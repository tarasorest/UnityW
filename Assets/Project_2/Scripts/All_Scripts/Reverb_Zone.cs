using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverb_Zone : MonoBehaviour
{
    [SerializeField] private AudioReverbZone _comp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _comp.enabled = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _comp.enabled = false;
    }
}
