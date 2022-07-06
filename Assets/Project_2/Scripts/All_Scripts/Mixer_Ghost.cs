using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Project_2;

public class Mixer_Ghost : MonoBehaviour
{
    public AudioMixer mixer_ghost;

    public void SetSound(float soundLevel)
    {
        mixer_ghost.SetFloat("Master_Ghost_Shot", soundLevel);
    }
}