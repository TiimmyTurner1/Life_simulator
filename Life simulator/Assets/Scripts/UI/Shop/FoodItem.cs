using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _energyValue;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public int EnergyValue => _energyValue;
}
