using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Runparticle2 : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ps;
    public string sceneName;
    public Button btnClick;
    public InputField inputUser;
    public InputField pass;
   // public InputField confmPass;
   // public InputField email;
    public GameObject userError;
    public GameObject passError;
   // public GameObject cfrmpassError;
   // public GameObject emailError;
   //  public Text confirmpassError;

    // private GettingUserData stopbutton;
    void Start()
    {
        btnClick.onClick.AddListener(GetInputOnClickHandler);
    }

    // Update is called once per frame
    void Update()
    {

    }
    /* public void PlayParticles()
     {
         ps.Stop();
         ps.Play ();
         StartCoroutine(Change());
     } */

    public void GetInputOnClickHandler()
    {


        if (string.IsNullOrWhiteSpace(inputUser.text))
        {

            userError.SetActive(true);
        }
        else if (string.IsNullOrWhiteSpace(pass.text))
        {
            passError.SetActive(true);
        }
       /* else if (string.IsNullOrWhiteSpace(confmPass.text))
        {
            cfrmpassError.SetActive(true);
        }
        else if (string.IsNullOrWhiteSpace(email.text))
        {
            emailError.SetActive(true);
        } */

        else
        {

          /*  if (string.Equals(pass.text, confmPass.text))
            { */
                userError.SetActive(false);
                passError.SetActive(false);
             //   cfrmpassError.SetActive(false);
             //   emailError.SetActive(false);
                StartCoroutine(LoginUser(inputUser.text, pass.text));
                ps.Stop();
                ps.Play();
                StartCoroutine(Change());
           // }
         /*   else
            {
                cfrmpassError.SetActive(true);
                confirmpassError.text = "Password Mismatch !";
                Debug.Log("Sorry your password doesn't match");
            } */
        }

    }
    IEnumerator Change()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoginUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("uname", username);
        form.AddField("pass", password);
      /*  form.AddField("cpass", confirmpass);
        form.AddField("email", email); */
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/mathapis/login.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //show results as text
                Debug.Log(www.downloadHandler.text);

                // or retrive results as binary data 
                byte[] results = www.downloadHandler.data;
            }

        }


    }
}
