using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_2
{
    public class BIG_B : MonoBehaviour
    {
        public GameObject player;
        [SerializeField] private GameObject _bomb;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                    _bomb.active = true;
                    Destroy(gameObject);
            }
        }
    }
}
