using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public soundManager soundManager;
    public volume volume;
    public Slider slider_music;
    public Slider slider_SFX;


    private void Start()
    {
        soundManager = FindObjectOfType<soundManager>();
        slider_music.value = volume.CurvolumeMusic;
        slider_SFX.value = volume.CurvolumeSFX;
    }
    private void Update()
    {
        if(soundManager == null)
        {
            soundManager = FindObjectOfType<soundManager>();
        }
        updateVolume();
    }

    public void updateVolume()
    {
        if (slider_music.value != volume.CurvolumeMusic)
        {
            volume.CurvolumeMusic = slider_music.value;
            soundManager.setVolumeMusic(volume.CurvolumeMusic);
        }

        if (slider_SFX.value != volume.CurvolumeSFX)
        {
            volume.CurvolumeSFX = slider_SFX.value;
            soundManager.setVolumeSFX(volume.CurvolumeSFX);
        }
    }
}
