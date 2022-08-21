using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSet : MonoBehaviour
{
    public static int VideoToPlay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateLevel();
    }

    void UpdateLevel()
    {
        for(int i=0; i<GlobalScore.CurrentLevel;i++)
            this.transform.GetChild(i).GetComponent<MapSelection>().isUnlock = true;
    }
}
