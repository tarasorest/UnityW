using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_2
{
    public class Enemy_3 : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _speed;
        public float durability = 150f;
        private bool buttonClick;
        private int numb;

        void Start()
        {
            _speed = 20f;
            numb = 0;
            _rotateSpeed = 4f;
            _player = FindObjectOfType<Player>();
        }

        void Update()
        {
            if (Vector3.Distance(transform.position, _player.transform.position) < 30)
            {
                numb += 1;
                if (numb % 80 == 0)
                    buttonClick = true;
            }
        }

        private void FixedUpdate()
        {
            if (buttonClick)
            {
                buttonClick = false;
                Fire();
            }
            var direction = _player.transform.position - transform.position;
            var stepRotate = Vector3.RotateTowards(transform.forward,
                direction,
                _rotateSpeed * Time.fixedDeltaTime,
                0f);
            transform.rotation = Quaternion.LookRotation(stepRotate);
            transform.position += transform.forward * _speed * Time.fixedDeltaTime;
        }
        private void Fire()
        {
            var bulletObj = Instantiate(_bulletPrefab, _spawnPosition.position, _spawnPosition.rotation);
            var bullet = bulletObj.GetComponent<Bullet>();
            bullet.Init(_player.transform, 10, 40f);
        }
        public void OnDestroy()
        {
            Destroy(gameObject);
        }
    }
}