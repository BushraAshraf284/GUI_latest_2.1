using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerRocket : MonoBehaviour
{
   // public Problem[] problems;      // list of all problems
    public int curProblem;          // current problem the player needs to solve
   /*  public float timePerProblem;    // time allowed to answer each problem

     public float remainingTime;  */   // time remaining for the current problem

    public PlayerControllerRocket player; // player object

    // instance
    public static GameManagerRocket instance;

    public AudioSource audio;
    public AudioSource youWin;
    public AudioSource youWinVoice;
    public AudioSource youLose;
    public AudioSource correctAns;
    public AudioSource wrongAns;

    //health

    public static int health;
    public GameObject heart1, heart2, heart3, gameOver;
    // public TextMeshProUGUI gameOver;
    //Question_Bank
    public TextAsset[] jsonFiles;
    Questions questionsInJson;

    void Awake ()
    {
        // set instance to this script.
        instance = this;
    }

    void Start ()
    {
        // set the initial problem
        EndGamePopupControllerRocket.instance.hidePopUp();
        Debug.Log("Level Set: " + (LevelSet.VideoToPlay - 1));
        questionsInJson = JsonUtility.FromJson<Questions>(jsonFiles[LevelSet.VideoToPlay - 1].text);
        SetProblem(0);
        
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
     //   gameOver.gameObject.SetActive(false);
    }

    void Update ()
    {
       // remainingTime -= Time.deltaTime;

        // has the remaining time ran out?
     /*   if(remainingTime <= 0.0f)
        {
            Lose();
        } */
     if (health > 3)
        {
            health = 3;
        }
        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                //  gameOver.gameObject.SetActive(true);
                EndGamePopupControllerRocket.instance.ScoreCheck(ScoreScriptRocket.scoreValue, questionsInJson.questions.Length);
                audio.Stop();
                Time.timeScale = 0.0f;
                break;
        }
    }

    // called when the player enters a tube
    public void OnPlayerEnterTube (int tube)
    {
        // did they enter the correct tube?
        if (tube == int.Parse(questionsInJson.questions[curProblem].correctanswer) - 1)
        {
            CorrectAnswer();
           
        }
        else
            IncorrectAnswer();
            
    }

    // called when the player enters the correct tube
    void CorrectAnswer()
    {
        // is this the last problem?
        if(questionsInJson.questions.Length - 1 == curProblem)
            Win();
        else
        {
            SetProblem(curProblem + 1);
            GameManagerRocket.health += 1;
            correctAns.Play();
        }
        ScoreScriptRocket.scoreValue += 10;

    }

    // called when the player enters the incorrect tube
    void IncorrectAnswer ()
    {
        player.Stun();
        wrongAns.Play();
    }

    // sets the current problem
    void SetProblem (int problem)
    {
        curProblem = problem;
        UIRocket.instance.SetProblemText(questionsInJson.questions[curProblem]);

        // remainingTime = timePerProblem;
    }

    // called when the player answers all the problems
    void Win ()
    {
        EndGamePopupControllerRocket.instance.ScoreCheck(ScoreScriptRocket.scoreValue, questionsInJson.questions.Length);
        youWin.Play();
        youWinVoice.Play();
        audio.Stop();
        Time.timeScale = 0.0f;
        
       // UI.instance.SetEndText(true);
        
    }

    // called if the remaining time on a problem reaches 0
    void Lose ()
    {
        EndGamePopupControllerRocket.instance.ScoreCheck(ScoreScriptRocket.scoreValue, questionsInJson.questions.Length);
        youLose.Play();
        audio.Stop();
        Time.timeScale = 0.0f;
      //  UI.instance.SetEndText(false);
        
    } 
}