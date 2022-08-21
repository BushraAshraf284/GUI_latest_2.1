using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetScore : MonoBehaviour
{
    public TextMeshProUGUI score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score.text = GlobalScore.Score.ToString();
    }
}
