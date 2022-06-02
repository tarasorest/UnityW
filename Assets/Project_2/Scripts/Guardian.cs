using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Project_2
{
    public class Guardian : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private GameObject _compl;
        public float durability;
        private int numb;
        private bool uhit;
        public float _distance;
        public float _bltspeed;


        void Start()
        {
            _player = FindObjectOfType<Player>();
            uhit = false;
        }

        private void Update()
        {
            if (_compl.GetComponent<NewBehaviourScript>().num == 0)
            {
                durability = 500f;
                _distance = 30f;
                _bltspeed = 30f;
                gameObject.GetComponent<NavMeshAgent>().speed = 25f;
            }
            else if (_compl.GetComponent<NewBehaviourScript>().num == 1)
            {
                durability = 400f;
                _distance = 25f;
                _bltspeed = 25f;
                gameObject.GetComponent<NavMeshAgent>().speed = 20f;
            }
            else if (_compl.GetComponent<NewBehaviourScript>().num == 2)
            {
                durability = 300f;
                _distance = 20f;
                _bltspeed = 20f;
                gameObject.GetComponent<NavMeshAgent>().speed = 15f;
            }

            Ray ray = new Ray(_spawnPosition.position, transform.forward);
            Debug.DrawRay(_spawnPosition.position, transform.forward * 70, Color.red);
            if (Physics.Raycast(ray, out RaycastHit hit,70))
            {
                Debug.DrawRay(_spawnPosition.position, transform.forward * hit.distance, Color.red);
                if (_player != null)
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        uhit = true;
                        gameObject.GetComponent<WayPointScript>().enabled = false;
                        gameObject.GetComponent<WayScript>().enabled = true;
                        numb += 1;
                        if (numb % 2 == 0)
                            Fire();

                    }
                    else if (!hit.collider.CompareTag("Player")&&uhit&& Vector3.Distance(transform.position, _player.transform.position) > _distance)
                    {
                        uhit = false;
                        StartCoroutine(pause());
                    }
                    else if (!hit.collider.CompareTag("Player") && uhit&& Vector3.Distance(transform.position, _player.transform.position) <= _distance)
                    {
                        uhit = false;
                        gameObject.GetComponent<WayPointScript>().enabled = false;
                        gameObject.GetComponent<WayScript>().enabled = true;
                    }
                }
            }
        }
        private IEnumerator pause()
        {
            gameObject.GetComponent<WayScript>().enabled = false;
            yield return new WaitForSeconds(5);
            gameObject.GetComponent<WayPointScript>().enabled = true;
        }
        private void Fire()
        {
            var bulletObj = Instantiate(_bulletPrefab, _spawnPosition.position, _spawnPosition.rotation);
            var bullet = bulletObj.GetComponent<Bullet>();
            bullet.Init(_player.transform, 10, _bltspeed);
        }
        public void OnDestroy()
        {
            Destroy(gameObject);
        }
    }
}