using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;

    public AudioSettings[] sounds;

    public Slider VolSlider;
    public Slider MusicSlider;
    public Slider SFXSlider;



    // Start is called before the first frame update
    void Awake()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVol", 1f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVol", 1f);

        foreach (AudioSettings s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }
    }

    public void Play(string name)
    {
        AudioSettings s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }




    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
    }



}
