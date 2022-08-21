using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class signDBConnection : MonoBehaviour
{
    
    public ParticleSystem ps;
    public ParticleSystem psexit;
    public string sceneName;
  
    public Button btnClick;
    public Button btnExit;
    public InputField inputUser;
    public InputField pass;
    public InputField confmPass;
    public InputField email;
    public GameObject userError;
    public GameObject passError;
    public GameObject cfrmpassError;
    public GameObject emailError;
    public Text confirmpassError;

    void Start()
    {
        btnExit.onClick.AddListener(ExittoMainMenu);
        btnClick.onClick.AddListener(GetInputOnClickHandler);
        
    }

    // Update is called once per frame


    public void ExittoMainMenu()
    {
        psexit.Stop();
        psexit.Play();
        Application.Quit();
    }
    public void GetInputOnClickHandler()
    {
        
     
        if (string.IsNullOrWhiteSpace(inputUser.text))
         {
           
            userError.SetActive(true);
        }
        else if(string.IsNullOrWhiteSpace(pass.text))
        {
            passError.SetActive(true);
        }
        else if (string.IsNullOrWhiteSpace(confmPass.text))
        {
            cfrmpassError.SetActive(true);
        }
        else if (string.IsNullOrWhiteSpace(email.text))
        {
            emailError.SetActive(true);
        }
        
        else 
        {   
            if (string.Equals(pass.text, confmPass.text))
            {
                userError.SetActive(false);
                passError.SetActive(false);
                cfrmpassError.SetActive(false);
                emailError.SetActive(false);
                StartCoroutine(RegisterUser(inputUser.text,pass.text, confmPass.text, email.text));
                 ps.Stop();
                 ps.Play();
                 StartCoroutine(Change());
            }
            else
            {
                cfrmpassError.SetActive(true);
                confirmpassError.text = "Password Mismatch !";
                Debug.Log("Sorry your password doesn't match");
            }        
        }

    }
  

    IEnumerator RegisterUser(string username, string password, string confirmpass, string email)
    {
        Debug.Log("This is my score: " + GlobalScore.Score.ToString());
        WWWForm form = new WWWForm();
        form.AddField("uname", username);
        form.AddField("pass", password);
        form.AddField("cpass", confirmpass);
        form.AddField("email", email);
        form.AddField("score", 0);
        form.AddField("level", 0);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/mathapis/signup.php", form))
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

     IEnumerator Change() 
     {
         yield return new WaitForSeconds(1);
         SceneManager.LoadScene(sceneName);
     }

}
