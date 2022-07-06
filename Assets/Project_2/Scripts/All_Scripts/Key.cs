using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_2
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private GameObject _playr;
        [SerializeField] private GameObject _keyicon;
        public bool keyenabled;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                keyenabled = true;
                _playr.GetComponent<Player>()._keyen = keyenabled;
                _keyicon.active = true;
                Destroy(gameObject);
            }
            else
            {
                if (gameObject != null&&_playr!=null)
                {
                    keyenabled = false;
                    _playr.GetComponent<Player>()._keyen = keyenabled;
                }
            }
        }
    }
}
