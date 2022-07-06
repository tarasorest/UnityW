using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Project_2
{
    public class Enemy_3 : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private GameObject _compl;
        [SerializeField] private GameObject _source;
        public float _speed;
        public float _bulspeed;
        public float durability;
        private bool buttonClick;
        private int numb;



        void Start()
        {
            numb = 0;
            _rotateSpeed = 15f;
            _player = FindObjectOfType<Player>();
            durability = 0;
            _speed = 0;
            _bulspeed = 0;
        }

        void Update()
        {
            _source = GameObject.FindWithTag("garg_shot");
            if (_compl.GetComponent<NewBehaviourScript>().num == 0)
            {
                if (durability == 0 && _speed == 0 && _bulspeed == 0)
                {
                    durability = 350f;
                    _speed = 150f;
                    _bulspeed = 160f;
                }
            }
            else if (_compl.GetComponent<NewBehaviourScript>().num == 1)
            {
                if (durability == 0 && _speed == 0 && _bulspeed == 0)
                {
                    durability = 250f;
                    _speed = 100f;
                    _bulspeed = 140f;
                }
            }
            else if (_compl.GetComponent<NewBehaviourScript>().num == 2)
            {
                if (durability == 0 && _speed == 0 && _bulspeed == 0)
                {
                    durability = 150f;
                    _speed = 50f;
                    _bulspeed = 120f;
                }
            }
            if (Vector3.Distance(transform.position, _player.transform.position) < 20)
            {
                numb += 1;
                if (numb % 40 == 0)
                    buttonClick = true;
            }
        }

        private void FixedUpdate()
        {
            if (buttonClick)
            {
                buttonClick = false;
                Fire();
                if(_source != null)
                _source.GetComponent<AudioSource>().Play();
            }
            gameObject.GetComponent<WayScript>().enabled = true;
        }
        private void Fire()
        {
            var bulletObj = Instantiate(_bulletPrefab, _spawnPosition.position, _spawnPosition.rotation);
            var bullet = bulletObj.GetComponent<Bullet>();
            bullet.Init(_player.transform, 10, _bulspeed);
        }
        public void OnDestroy()
        {
            Destroy(gameObject);
        }
    }
}