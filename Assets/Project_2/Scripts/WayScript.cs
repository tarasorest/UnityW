using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Project_2
{
    public class WayScript : MonoBehaviour
    {
        public NavMeshAgent nawmeshagent;
        [SerializeField] private GameObject _pers;


        void Update()
        {
            if(_pers !=null)
            nawmeshagent.SetDestination(_pers.transform.position);
        }

    }
}
