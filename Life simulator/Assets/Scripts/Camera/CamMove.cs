using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamMove : MonoBehaviour
{
    [SerializeField] private Transform _bedroomPosition;
    [SerializeField] private Transform _kitchenPosition;
    [SerializeField] private Transform _bathroomPosition;
    [SerializeField] private Transform _gameroomPosition;

    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent(typeof(KitchenZone)))
        {
            SetTranform(_kitchenPosition);
        }
        else if (other.GetComponent(typeof(BathroomZone)))
        {
            SetTranform(_bathroomPosition);
        }
        else if (other.GetComponent(typeof(GameroomZone)))
        {
            SetTranform(_gameroomPosition);
        }
        else if (other.GetComponent(typeof(BedroomZone)))
        {
            SetTranform(_bedroomPosition);
        }
    }
    
    private void SetTranform(Transform room)
    {
        _mainCamera.transform.DOMove(room.position, 1);
    }
}
