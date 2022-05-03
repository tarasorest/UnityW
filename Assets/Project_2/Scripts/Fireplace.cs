using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_2
{
    public class Fireplace : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Table"))
            {
                GameObject[] mines = GameObject.FindGameObjectsWithTag("Mine");
                foreach (var mine in mines)
                {
                    Debug.Log("Hit");
                    mine.GetComponent<Mine>()._isEnable = false;
                }
            }
        }
    }
}
