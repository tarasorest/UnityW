using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_2
{
    public class Shield : MonoBehaviour,Itakedemage
    {
        [SerializeField] private float _durability = 20f;
        public void Init(float durability)
        {
            _durability = durability;
            Destroy(gameObject, 5f);
        }
        public void Hit(float demage)
        {
            _durability -= demage;
            if(_durability <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
