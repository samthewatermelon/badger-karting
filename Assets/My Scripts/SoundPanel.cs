using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SoundPanel : MonoBehaviour
{
    public AudioMixer theMixer;

    public TMP_Text masterLabel, musicLabel, sfxLabel;

    public Slider masterslider, musicslider, sfxslider;

    public void SetMasterVol()
    {
        masterLabel.text = Mathf.RoundToInt(masterslider.value + 80).ToString();

        theMixer.SetFloat("MasterVol", masterslider.value);
    }

    public void SetMusicVol()
    {
        musicLabel.text = Mathf.RoundToInt(musicslider.value + 80).ToString();

        theMixer.SetFloat("MusicVol", musicslider.value);
    }

    public void SetSfxVol()
    {
        sfxLabel.text = Mathf.RoundToInt(sfxslider.value + 80).ToString();

        theMixer.SetFloat("SFXVol", sfxslider.value);
    }

    public void MuteToggle(bool mute)
    {
        if (mute)
        {
            AudioListener.volume = 0;
        }
        else 
        {
            AudioListener.volume = 1;
        }
    }







    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
