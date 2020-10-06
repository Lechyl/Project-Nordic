using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    
    public AudioMixer mixer;

    public Slider VolSlider;
    public Slider MusicSlider;
    public Slider SFXSlider;

    public void SetMasterVol(float sliderValue)
    {
        VolSlider = GetComponent<Slider>();

        if (MusicSlider.value >= VolSlider.value)
        {
            MusicSlider.value = VolSlider.value;
        }

        if (SFXSlider.value >= VolSlider.value)
        {
            SFXSlider.value = VolSlider.value;
        }

        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
    }


    public void SetMusicVol(float sliderValue)
    {
        if (MusicSlider.value >= VolSlider.value)
        {
            MusicSlider.value = VolSlider.value;
        }

        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSFXVol(float sliderValue)
    {
        if (SFXSlider.value >= VolSlider.value)
        {
            SFXSlider.value = VolSlider.value;
        }

        mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
    }

}
