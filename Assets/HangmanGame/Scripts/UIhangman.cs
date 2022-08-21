using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIhangman : MonoBehaviour
{
    public TextMeshProUGUI problemText;                // text that displays the maths problem
    public TextMeshProUGUI[] answersTexts;                        // array of the 4 answers texts
    public TextMeshProUGUI endText;                    // text displayed a the end of the game (win or game over)

    // instance
    public static UIhangman instance;

    void Awake ()
    {
        // set instance to be this script
        instance = this;
    }



    // sets the ship UI to display the new problem ------------- //change made
    public void SetProblemText (Question question)
    {
        /*string operatorText = "";

        // convert the problem operator from an enum to an actual text symbol
        switch(problem.operation)
        {
            case MathsOperation.Addition: operatorText = " + "; break;
            case MathsOperation.Subtraction: operatorText = " - "; break;
            case MathsOperation.Multiplication: operatorText = " x "; break;
            case MathsOperation.Division: operatorText = " ÷ "; break;
        }

        // set the problem text to display the problem*/   //this part is changed
        problemText.text = question.problem;
        answersTexts[0].text = question.choice1;
        answersTexts[1].text = question.choice2;
        answersTexts[2].text = question.choice3;
        answersTexts[3].text = question.choice4;

    }

    // sets the end text to display if the player won or lost
    public void SetEndText (bool win)
    {
        // enable the end text object
        endText.gameObject.SetActive(true);

        // did the player win?
        if (win)
        {
            endText.text = "yayy You Win...";
           // endText.color = Color.purple;
        }
        // did the player lose?
        else
        {
            endText.text = "Game Over!";
         //   endText.color = Color.red;
        } 
    }
}