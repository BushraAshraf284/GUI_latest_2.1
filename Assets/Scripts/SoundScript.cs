using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
    public static readonly string VolumePrefs = "VolumePrefs";
    public static readonly string sfxPrefs = "sfxPrefs";
    private float VolumeFloat, sfxFloat, prevVolume, prevSfx;
    private Music music;
   // public Button musicToggleButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    private bool on = true;
    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindObjectOfType<Music>();
      //  this.GetComponent<Image>().sprite = musicOnSprite;
        UpdateIconAndVolume();
    }

    // Update is called once per frame
 
    public void PauseMusic()
    {
        music.ToggleSound();
        UpdateIconAndVolume();
        SaveSoundSettings();
    }

    void UpdateIconAndVolume()
    {
        if(PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            VolumeFloat = PlayerPrefs.GetFloat(VolumePrefs);
            sfxFloat = PlayerPrefs.GetFloat(sfxPrefs);
            //volumeAudio.volume = VolumeFloat;
            AudioListener.volume = VolumeFloat;
           
          //  musicToggleButton.GetComponent<Image>().sprite = musicOnSprite;
            this.GetComponent<Image>().sprite = musicOnSprite;
            on = false;
            
        }
        else
        {
            AudioListener.volume = 0;
          // musicToggleButton.GetComponent<Image>().sprite = musicOffSprite;
           this.GetComponent<Image>().sprite = musicOffSprite;
            on = true;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(VolumePrefs, VolumeFloat);
        PlayerPrefs.SetFloat(sfxPrefs, sfxFloat);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

}
