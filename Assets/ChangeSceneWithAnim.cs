using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithAnim : MonoBehaviour
{
    public string sceneName;
    Coroutine co;
    
    public void changeSceneAfterAnim()
    {
        SceneManager.LoadScene(sceneName);
    }

    }
