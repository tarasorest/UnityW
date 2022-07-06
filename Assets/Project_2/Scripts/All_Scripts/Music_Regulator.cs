using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project_2;

public class Music_Regulator : MonoBehaviour
{
    [SerializeField] Player _plr;
    public float num;

    private void Awake()
    {
        num = 1;
        GetComponent<AudioSource>().pitch = num;
    }
    void Update()
    {
        _plr = FindObjectOfType<Player>();
        if (_plr != null)
        {
            if (_plr._durability <= 30 && _plr._durability > 16)
            {
                if (GetComponent<AudioSource>().pitch <= 1.2)
                {
                    num = (float)(num + 0.002);
                    GetComponent<AudioSource>().pitch = num;
                }
            }
            else if (_plr._durability <= 15)
            {
                if (GetComponent<AudioSource>().pitch <= 1.3)
                {
                    num = (float)(num + 0.002);
                    GetComponent<AudioSource>().pitch = num;
                }
            }
            if (_plr._durability > 25)
            {
                if (GetComponent<AudioSource>().pitch > 1)
                {
                    num = (float)(num - 0.002);
                    GetComponent<AudioSource>().pitch = num;
                }
            }
        }
        else
        {
            if (GetComponent<AudioSource>().pitch > 1)
            {
                num = (float)(num - 0.002);
                GetComponent<AudioSource>().pitch = num;
            }
        }
    }
}
