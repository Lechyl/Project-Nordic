using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadAudio : MonoBehaviour
{

    public Slider MusicSlider;
    // Start is called before the first frame update
    void Start()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVol");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
