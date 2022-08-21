using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Question
{
    //these variables are case sensitive and must match the strings "firstName" and "lastName" in the JSON.
    public string problem;
    public string choice1;
    public string choice2;
    public string choice3;
    public string choice4;
    public string correctanswer;
}