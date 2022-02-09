using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    [SerializeField] private GameObject _goPcZone;

    public void ActivateZone()
    {
        _goPcZone.SetActive(true);
    }

    public void DeactivateZOne()
    {
        _goPcZone.SetActive(true);
    }
}
