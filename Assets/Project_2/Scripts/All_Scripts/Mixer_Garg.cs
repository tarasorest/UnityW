using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Project_2;

public class Mixer_Garg : MonoBehaviour
{
    public AudioMixer mixer_garg;

    public void SetSound(float soundLevel)
    {
        mixer_garg.SetFloat("Master_Garg_Shot", soundLevel);
    }
}