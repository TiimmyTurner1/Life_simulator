using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SleepState", menuName = "States/SleepState")]

public class SleepState : State
{
    private Bed _bed;
    private Vector3 _targetSleepPosition;
    private Vector3 _lastPlayerPosition;

    private bool _isSleeping;
    private float _sleepTimeLeft = 20f;
    private float _sleepBarAdding = 0.00008f;

    public override void Init()
    {
        _bed = FindObjectOfType<Bed>();
        _lastPlayerPosition = Player.gameObject.transform.position;
        _targetSleepPosition = FindObjectOfType<SleepPoint>().transform.position;
        _isSleeping = false;
        IsFinished = false;
    }
    public override void Run()
    {
        if (IsFinished)
        {
            return;
        }

        if (!_isSleeping)
        {
            StartSleep();
        }
        else 
        {
            DoSleep();
        }

    }

    void StartSleep()
    {        
        //анимация лечь в кровать
        _isSleeping = true;        
    }

    void DoSleep()
    {
        Player.transform.rotation = Quaternion.Euler(-90, -90, 180);
        Player.transform.position = _targetSleepPosition;
        _sleepTimeLeft -= Time.deltaTime;
        Player.AddEnergyValue(_sleepBarAdding);

        if (_sleepTimeLeft > 0 && Player.Energy < 1)
        {
            return;
        }    
        else 
        {
            //анимация встать с кровати
            Player.transform.position = _lastPlayerPosition;
            IsFinished = true;
            _bed.DeactivateZone();
        }        
    }
}
