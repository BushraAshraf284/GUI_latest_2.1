
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Debug.Log(LevelSet.VideoToPlay);
        HideOthers();
        this.transform.GetChild(LevelSet.VideoToPlay-1).gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HideOthers()
    {
        
        if(GlobalScore.CurrentLevel<=1)
        {
            for(int i=0; i<this.transform.childCount;i++)
                this.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
