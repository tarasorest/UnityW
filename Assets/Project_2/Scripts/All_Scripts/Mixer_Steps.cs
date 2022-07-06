using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Project_2;

public class Mixer_Steps : MonoBehaviour
{
    public AudioMixer mixer_steps;

    public void SetSound(float soundLevel)
    {
        mixer_steps.SetFloat("Master_Steps_Sound", soundLevel);
    }
}