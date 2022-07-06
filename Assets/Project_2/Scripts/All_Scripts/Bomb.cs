using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_2
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _sparks;
        [SerializeField] private GameObject enemy;
        [SerializeField] private GameObject _expl_sound;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy_3"))
            {
                _expl_sound = GameObject.FindWithTag("bomb_explosion");
                var spark_eff = Instantiate(_sparks);
                spark_eff.transform.position = gameObject.transform.position;
                var _time = spark_eff.main.duration + spark_eff.main.startLifetimeMultiplier;
                Destroy(spark_eff.gameObject, _time);
                _expl_sound.GetComponent<AudioSource>().Play();
                var objEnemy = enemy.GetComponent<Enemy_3>();
                objEnemy.OnDestroy();
                Destroy(enemy);
                Destroy(gameObject);
            }
        }
    }
}
