using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : MonoBehaviour
{
    [SerializeField] private GameObject _openFridgeZone;
    [SerializeField] private Animator _animator;

    public void ActivateZone()
    {
        _openFridgeZone.SetActive(true);
    }

    public void DeactivateZone()
    {
        _openFridgeZone.SetActive(false);
    }

    public void OpenFridge()
    {
        _animator.Play("FridgeOpen");
    }

    public void CloseFridge()
    {
        _animator.Play("FridgeClose");
    }
}
