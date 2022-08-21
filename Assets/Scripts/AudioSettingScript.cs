using UnityEngine;

public class AudioSettingScript : MonoBehaviour
{
    public static readonly string VolumePrefs = "VolumePrefs";
    public static readonly string sfxPrefs = "sfxPrefs";
    private float VolumeFloat, sfxFloat;
    public AudioSource volumeAudio;
    public AudioSource[] sfxAudio;
    // Start is called before the first frame update
    void Awake()
    {
        ContinueSettings();
    }

    // Update is called once per frame
    private void ContinueSettings()
    {
        VolumeFloat = PlayerPrefs.GetFloat(VolumePrefs);
        sfxFloat = PlayerPrefs.GetFloat(sfxPrefs);
        //volumeAudio.volume = VolumeFloat;
        AudioListener.volume = VolumeFloat;
        for (int i = 0; i < sfxAudio.Length; i++)
        {
            sfxAudio[i].volume = sfxFloat;
        }
    }
}
