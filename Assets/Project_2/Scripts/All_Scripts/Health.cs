using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_2
{
    public class Health : MonoBehaviour
    {
        public GameObject player;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                    var healthpoints = player.GetComponent<Player>();
                    healthpoints._durability += 20;
                    Destroy(gameObject);
            }
        }
    }
}
