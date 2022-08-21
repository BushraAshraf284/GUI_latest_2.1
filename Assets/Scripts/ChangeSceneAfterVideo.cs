using System.Diagnostics;
using System.Net.Sockets;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ChangeSceneAfterVideo : MonoBehaviour
{
     VideoPlayer video;
     public string sceneName;
     public TrailerSoundManager sound;
 
    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
 
         
    }
 
 
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        if(sound != null)
        {
            sound.UnMute();
        }
        SceneManager.LoadScene(sceneName);//the scene that you want to load after the video has ended.
        
    }
}
