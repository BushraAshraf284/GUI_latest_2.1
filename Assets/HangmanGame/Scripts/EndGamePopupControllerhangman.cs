using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGamePopupControllerhangman : MonoBehaviour {

	public GameObject LosePopUp; //change endGameOverlayPanel -> VictoryPopUp
	public GameObject VictoryPopUp; //change //add
	public GameObject EndGamePopUp;
	public Text VictoryScore;
	public Text LoseScore;
	public GameObject nostar;
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	public GameObject hangparts;

	public static EndGamePopupControllerhangman instance;

	void Awake()
	{
		// set instance to be this script
		instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void ScoreCheck(int score, int totalQuestions)
	{
		EndGamePopUp.SetActive(true);
		hangparts.SetActive(false);
		float totalscore = totalQuestions * 10;

		float scorePercentage = (score / totalscore) * 100;

		Debug.Log("Score:" + score + " totalQuestions: " + totalQuestions + " totalscore: " + totalscore + " score Percentage: " + scorePercentage);


		
		if (scorePercentage >= 90)
		{
			
			VictoryPopUp.SetActive(true);
			star3.SetActive(true);
			VictoryScore.text = scorePercentage + "%";
		}
		else if (scorePercentage >= 75)
		{
			
			VictoryPopUp.SetActive(true);
			star2.SetActive(true);
			VictoryScore.text = scorePercentage + "%";
		}
		else if (scorePercentage >= 50)
		{
			
			VictoryPopUp.SetActive(true);
			star1.SetActive(true);
			VictoryScore.text = scorePercentage + "%";
		}
		else if (scorePercentage < 50)
		{
			LosePopUp.SetActive(true);
			nostar.SetActive(true);
			LoseScore.text = scorePercentage + "%";
		}

		Debug.Log("CurrentLevel:" + GlobalScore.CurrentLevel);
		Debug.Log("Score" + GlobalScore.Score);

		updatelevel((int)scorePercentage);

	}

	public void hidePopUp()
    {
		EndGamePopUp.SetActive(false);
		VictoryPopUp.SetActive(false);
		LosePopUp.SetActive(false);
	}

	public void updatelevel(int score)
    {
		GlobalScore.CurrentLevel++;
		GlobalScore.Score += score;
	}


}
