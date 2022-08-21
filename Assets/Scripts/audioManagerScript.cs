using UnityEngine;
using UnityEngine.UI;

public class audioManagerScript : MonoBehaviour
{
    public static readonly string FirstPlay = "FirstPlay";
    public static readonly string VolumePrefs = "VolumePrefs";
    public static readonly string sfxPrefs = "sfxPrefs";
    private int firstPlayInt;
    public Slider VolumeSlider,sfxSlider;
    private float VolumeFloat, sfxFloat;
    public AudioSource volumeAudio;
    public AudioSource[] sfxAudio;
    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if(firstPlayInt == 0)
        {
            VolumeFloat = .125f;
            sfxFloat = .75f;
            VolumeSlider.value = VolumeFloat;
            sfxSlider.value = sfxFloat;
            PlayerPrefs.SetFloat(VolumePrefs, VolumeFloat);
            PlayerPrefs.SetFloat(sfxPrefs, sfxFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            VolumeFloat = PlayerPrefs.GetFloat(VolumePrefs);
            VolumeSlider.value = VolumeFloat;
            sfxFloat = PlayerPrefs.GetFloat(sfxPrefs);
            sfxSlider.value = sfxFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(VolumePrefs, VolumeSlider.value);
        PlayerPrefs.SetFloat(sfxPrefs, sfxSlider.value);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        volumeAudio.volume = VolumeSlider.value;
        AudioListener.volume = VolumeSlider.value;
        for(int i=0; i< sfxAudio.Length; i++)
        {
            sfxAudio[i].volume = sfxSlider.value;
        }
    }
}
