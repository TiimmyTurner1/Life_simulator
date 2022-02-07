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
    private bool _isFixed;
    
    public bool IsMovable { get; set; }

    private void Start()
    {
        _mainCamera = Camera.main;
        _myMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _isFixed = false;
        IsMovable = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isFixed == false)
        {
            RaycastHit hit;

            if(Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                _myMeshAgent.SetDestination(hit.point);                
            }            
        }

        if (IsMovable == false)
        {
            _animator.SetFloat("Speed", 0);

        }
        else
        {
            float speed = _myMeshAgent.velocity.magnitude;
            _animator.SetFloat("Speed", speed);
        }
    }

    public void MakeAgentFixed()
    {
        _isFixed = true;
    }
    
    public void MakeAgentMovable()
    {
        _isFixed = false;
    }
}
