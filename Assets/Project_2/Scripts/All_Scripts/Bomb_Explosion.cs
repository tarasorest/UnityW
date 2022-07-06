using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Explosion : MonoBehaviour
{
    private AudioSource _expl_source;
    [SerializeField] private AudioClip _expl;
    void Awake()
    {
        _expl_source = GetComponent<AudioSource>();
    }

    public void b_expl_1()
    {
        _expl_source.PlayOneShot(_expl);
    } 

}
