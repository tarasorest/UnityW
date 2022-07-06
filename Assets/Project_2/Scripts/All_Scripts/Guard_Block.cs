using Project_2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard_Block : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _ghost;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Guard"))
        {
            other.GetComponent<Rigidbody>().isKinematic = false;
            Vector3 dir = (gameObject.transform.position - other.transform.position).normalized;
            other.GetComponent<Rigidbody>().AddForce(dir * -1200f, ForceMode.Impulse);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Guard"))
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
        }
        else if(other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().isKinematic = false;
            _ghost.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
