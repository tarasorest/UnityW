using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_2
{
    public class Health : MonoBehaviour
    {
        public GameObject player;
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    var healthpoints = player.GetComponent<Player>();
                    healthpoints._durability += 20;
                    Destroy(gameObject);
                }
            }
        }
    }
}
