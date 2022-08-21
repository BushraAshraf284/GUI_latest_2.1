 using UnityEngine;
 using System.Collections;
 
 public class StaticAudio : MonoBehaviour
 {
 
     private static StaticAudio instance = null;
     public static StaticAudio Instance
     {
         get { return instance; }
     }
     void Awake()
     {
         if (instance != null && instance != this) {
             Destroy(this.gameObject);
             return;
         } else {
             instance = this;
         }
         DontDestroyOnLoad(this.gameObject);
     }
     // any other methods you need
 }