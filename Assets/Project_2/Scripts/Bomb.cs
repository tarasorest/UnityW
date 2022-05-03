using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_2
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy_3"))
            {
                var objEnemy = enemy.GetComponent<Enemy_3>();
                objEnemy.OnDestroy();
                Destroy(enemy);
                Destroy(gameObject);
            }
        }
    }
}
