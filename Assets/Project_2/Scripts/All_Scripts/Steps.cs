using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Steps : MonoBehaviour
{
    private AudioSource _source;

    [SerializeField] AudioClip[] _sounds;
    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
    public void Step()
    {
        var sound = _sounds[Random.Range(0, _sounds.Length)];
        _source.PlayOneShot(sound);
    }



}
