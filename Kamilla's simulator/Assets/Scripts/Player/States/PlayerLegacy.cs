using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


public class PlayerLegacy : MonoBehaviour
{
    public float Energy = 1f;
    public float Eat = 1f;
    public LayerMask whatCanBeClickOn;

    public State SleepState;
    public State EatState;
    public State EmptyState;
    public State CurrentState;

    private float eatLifeTime = 150f;
    private float energyLifeTime = 200f;
    
    private NavMeshAgent _myAgent;
    private Animator _animator;   

    private void Start()
    {
        _animator = GetComponent<Animator>();        
        _myAgent = GetComponent<NavMeshAgent>();
    }

    
    private void Update()
    {
        Eat -= Time.deltaTime / eatLifeTime;
        Energy -= Time.deltaTime / energyLifeTime;
        
        Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(Ray, out hit, 100, whatCanBeClickOn);

        if (!CurrentState.IsFinished)
        {
            CurrentState.Run();
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.tag == "Bed")
            {
                Vector3 target = GameObject.Find("pointToSleep").transform.position;
                MoveToBed(target);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                SetState(EmptyState);
                MoveTo(hit.point);
            }

            float speed = _myAgent.velocity.magnitude;
            _animator.SetFloat("Speed", speed);
        }        
    }

    public void SetState(State state)
    {
        CurrentState = Instantiate(state);        
        CurrentState.Init();
    }

    public void MoveTo(Vector3 hit)
    {
        _myAgent.SetDestination(hit);
    }

    public void MoveToBed(Vector3 positionToSleep)
    {
        MoveTo(positionToSleep);

        if (gameObject.transform.position.x == positionToSleep.x && gameObject.transform.position.z == positionToSleep.z)
        {            
            SetState(SleepState);            
        }
    }
}

