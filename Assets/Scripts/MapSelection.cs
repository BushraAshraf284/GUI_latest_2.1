using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelection : MonoBehaviour
{
    public bool isUnlock = false;
    public GameObject UnlockLevel;
    public GameObject LockLevel;
    public int index;


    void Update()
    {
        UpdateMapSelection();
    }

    public void UpdateMapSelection()
    {
        if(isUnlock)
        {
            UnlockLevel.SetActive(true);
            LockLevel.SetActive(false);
        }
        else
        {
            UnlockLevel.SetActive(false);
            LockLevel.SetActive(true);
        }
    }

    /*public void UpdateMap()
    {
        if(GlobalScore.Score >= questNum)
        {
            isUnlock = true;
        }
        else
        {
            isUnlock = false;
        }
    }*/

    public void SetVideoIndex()
    {
        LevelSet.VideoToPlay = index;
    }

    
}
