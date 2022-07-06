using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Project_2;

public class Sounds_Value : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void SetSound(float soundLevel)
    {
        masterMixer.SetFloat("Sound", soundLevel);
    }
}