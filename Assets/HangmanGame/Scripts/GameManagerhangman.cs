using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerhangman : MonoBehaviour
{
  //  public Problem[] questionsInJson.questions;      // list of all problems //change //remove
    public int curProblem;          // current problem the player needs to solve
    // instance
    public static GameManagerhangman instance;
    
    public GameObject restart;
    public GameObject NextLevel;
    public GameObject playmenu;
    public GameObject playbutton;
    public GameObject questionSection;
    public GameObject[] hangParts;
    //change //remove end game pop controller
    private int missesCount;
    private int victoriesCount;
   //remove score

    //change
    public TextAsset[] jsonFiles;
    Questions questionsInJson;



    public GameObject floatingText;
    public float DestroyTime = 1f;
    // public GameObject explosionPrefab;
   // set music
    public AudioSource bgMusic;
    public AudioSource correctAns;
    public AudioSource wrongAns;
    public AudioSource WinAudio;
    public AudioSource youWinVoice;
    public AudioSource scoreMusic;

    //setting health
    //public int maxHealth = 100;
    //public int currentHealth;
    //public HealthBarScript healthBar;

    void Play()
    {
        playmenu.gameObject.SetActive(false);
        questionSection.gameObject.SetActive(true);
        missesCount = hangParts.Length;
        EndGamePopupControllerhangman.instance.hidePopUp(); //change

        // set the initial problem 
        Time.timeScale = 1f;
        SetProblem(0);
    }

    void Awake ()
    {
        // set instance to this script.
        instance = this;
    }

    void Start ()
    {
        //change
        Debug.Log("Level Set: "+ (LevelSet.VideoToPlay - 1));
        questionsInJson = JsonUtility.FromJson<Questions>(jsonFiles[LevelSet.VideoToPlay-1].text);
        /*foreach (Question q in questionsInJson.questions)
        {
            Debug.Log("Found object: problem:" + q.problem + " answer1: " + q.choice1 + " choice2: " + q.choice2 + " choice3: " + q.choice3 + " choice4: " + q.choice4);
        }*/
        playbutton.GetComponent<Button>().onClick.AddListener(() => Play());
        //currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);

    }


    // called when the player enters a tube
    public void OnPlayerEnterTube (int tube) //int changed to string
    {
        // did they enter the correct tube? //change
        if (tube == int.Parse(questionsInJson.questions[curProblem].correctanswer)-1)
        {
            showFloatingText();
            CorrectAnswer();
            correctAns.Play();

        }
        else
        {
            missesCount--;
            IncorrectAnswer();
            wrongAns.Play();
        }
            
    }

    // called when the player enters the correct tube
    public void CorrectAnswer()
    {
        // is this the last problem? //change
        if(questionsInJson.questions.Length - 1 == curProblem)
        {  
            StartCoroutine(Win());
            
        }
        else
        {
            SetProblem(curProblem + 1);
        //    Destroy(gameObject);
        }
        scoreMusic.Play();
        ScoreScripthangman.scoreValue += 10;
        victoriesCount++;

    }

    // called when the player enters the incorrect tube
    public void IncorrectAnswer ()
    {
        /*if (currentHealth > 0)
        {
            TakeDamage(20);
        }
        else if (currentHealth <= 0)
        {
            bgMusic.Stop();
            Time.timeScale = 0.0f;
            
          //  restart.gameObject.SetActive(true);
            
        }*/

        
        if (missesCount < 0)
        {
            //hangParts[missesCount].SetActive(true);
            Defeat();
        }
        else if (missesCount < hangParts.Length)
        {
            hangParts[missesCount].SetActive(true);
        }

        //missesCount++;

    }

    // sets the current problem
    public void SetProblem (int problem)
    {
        curProblem = problem;
        UIhangman.instance.SetProblemText(questionsInJson.questions[curProblem]); //change
    }

    

    // called when the player answers all the problems
    public IEnumerator Win ()
    {
        yield return new WaitForSeconds(2f);
        victoriesCount++;
        //endGamePopupController.DisplayPopup("You Win!", "Victories: " + victoriesCount); 
        // Scoremanager.score = victoriesCount;
        //change //add
        EndGamePopupControllerhangman.instance.ScoreCheck(ScoreScripthangman.scoreValue, questionsInJson.questions.Length);
        questionSection.SetActive(false);
        /*restart.gameObject.SetActive(true);
        NextLevel.gameObject.SetActive(true);*/
        bgMusic.Stop();       
        WinAudio.Play();
        youWinVoice.Play();
        Time.timeScale = 0.0f;
    }

    void showFloatingText()
    {
        if(floatingText!=null)
        {
            GameObject prefab = Instantiate(floatingText, transform.position, Quaternion.identity);
            //prefab.GetComponentInChildren<TextMeshProUGUI>().text = "+10";
            Destroy(prefab, DestroyTime);
            //Destroy(explosionPrefab, DestroyTime);
        }
      
    }

    private void Defeat()
    {
        //PlayAudioClip(defeatSound);
        // defeatsCount++;
        // endGamePopupController.DisplayPopup("You Lose!", "Victories: " + victoriesCount);
        //Scoremanager.score = victoriesCount;
        //change
        EndGamePopupControllerhangman.instance.ScoreCheck(ScoreScripthangman.scoreValue, questionsInJson.questions.Length);
        questionSection.SetActive(false);
    }

    private void Victory()
    {
        //PlayAudioClip(victorySound);
        
        
    }
    /*void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }*/

    

}