using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMover : MonoBehaviour
{
    private Camera _mainCamera;
    private NavMeshAgent _myMeshAgent;
    private Animator _animator;    

    private void Start()
    {
        _mainCamera = Camera.main;
        _myMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if(Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                _myMeshAgent.SetDestination(hit.point);                
            }            
        }

        float speed = _myMeshAgent.velocity.magnitude;
        _animator.SetFloat("Speed", speed);
    }
}
