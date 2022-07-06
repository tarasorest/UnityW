using Project_2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{
    public float _healthInd;

    private void Awake()
    {
        
        gameObject.GetComponent<Slider>().minValue = 0f;
        gameObject.GetComponent<Slider>().maxValue = 50f;
        _healthInd = 50f;
    }
    void Update()
    {
        gameObject.GetComponent<Slider>().value = _healthInd;
    }
}
