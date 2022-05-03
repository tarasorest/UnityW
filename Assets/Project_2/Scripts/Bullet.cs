using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_2
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _demage = 3f;
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
            //transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
            transform.position += transform.forward * _speed * Time.fixedDeltaTime;

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Itakedemage takeDemage))
            {
                takeDemage.Hit(_demage);
                if (collision.gameObject.CompareTag("Player"))
                {
                    Destroy(gameObject);
                }

            }
        }
    }
}