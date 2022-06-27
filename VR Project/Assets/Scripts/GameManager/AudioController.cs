using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider audioSlider;

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.GetFloat("AllAudio", out float i);
        audioSlider.value = i;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioControl ()
    {
        float volume = audioSlider.value;

        if (volume == -40f)
            audioMixer.SetFloat("AllAudio", -80);
        else
            audioMixer.SetFloat("AllAudio", volume);
    }
}
