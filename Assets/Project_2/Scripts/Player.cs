using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Project_2
{
    public class Player : MonoBehaviour,Itakedemage
    {
        public GameObject enemy;
        public GameObject shieldPrefab;
        [SerializeField] private GameObject _granadePrefab;
        [SerializeField] private float _jumpForce = 50f;
        public Transform spawnPosition;
        [SerializeField] private Rigidbody _rb;
        [HideInInspector] public int level = 1;
        [SerializeField] private float _buttonsspeedRotate;
        [SerializeField] private float _mousespeedRotate = 300f;
        public float _durability = 30f;
        private Vector3 _direction;
        private bool _isSprint;
        private bool _isGran;
        private bool _isSpawnShield;
        private float _cfSpeed = 1f;
        private float _sprint;

        public float speed = 1f;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }
        void Update()
        {

            if (Input.GetMouseButtonDown(1))
                _isSpawnShield = true;

            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
            _isSprint = Input.GetButton("Sprint");

            _sprint = (_isSprint) ? 2f : 1f;

            _direction = transform.TransformDirection(_direction);
            _rb.MovePosition(transform.position + _direction.normalized * speed * _sprint * _cfSpeed * Time.fixedDeltaTime);
            Vector3 rotate = new Vector3(0, Input.GetAxis("Mouse X") * _mousespeedRotate * Time.fixedDeltaTime, 0);
            _rb.MoveRotation(_rb.rotation * Quaternion.Euler(rotate));

            if (Input.GetKeyDown(KeyCode.G))
            {
                _isGran = true;
            }

            if (Input.GetKey(KeyCode.Space))
                GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

        }

        private void FixedUpdate()
        {
            if (_isGran)
            {
                _isGran = false;
                FireG();
            }
            if (_isSpawnShield)
            {
                _isSpawnShield = false;
                SpawnShield();
            }

            //Move(Time.fixedDeltaTime);
           
            //transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * _mousespeedRotate * Time.fixedDeltaTime, 0));
        }

        private void SpawnShield()
        {
            var shieldObj = Instantiate(shieldPrefab, spawnPosition.position, spawnPosition.rotation);
            var shield = shieldObj.GetComponent<Shield>();
            shield.Init(10 * level);

            shield.transform.SetParent(spawnPosition);
        }
        //private void Move(float delta)
        //{
        //    var fixedDirection = transform.TransformDirection(_direction.normalized);
            
        //    transform.position += fixedDirection * _sprint * delta;
        //}

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
                var objEnemy = enemy.GetComponent<Enemy_3>();
                objEnemy.OnDestroy();
            }
        }
        private void FireG()
        {
            var granObj = Instantiate(_granadePrefab, spawnPosition.position, spawnPosition.rotation);
            var gran = granObj.GetComponent<Granade>();
            gran.Init(gameObject.transform, 5f, 30f);
        }
    }
}
