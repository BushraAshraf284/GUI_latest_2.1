
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class getscoredb : MonoBehaviour
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
        
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/mathapis/getScore.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //show results as text
                Debug.Log("Score from db"+ www.downloadHandler.text); // set value of score to the game object of score

                GlobalScore.Score = int.Parse(www.downloadHandler.text);
                Debug.Log("Global score db: " + GlobalScore.Score);
                // or retrive results as binary data 
                byte[] results = www.downloadHandler.data;
                
            }
        }
    }
}
