using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Project_2;

public class Main_Music : MonoBehaviour
{
    public AudioMixer mixer_mainmusic;

    public void SetSound(float soundLevel)
    {
        mixer_mainmusic.SetFloat("Master_Base_Music", soundLevel);
    }
}