using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionRocket : MonoBehaviour
{
	// Start is called before the first frame update
	public void ClickPlay()
	{
		Debug.Log("play");
		SceneManager.LoadScene("RocketLaunchGame");
		
	}
}
