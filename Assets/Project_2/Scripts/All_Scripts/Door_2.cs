using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_2
{
    public class Door_2 : MonoBehaviour
    {
        [SerializeField] private GameObject _guy;
        [SerializeField] private Transform _rotatePoint;
        private void OnTriggerEnter(Collider other)
        {
            if(_guy!=null)
            if (other.CompareTag("Player"))
            {
                if (_guy.GetComponent<Player>()._keyen)
                {
                    _rotatePoint.Rotate(Vector3.up, 90);
                        Debug.Log("You Win!!!");
                    if(_guy!=null)
                    Destroy(_guy);
                }
            }
        }
    }
}
