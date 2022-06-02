using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject _complex;
    public int num;
    void Update()
    {
       if(_complex.GetComponent<TMP_Dropdown>().value == 0)
        {
            gameObject.GetComponent<TMP_Text>().text = "HARD";
            num = 0;

        }else if (_complex.GetComponent<TMP_Dropdown>().value == 1)
        {
            gameObject.GetComponent<TMP_Text>().text = "MEDIUM";
            num = 1;
        }
        else
        {
            gameObject.GetComponent<TMP_Text>().text = "EASY";
            num = 2;
        }
    }

}
