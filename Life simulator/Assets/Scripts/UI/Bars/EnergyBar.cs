using UnityEngine;

public class EnergyBar : Bar
{
    [SerializeField] private float _maxValue;
   
    private void Start()
    {        
        SetMaxValue(_maxValue);
    }

    private void Update()
    {
        SetValue(Player.Energy);
    }
}
