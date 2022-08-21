

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerSoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] Musics;
    private float prevVolume;
    void Start()
    {
         Musics = GameObject.FindGameObjectsWithTag("Music");
         Mute();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Mute()
    {
        if(Musics == null || Musics.Length == 0)
        {
            Debug.Log("No Music Found!");
        }
        else{
            
            foreach (GameObject music in Musics)
            {
                AudioSource audio = music.GetComponent<AudioSource>();
                prevVolume = audio.volume;
                audio.volume = 0;
                Debug.Log(music);
            }

           
        }
    }

    public void UnMute()
    {
       
        if(Musics == null || Musics.Length == 0)
        {
            Debug.Log("No Music Found!");
        }
        else{
            
            foreach (GameObject music in Musics)
            {
                AudioSource audio = music.GetComponent<AudioSource>();

                audio.volume = prevVolume;
                Debug.Log(music);
            }

           
        } 
    }
}
