using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_2
{
    public class Granade : MonoBehaviour
    {
        [SerializeField] private float _demage = 15f;
        private Transform _target;
        private float _speed;
        public void Init(Transform target, float lifeTime, float speed)
        {
            _speed = speed;
            _target = target;
            Destroy(gameObject, lifeTime);
        }
        void FixedUpdate()
        {
            transform.position += transform.forward * _speed * Time.fixedDeltaTime;

        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.GetComponent<Enemy_3>())
            {
                var wer = collision.gameObject.GetComponent<Enemy_3>();
                Destroy(gameObject);
                wer.durability -= _demage;
                if(wer.durability <= 0)
                {
                    Destroy(wer.gameObject);
                }
            }
        }
    }
}