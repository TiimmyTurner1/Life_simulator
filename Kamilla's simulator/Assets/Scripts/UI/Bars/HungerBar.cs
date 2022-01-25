using UnityEngine;

public class HungerBar : Bar
{
    [SerializeField] private float _maxValue;    

    private void Start()
    {        
        SetMaxValue(_maxValue);
    }

    private void Update()
    {
        SetValue(Player.Hunger);
    }
}
