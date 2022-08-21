using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public string SceneName;
    public int index;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Button")){
            //  SceneManager.LoadScene(SceneName);
            SceneManager.LoadScene(index);
        }
    }
}
