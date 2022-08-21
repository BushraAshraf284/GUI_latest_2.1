using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogindbConnect : MonoBehaviour
{

    public ParticleSystem particle;
    public ParticleSystem partexit;
    public string sceneName2;
    private string databasevalue;
    public Button btnNext;
    public Button btnQuit;
    public InputField LoginUser;
    public InputField loginPass;
    public static string user, pass;
    public GameObject LoginuserError;
    public GameObject loginPassError;
    public GameObject Errorcredential;
    
    void Start()
    {
        btnQuit.onClick.AddListener(ExittoMainMenu);
        btnNext.onClick.AddListener(GetInputOnClickHandler);

    }

    // Update is called once per frame


    public void ExittoMainMenu()
    {
        partexit.Stop();
        partexit.Play();
        Application.Quit();
    }
    public void GetInputOnClickHandler()
    {
       
        if (string.IsNullOrWhiteSpace(LoginUser.text))
        {

            LoginuserError.SetActive(true);
        }
        else if (string.IsNullOrWhiteSpace(loginPass.text))
        {
            loginPassError.SetActive(true);
        }
        else
        {
            LoginuserError.SetActive(false);
            loginPassError.SetActive(false);
            StartCoroutine(Login(LoginUser.text, loginPass.text));
          
            
         }
        
    }


    IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("uname", username);
        form.AddField("pass", password);
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
                databasevalue= www.downloadHandler.text;
                if(string.Equals(databasevalue, "Login Success"))
                {
                    Debug.Log(databasevalue);
                    user = LoginUser.text;
                    pass = loginPass.text;
                    particle.Stop();
                    particle.Play();
                    StartCoroutine(Change());
                    

                }
                else
                {
                    Errorcredential.SetActive(true);
                    Debug.Log("invalid credentials");
                }

                // or retrive results as binary data 
                byte[] results = www.downloadHandler.data;
                
            }


        }
    }


    IEnumerator Change()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName2);
    }

}
