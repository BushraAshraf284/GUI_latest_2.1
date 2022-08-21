using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalScore : MonoBehaviour
{
    public static int Score;
    public static int CurrentLevel;
    void Start()
    {
        Score = 0;
        CurrentLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
