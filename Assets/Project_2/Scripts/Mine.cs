using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_2
{
    public class Mine : MonoBehaviour
    {
        [SerializeField] private GameObject i;
        [SerializeField] private GameObject _pr;
        [SerializeField] private GameObject _em;
        [SerializeField] private float _cooldown;
        private bool _isHide;
        public bool _isEnable;
        void Start()
        {
            InvokeRepeating(nameof(Move), 1f, _cooldown);
            _isEnable = true;
        }

        private void Update()
        {
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
                            if (!col.gameObject.CompareTag("floor"))
                            {
                                col.gameObject.AddComponent<Rigidbody>();
                                if(col.attachedRigidbody)
                                col.attachedRigidbody.
                                AddForce(-(_hit.point - col.transform.position) * 1000);
                                var objEnemy = _em.GetComponent<Enemy_3>();
                                objEnemy.OnDestroy();
                                if (i != null)
                                    Destroy(i);
                            }
                            else
                            {
                                if (i != null)
                                    Destroy(i);
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
                            if (!col.gameObject.CompareTag("floor"))
                            {
                                col.gameObject.AddComponent<Rigidbody>();
                                col.attachedRigidbody.AddForce(-(_hit.point - col.transform.position) * 1000);
                                if (i != null)
                                    Destroy(i);
                            }
                            else
                            {
                                if (i != null)
                                    Destroy(i);
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
                        if (!col.gameObject.CompareTag("floor") )
                        {
                            col.gameObject.AddComponent<Rigidbody>();
                            col.attachedRigidbody.AddForce(-(_hit.point - col.transform.position) * 1000);
                            if (i != null)
                                Destroy(i);
                        }
                        else
                        {

                            if (i != null)
                                Destroy(i);
                        }
                    }
                }
            }
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