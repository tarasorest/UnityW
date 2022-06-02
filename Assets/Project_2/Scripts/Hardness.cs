using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Project_2;
using UnityEngine.AI;

public class Hardness : MonoBehaviour
{

    public void Start()
    {        
        if (gameObject != null)
        {
            var objGuard = GameObject.FindGameObjectWithTag("Guard");
            var objEnem3 = GameObject.FindGameObjectWithTag("Enemy_3");

            if (GameObject.FindGameObjectWithTag("Enemy_3") != null && GameObject.FindGameObjectWithTag("Guard") != null)
            {
                var compEnem3 = objEnem3.GetComponent<Enemy_3>();
                var compGuard = objGuard.GetComponent<Guardian>();
                var seccompGuard = objGuard.GetComponent<NavMeshAgent>();
                if (gameObject.GetComponent<TMP_Dropdown>().value == 0)
                {


                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>().durability += 150f;
                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>()._speed += 40;
                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>()._bulspeed += 15f;

                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>().durability += 150f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>()._distance += 10f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>()._bltspeed -= 20f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<NavMeshAgent>().speed += 10f;
                }
                else if (gameObject.GetComponent<TMP_Dropdown>().value == 1)
                {

                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>().durability += 100f;
                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>()._speed += 5f;
                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>()._bulspeed += 10f;

                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>().durability += 100f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>()._distance += 5f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>()._bltspeed -= 10f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<NavMeshAgent>().speed += 5f;

                }
                else
                {
                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>().durability = 150f;
                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>()._speed = 20f;
                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>()._bulspeed = 50f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>().durability = 300f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>()._distance = 20f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>()._bltspeed = 40f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<NavMeshAgent>().speed = 20f;
                }
            }
            else if (GameObject.FindGameObjectWithTag("Guard") == null)
            {
                var compEnem3 = objEnem3.GetComponent<Enemy_3>();
                if (gameObject.GetComponent<TMP_Dropdown>().value == 0)
                {

                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>().durability += 150f;
                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>()._speed += 10f;
                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>()._bulspeed += 15f;
                }
                else if (gameObject.GetComponent<TMP_Dropdown>().value == 1)
                {

                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>().durability += 100f;
                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>()._speed += 5f;
                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>()._bulspeed += 10f;

                }
                else
                {
                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>().durability = 150f;
                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>()._speed = 20f;
                    GameObject.FindGameObjectWithTag("Enemy_3").GetComponent<Enemy_3>()._bulspeed = 50f;
                }
            }
            else if (GameObject.FindGameObjectWithTag("Guard") == null)
            {
                var compGuard = objGuard.GetComponent<Guardian>();
                var seccompGuard = objGuard.GetComponent<NavMeshAgent>();
                if (gameObject.GetComponent<TMP_Dropdown>().value == 0)
                {

                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>().durability += 150f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>()._distance += 10f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>()._bltspeed -= 20f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<NavMeshAgent>().speed += 10f;
                }
                else if (gameObject.GetComponent<TMP_Dropdown>().value == 1)
                {

                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>().durability += 100f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>()._distance += 5f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>()._bltspeed -= 10f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<NavMeshAgent>().speed += 5f;
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>().durability = 300f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>()._distance = 20f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<Guardian>()._bltspeed = 40f;
                    GameObject.FindGameObjectWithTag("Guard").GetComponent<NavMeshAgent>().speed = 20f;
                }
            }
        }
    }
}

