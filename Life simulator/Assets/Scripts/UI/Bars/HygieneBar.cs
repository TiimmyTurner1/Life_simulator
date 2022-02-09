using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HygieneBar : Bar
{
    [SerializeField] private float _maxValue;    

    private void Start()
    {        
        SetMaxValue(_maxValue);
    }

    private void Update()
    {
        SetValue(Player.Hygiene);
    }
}
