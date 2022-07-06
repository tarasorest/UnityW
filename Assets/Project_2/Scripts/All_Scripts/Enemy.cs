using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_2
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private GameObject _Enemy; 
        [SerializeField] private Player _player;
        [SerializeField] private Transform _spawnPosition;
        private bool _isEnemy;
        
        void Start()
        {
            _player = FindObjectOfType<Player>();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _isEnemy = true;
            }
        }
        private void FixedUpdate()
        {
            if (_isEnemy)
            {
                _isEnemy = false;
                SpawnEnemy();
            }
        } 
        private void SpawnEnemy()
        {
                var enemyObj = Instantiate(_Enemy, transform.position, transform.rotation);
                var enemy = enemyObj.GetComponent<Enemy>();
                Destroy(enemyObj, 3f);
        }

    }
}
