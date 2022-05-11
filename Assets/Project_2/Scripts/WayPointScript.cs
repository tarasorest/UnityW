using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Project_2
{
    public class WayPointScript : MonoBehaviour
    {
        public NavMeshAgent nawmeshagent;
        public Transform[] waypoints;
        int m_currentwaypoint_index;
        void Start()
        {
            nawmeshagent.SetDestination(waypoints[0].position);
        }
    

        void Update()
        {
            if (nawmeshagent.remainingDistance <= nawmeshagent.stoppingDistance)
            {
                m_currentwaypoint_index = (m_currentwaypoint_index + 1) % waypoints.Length;
                nawmeshagent.SetDestination(waypoints[m_currentwaypoint_index].position);
            }
        }

    }
}
