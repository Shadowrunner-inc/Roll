using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class VolumeControl : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] UnityEngine.UI.Slider Slider;
    [SerializeField] string VolumeParameter = "MasterVolume";

    void Awake()
    {
        Slider.onValueChanged.AddListener(HandelSliderValueChanged);
    }

    void Start()
    {
       Slider.value = PlayerPrefs.GetFloat(VolumeParameter, Slider.value);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(VolumeParameter, Slider.value);
    }
  
    void HandelSliderValueChanged(float value)
    {
        print(value);
        mixer.SetFloat(VolumeParameter, value);
    }
}
