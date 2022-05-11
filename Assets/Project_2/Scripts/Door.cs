using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_2
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Transform _rotatePoint;
        private bool _isStopped;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")||other.CompareTag("Guard") && !_isStopped)
            {
                _rotatePoint.Rotate(Vector3.up, 90);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("Guard") && !_isStopped)
            {
                _rotatePoint.Rotate(Vector3.up, -90);
            }
        }
    }
}
