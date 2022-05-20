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
        public bool _keyen;
        [SerializeField] private GameObject _granadePrefab;
        [SerializeField] private float _jumpForce = 500f;
        public Transform spawnPosition;
        [SerializeField] private Rigidbody _rb;
        [HideInInspector] public int level = 1;
        [SerializeField] private float _buttonsspeedRotate;
        [SerializeField] private float _mousespeedRotate = 300f;
        public float _durability = 100f;
        private Vector3 _direction;
        private bool _isSprint;
        private bool _isGran;
        private bool _isSpawnShield;
        private float _cfSpeed = 1f;
        private float _sprint;
        private bool is_ground;
        [SerializeField] private Animator _anim;
        private readonly int IsWalking = Animator.StringToHash("IsWalking");
        private readonly int IsShield = Animator.StringToHash("IsShield");
        public float speed =10f;



        private void OnTriggerStay(Collider col)
        {               //если в тригере что то есть и у обьекта тег "ground"
            if (col.tag == "floor") is_ground = true;      //то включаем переменную "на земле"
        }
        private void OnTriggerExit(Collider col)
        {              //если из триггера что то вышло и у обьекта тег "ground"
            if (col.tag == "floor") is_ground = false;     //то вџключаем переменную "на земле"
        }
        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody>();
        }
        void Update()
        {

            if (Input.GetMouseButtonDown(1))
            {
                _anim.SetBool(IsShield, true);
                _isSpawnShield = true;
            }

            if(GameObject.FindWithTag("Shield"))
            {
                _anim.SetBool(IsShield, true);
            }
            else
            {
                _anim.SetBool(IsShield, false);
            }

            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
            _isSprint = Input.GetButton("Sprint");

            _sprint = (_isSprint) ? 2f : 1f;

            _direction = transform.TransformDirection(_direction);
            _rb.MovePosition(transform.position + _direction.normalized * speed * _sprint * _cfSpeed * Time.fixedDeltaTime);
            Vector3 rotate = new Vector3(0, Input.GetAxis("Mouse X") * _mousespeedRotate * Time.fixedDeltaTime, 0);
            _rb.MoveRotation(_rb.rotation * Quaternion.Euler(rotate));
            _anim.SetBool(IsWalking, _direction != Vector3.zero);

            if (Input.GetKeyDown(KeyCode.G))
            {
                _isGran = true;
            }

            if (Input.GetKey(KeyCode.Space) && is_ground)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }


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
                _anim.SetBool(IsShield, true);
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
                if (enemy != null)
                {
                    var objEnemy = enemy.GetComponent<Enemy_3>();
                    objEnemy.OnDestroy();
                }
            }
        }
        private void FireG()
        {
            var granObj = Instantiate(_granadePrefab, spawnPosition.position, spawnPosition.rotation);
            var gran = granObj.GetComponent<Granade>();
            gran.Init(gameObject.transform, 5f, 15f);
        }
    }
}
