using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WorkPcState", menuName = "States/WorkPcState")]
public class PcWorkState : State
{
    private Computer _computer;
    private PlayerMover _playerMover;
    private GameObject _pcPanel;
    private Vector3 _targetPcSitPosition;
    private Vector3 _lastPlayerPosition;

    private bool _isWorking;

    public override void Init()
    {
        _computer = FindObjectOfType<Computer>();
        _playerMover = FindObjectOfType<PlayerMover>();
        _pcPanel = FindObjectOfType<PcPanel>(true).gameObject;
        _lastPlayerPosition = Player.gameObject.transform.position;
        _targetPcSitPosition = FindObjectOfType<PcSitPoint>().transform.position;
        _isWorking = false;
        IsFinished = false;
    }
    public override void Run()
    {
        if (IsFinished)
        {
            return;
        }

        if (!_isWorking)
        {
            StartWorkPC();
        }
        else 
        {
            DoWorkPC();
        }

    }

    private void StartWorkPC()
    {  
        _playerMover.MakeAgentFixed();
        _isWorking = true;        
        _pcPanel.SetActive(true);
    }

    private void DoWorkPC()
    {
        Player.transform.rotation = Quaternion.Euler(-90, -90, 180);
        Player.transform.position = _targetPcSitPosition;
        
        if (_pcPanel.activeSelf == false)
        {
            Player.transform.position = _lastPlayerPosition;
            IsFinished = true;
            _computer.DeactivateZOne();
            _playerMover.MakeAgentMovable();
        } 
    }
}
