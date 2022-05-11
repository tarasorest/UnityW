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
        public float durability = 300f;
        private int numb;
        private bool uhit;

        void Start()
        {
            _player = FindObjectOfType<Player>();
            uhit = false;
        }

        private void Update()
        {
            Ray ray = new Ray(_spawnPosition.position, transform.forward);
            Debug.DrawRay(_spawnPosition.position, transform.forward * 50, Color.red);
            if (Physics.Raycast(ray, out RaycastHit hit,50))
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
                        if (numb % 30 == 0)
                            Fire();

                    }
                    else if (!hit.collider.CompareTag("Player")&&uhit&& Vector3.Distance(transform.position, _player.transform.position) > 15)
                    {
                        uhit = false;
                        StartCoroutine(pause());
                    }
                    else if (!hit.collider.CompareTag("Player") && uhit&& Vector3.Distance(transform.position, _player.transform.position) <= 15)
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
            bullet.Init(_player.transform, 10, 70f);
        }
        public void OnDestroy()
        {
            Destroy(gameObject);
        }
    }
}