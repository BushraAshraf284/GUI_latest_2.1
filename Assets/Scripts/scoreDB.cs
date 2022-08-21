
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class scoreDB : MonoBehaviour
{
    // public TextMeshProUGUI score;

    void Start()
    {
        StartCoroutine(Score(GlobalScore.Score.ToString(), GlobalScore.CurrentLevel.ToString()));
    }
    // Start is called before the first frame update
    IEnumerator Score(string score, string curlevel)
    {
        Debug.Log("Username:" + LogindbConnect.user);
        Debug.Log("Password:" + LogindbConnect.pass);
        Debug.Log("MycurrentLvel: " + curlevel);
        Debug.Log("Myscore" + score);

        WWWForm form = new WWWForm();
        Debug.Log("score success" + score.ToString());
        form.AddField("uname", LogindbConnect.user);
        form.AddField("pass", LogindbConnect.pass);
        form.AddField("score", score);
        form.AddField("level", curlevel);



        //  Debug.Log("login name" + LogindbConnect.LoginUser.text);

        //Need Username and password from lgindbconnect
        //create new api for score

        //   form.AddField("cpass", confirmpass);
        //   form.AddField("email", email);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/mathapis/scorelevelDB.php", form))
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
                /* if (string.Equals(databasevalue, "Login Success"))
                 {
                     Debug.Log(databasevalue);
                     particle.Stop();
                     particle.Play();
                     StartCoroutine(Change());
                 }
                 else
                 {
                     Errorcredential.SetActive(true);
                     Debug.Log("invalid credentials");
                 }
                */
                // or retrive results as binary data 
                byte[] results = www.downloadHandler.data;

            }
        }
    }
}
