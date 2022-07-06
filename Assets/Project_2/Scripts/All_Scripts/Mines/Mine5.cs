using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_2
{
    public class Mine5 : MonoBehaviour
    {
        [SerializeField] private GameObject i;
        [SerializeField] private GameObject _pr;
        [SerializeField] private GameObject _em;
        [SerializeField] private float _cooldown;
        [SerializeField] private GameObject _expl_sound;
        [SerializeField] private ParticleSystem _sparks_1;
        [SerializeField] private ParticleSystem _sparks_2;
        private bool _isHide;
        public bool _isEnable;
        void Start()
        {
            InvokeRepeating(nameof(Move), 1f, _cooldown);
            _isEnable = true;
        }

        private void Update()
        {
            _expl_sound = GameObject.FindWithTag("mine_5");
            if (_em != null && _pr != null && _isEnable == true)
            {
                if (Vector3.Distance(_pr.transform.position, transform.position) <= 5 || Vector3.Distance(_em.transform.position, transform.position) <= 5)
                {
                    Ray ray = new Ray(transform.position, transform.position);
                    RaycastHit _hit;
                    if (Physics.Raycast(ray, out _hit, Mathf.Infinity))
                    {

                        Collider[] _col = Physics.OverlapSphere(_hit.point, 40);
                        foreach (var col in _col)
                        {
                            if (!col.gameObject.CompareTag("floor") && !col.gameObject.CompareTag("Mine") && !col.gameObject.CompareTag("Mine") && !col.gameObject.CompareTag("Zone"))
                            {
                                col.gameObject.AddComponent<Rigidbody>();
                                if(col.attachedRigidbody)
                                col.attachedRigidbody.
                                AddForce(-(_hit.point - col.transform.position) * 1000);
                                var objEnemy = _em.GetComponent<Enemy_3>();
                                objEnemy.OnDestroy();
                                if (i != null)
                                {
                                    particle();
                                    Destroy(i);
                                }
                            }
                            else
                            {
                                if (i != null)
                                {
                                    particle();
                                    Destroy(i);
                                }
                            }
                        }
                    }
                }
            }
            if (_em == null && _pr != null && _isEnable == true)
            {
                if (Vector3.Distance(_pr.transform.position, transform.position) <= 5)
                {
                    Ray ray = new Ray(transform.position, transform.position);
                    RaycastHit _hit;
                    if (Physics.Raycast(ray, out _hit, Mathf.Infinity))
                    {
                        Collider[] _col = Physics.OverlapSphere(_hit.point, 40);
                        foreach (var col in _col)
                        {
                            if (!col.gameObject.CompareTag("floor") && !col.gameObject.CompareTag("Mine")&& !col.gameObject.CompareTag("Zone"))
                            {
                                col.gameObject.AddComponent<Rigidbody>();
                                col.attachedRigidbody.AddForce(-(_hit.point - col.transform.position) * 1000);
                                if (i != null)
                                {
                                    particle();
                                    Destroy(i);
                                }
                            }
                            else
                            {
                                if (i != null)
                                {
                                    particle();
                                    Destroy(i);
                                }
                            }
                        }
                    }
                }
            }
            else if (_em == null && _pr == null && _isEnable == true)
            {
                    Ray ray = new Ray(transform.position, transform.position);
                    RaycastHit _hit;
                    if (Physics.Raycast(ray, out _hit, Mathf.Infinity))
                    {
                        Collider[] _col = Physics.OverlapSphere(_hit.point, 40);
                    foreach (var col in _col)
                    {
                        if (!col.gameObject.CompareTag("floor") && !col.gameObject.CompareTag("Mine")&& !col.gameObject.CompareTag("Zone"))
                        {
                            col.gameObject.AddComponent<Rigidbody>();
                            col.attachedRigidbody.AddForce(-(_hit.point - col.transform.position) * 1000);
                            if (i != null)
                            {
                                particle();
                                Destroy(i);
                            }
                        }
                        else
                        {

                            if (i != null)
                            {
                                particle();
                                Destroy(i);
                            }
                        }
                    }
                }
            }
        }

        private void particle()
        {
            var spark_eff_1 = Instantiate(_sparks_1);
            spark_eff_1.transform.position = gameObject.transform.position;
            var _time_1 = spark_eff_1.main.duration + spark_eff_1.main.startLifetimeMultiplier;
            Destroy(spark_eff_1.gameObject, _time_1);
            if(_expl_sound != null)
            _expl_sound.GetComponent<AudioSource>().Play();
            var spark_eff_2 = Instantiate(_sparks_2);
            spark_eff_2.transform.position = gameObject.transform.position;
            var _time_2 = spark_eff_2.main.duration + spark_eff_1.main.startLifetimeMultiplier;
            Destroy(spark_eff_1.gameObject, _time_2);
        }
        private void Move()
        {
            if (_isHide)
            {
                transform.position = new Vector3(transform.position.x,1, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, -1, transform.position.z);
            }

            _isHide = !_isHide;
        }

    }
}