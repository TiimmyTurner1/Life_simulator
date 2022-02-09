using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sofa : MonoBehaviour
{
    [SerializeField] private GameObject _goWatchTVZone;
    
    public void ActivateZone()
    {
        _goWatchTVZone.SetActive(true);
    }

    public void DeactivateZone()
    {
        _goWatchTVZone.SetActive(false);
    }
}
