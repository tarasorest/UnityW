using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_2
{

    public class Granade : MonoBehaviour
    {
        [SerializeField] private GameObject s_enem;
        [SerializeField] private GameObject s_drop;
        [SerializeField] private ParticleSystem _sparks;
        [SerializeField] private float _demage = 30f;
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
            var spark_eff = Instantiate(_sparks);
            spark_eff.transform.position = collision.contacts[0].point;

            if (collision.gameObject.CompareTag("Enemy_3")|| collision.gameObject.CompareTag("Guard"))
            {
                var sound_enem = Instantiate(s_enem);
                sound_enem.transform.position = gameObject.transform.position;
                sound_enem.GetComponent<AudioSource>().Play();
                Destroy(sound_enem,1);
            }
            else
            {
                var sound_drop = Instantiate(s_drop);
                sound_drop.transform.position = gameObject.transform.position;
                sound_drop.GetComponent<AudioSource>().Play();
                Destroy(sound_drop,1);
            }

            if (collision.transform.rotation.eulerAngles.y == 0)
            {
                var _time = spark_eff.main.duration + spark_eff.main.startLifetimeMultiplier;
                Destroy(spark_eff.gameObject, _time);
            }
            else
            {
                spark_eff.transform.rotation = collision.transform.rotation;
                var _time = spark_eff.main.duration + spark_eff.main.startLifetimeMultiplier;
                Destroy(spark_eff.gameObject, _time);
            }

            if(collision.gameObject.GetComponent<Enemy_3>())
            {
                var wer = collision.gameObject.GetComponent<Enemy_3>();
                Destroy(gameObject);
                wer.durability -= _demage;
                if(wer.durability <= 0)
                {
                    Destroy(wer.gameObject);
                }
            }else if (collision.gameObject.GetComponent<Guardian>())
            {
                var ver = collision.gameObject.GetComponent<Guardian>();
                Destroy(gameObject);
                ver.durability -= _demage;
                if (ver.durability <= 0)
                {
                    Destroy(ver.gameObject);
                }
            }
        }
    }
}