using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Project_2;
using UnityEngine.AI;

public class StandartParametres : MonoBehaviour
{

    void Update()
    {
        var objEnem3 = GameObject.FindGameObjectWithTag("Enemy_3");
        var compEnem3 = objEnem3.GetComponent<Enemy_3>();
        compEnem3.durability = 150f;
        compEnem3._speed = 20f;
        compEnem3._bulspeed = 50f;

        var objGuard = GameObject.FindGameObjectWithTag("Guard");
        var compGuard = objGuard.GetComponent<Guardian>();
        var seccompGuard = objGuard.GetComponent<NavMeshAgent>();
        compGuard.durability = 300f;
        compGuard._distance = 20f;
        compGuard._bltspeed = 40f;
        seccompGuard.speed = 20f;
    }
}
