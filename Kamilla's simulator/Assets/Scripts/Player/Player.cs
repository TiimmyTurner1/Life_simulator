using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent),typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _money;

    [SerializeField] private float _energy;
    [SerializeField] private float _hunger;
    [SerializeField] private float _leisure;
    [SerializeField] private float _hygiene;

    [SerializeField] private float _hungerLifeTime;
    [SerializeField] private float _energyLifeTime;
    [SerializeField] private float _leisureLifeTime;
    [SerializeField] private float _hygieneLifeTime;

    [SerializeField] private LayerMask _whatCanBeClickOn;

    [SerializeField] private State _sleepState;
    [SerializeField] private State _watchTVState;
    [SerializeField] private State _workPCState;
    [SerializeField] private State _showerState;
    [SerializeField] private State _emptyState;
    [SerializeField] private State _currentState;

    private Camera _mainCamera;

    public int Money => _money;
    public float Energy => _energy;
    public float Hunger => _hunger;
    public float Leisure => _leisure;
    public float Hygiene => _hygiene;

    public State SleepState => _sleepState;
    public State WatchTVState => _watchTVState;
    public State WorkPcState => _workPCState;
    public State ShowerState => _showerState;

    public event UnityAction<int> MoneyChanged;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        CountLifeValues();
        MoneyChanged?.Invoke(Money);


        Ray Ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(Ray, out hit, 100, _whatCanBeClickOn);

        if (!_currentState.IsFinished)        
            _currentState.Run();        
        else
        {     
            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.TryGetComponent(out Bed bed))
            {                
                bed.ActivateZone();
            }
            else if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.TryGetComponent(out Refrigerator refrigerator))
            {
                refrigerator.ActivateZone();
            }
            else if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.TryGetComponent(out Sofa sofa))
            {
                sofa.ActivateZone();
            }
            else if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.TryGetComponent(out Computer computer))
            {
                computer.ActivateZone();
            }
            else if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.TryGetComponent(out Shower shower))
            {
                shower.ActivateZone();
            }
            else if (Input.GetMouseButtonDown(0))
            {
                SetState(_emptyState);
                DeactivateAllActiveZones();
            }
        }
    }

    public void SetState(State state)
    {
        _currentState = Instantiate(state);
        _currentState.Player = this;
        _currentState.Init();
    }

    private void CountLifeValues()
    {
        _hunger -= Time.deltaTime / _hungerLifeTime;
        _energy -= Time.deltaTime / _energyLifeTime;
        _leisure -= Time.deltaTime / _leisureLifeTime;
        _hygiene -= Time.deltaTime / _hygieneLifeTime;
    }

    private void DeactivateAllActiveZones()
    {
        GameObject[] zones = GameObject.FindGameObjectsWithTag("Zone");

        foreach (var zone in zones)
        {
            zone.SetActive(false);
        }
    }

    public void AddValue(float value, ValueType valueType)
    {
        switch (valueType)
        {
            case ValueType.Energy:
                _energy += value;
                break;
            
            case ValueType.Hunger:
                float hungerValue = value / 100;
                
                if (_hunger + hungerValue > 1)
                    _hunger = 1;
                else
                    _hunger += value/100;
                break;
            
            case  ValueType.Leisure:
                _leisure += value;
                break;
            
            case ValueType.Hygiene:
                _hygiene += value;
                break;
        }
    }

    public void AddMoney(int money)
    {
        _money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void BuyFood(FoodItem item)
    {
        _money -= item.Price;        
        MoneyChanged?.Invoke(Money);
    }
    
    public enum ValueType
    {
        Energy,
        Leisure,
        Hygiene,
        Hunger
    }
}
