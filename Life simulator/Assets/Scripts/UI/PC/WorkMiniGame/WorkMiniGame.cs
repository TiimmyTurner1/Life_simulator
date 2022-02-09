using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class WorkMiniGame : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _payMoneyPerUnit;
    [SerializeField] private int _takeMoneyPerUnit;
    [SerializeField] private GameObject[] _docs;
    [SerializeField] private Transform _instPoint;

    private void Start()
    {
        InstDoc();
    }

    private void InstDoc()
    {
        Random random = new Random();
        GameObject currentDoc = _docs[random.Next(0, 3)];
        Instantiate(currentDoc, _instPoint);
    }

    public void PayMoney()
    {
        _player.AddMoney(_payMoneyPerUnit);
        InstDoc();
    }

    public void TakeMoney()
    {
        _player.AddMoney(-1 * _takeMoneyPerUnit);
        InstDoc();
    }
    
    public enum ItemsColor
    {
        Red,
        Blue,
        Yellow
    }
}
