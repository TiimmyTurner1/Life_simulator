using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : MonoBehaviour
{
    [SerializeField] private GameObject _goShowerZone;
    
    public void ActivateZone()
    {
        _goShowerZone.SetActive(true);
    }

    public void DeactivateZone()
    {
        _goShowerZone.SetActive(false);
    }
}
