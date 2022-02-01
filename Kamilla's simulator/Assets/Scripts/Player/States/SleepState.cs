using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SleepState", menuName = "States/SleepState")]

public class SleepState : State
{
    private Bed _bed;
    private BedParticle _particleBed;
    private Vector3 _targetSleepPosition;
    private Vector3 _lastPlayerPosition;

    private bool _isSleeping;
    private float _sleepTimeLeft = 20f;
    private float _sleepBarAdding = 0.00008f;

    public override void Init()
    {
        _bed = FindObjectOfType<Bed>();
        _particleBed = FindObjectOfType<BedParticle>();
        _particleBed.GetComponent<ParticleSystem>().Play(true);
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

    private void StartSleep()
    {  
        _isSleeping = true;        
    }

    private void DoSleep()
    {
        Player.transform.rotation = Quaternion.Euler(-90, -90, 180);
        Player.transform.position = _targetSleepPosition;
        _sleepTimeLeft -= Time.deltaTime;
        Player.AddValue(_sleepBarAdding, Player.ValueType.Energy);

        if (_sleepTimeLeft <= 0 || Player.Energy >= 1)
        {
            Player.transform.position = _lastPlayerPosition;
            IsFinished = true;
            _particleBed.GetComponent<ParticleSystem>().Stop();
            _bed.DeactivateZone();
        }        
    }
}
