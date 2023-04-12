using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] private Material _redLight;
    [SerializeField] private Material _greenLight;
    [SerializeField] private int _lampNumber = 0;
    private void OnEnable()
    {
        Escape.OnLampColorChange += ChangeColor;
    }
    private void OnDisable()
    {
        Escape.OnLampColorChange -= ChangeColor;
    }

    private void Start()
    {
        ChangeColor(_lampNumber);
    }


    private void ChangeColor(int lampNumber, bool unlock = false)
    {
        if (lampNumber == _lampNumber)
        {
            if (unlock)
            {
                GetComponent<MeshRenderer>().material = _greenLight;
            }
            else
            {
                GetComponent<MeshRenderer>().material = _redLight;
            }
        }
    }
}
