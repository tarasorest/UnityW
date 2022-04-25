using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Project_2
{
    public class Player : MonoBehaviour,Itakedemage
    {
        public GameObject shieldPrefab;

        public Transform spawnPosition;
        private bool _isSpawnShield;
        [HideInInspector] public int level = 1;
        [SerializeField] private float _buttonsspeedRotate;
        [SerializeField] private float _mousespeedRotate;
        public float _durability = 30f;
        private Vector3 _direction;
        private bool _isSprint;
        private int numb = 0;

        public float speed = 5f;

        void Update()
        {

            if (Input.GetMouseButtonDown(1))
                _isSpawnShield = true;

            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
            _isSprint = Input.GetButton("Sprint");
        }

        private void FixedUpdate()
        {
            if (_isSpawnShield)
            {
                _isSpawnShield = false;
                SpawnShield();
            }

            Move(Time.fixedDeltaTime);
            
            transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * _buttonsspeedRotate * Time.fixedDeltaTime, 0));
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * _mousespeedRotate * Time.fixedDeltaTime, 0));
        }

        private void SpawnShield()
        {
            var shieldObj = Instantiate(shieldPrefab, spawnPosition.position, spawnPosition.rotation);
            var shield = shieldObj.GetComponent<Shield>();
            shield.Init(10 * level);

            shield.transform.SetParent(spawnPosition);
        }
        private void Move(float delta)
        {
            var fixedDirection = transform.TransformDirection(_direction.normalized);
            
            transform.position += fixedDirection * (_isSprint ? speed * 2 : speed) * delta;
        }

        public void Init(float durability)
        {
            _durability = durability;
            Destroy(gameObject, 5f);
        }
        public void Hit(float demage)
        {
            _durability -= demage;
            if (_durability <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
