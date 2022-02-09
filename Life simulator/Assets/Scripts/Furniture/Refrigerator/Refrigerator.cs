using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : MonoBehaviour
{
    [SerializeField] private GameObject _openFridgeZone;
    [SerializeField] private Animator _animator;
    [SerializeField] private Shop _shop;

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
        StartCoroutine(PlayAnimation());
        
    }

    public void CloseFridge()
    {
        _animator.Play("FridgeClose");
    }

    private IEnumerator PlayAnimation()
    {
        _animator.Play("FridgeOpen");
        yield return new WaitForSeconds(1);
        _shop.OpenShop();
    }
}
