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
                    mine.GetComponent<Mine1>()._isEnable = false;
                    mine.GetComponent<Mine2>()._isEnable = false;
                    mine.GetComponent<Mine3>()._isEnable = false;
                    mine.GetComponent<Mine4>()._isEnable = false;
                    mine.GetComponent<Mine5>()._isEnable = false;
                    mine.GetComponent<Mine6>()._isEnable = false;
                }
            }
        }
    }
}
