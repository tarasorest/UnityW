using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume_Controller : MonoBehaviour
{
    public string VolumeParameter = "MasterVolume";
    public AudioMixer mixer;
    public Slider slider;
    public Text text;
    private float _volumeValue;
    private const float _multiplier = 33.5f;
    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        _volumeValue = Mathf.Log10(value) * _multiplier;
        text.text = Mathf.Round(Mathf.Log10(value) * _multiplier) + 100 + "%";
        mixer.SetFloat(VolumeParameter, _volumeValue);
    }
    void Start()
    {
        _volumeValue = PlayerPrefs.GetFloat(VolumeParameter, Mathf.Log10(slider.value) * _multiplier);
        text.text = Mathf.Round(PlayerPrefs.GetFloat(VolumeParameter, Mathf.Log10(slider.value) * _multiplier)) + 100 + "%";
        slider.value = Mathf.Pow(10f, _volumeValue / _multiplier);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(VolumeParameter, _volumeValue);
    }
}
