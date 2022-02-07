using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WorkPcState", menuName = "States/WorkPcState")]
public class PcWorkState : State
{
    private Animator _animator;
    private Computer _computer;
    private PlayerMover _playerMover;
    private GameObject _pcPanel;
    private Vector3 _targetPcSitPosition;
    private Vector3 _lastPlayerPosition;

    private bool _isWorking;

    public override void Init()
    {
        _computer = FindObjectOfType<Computer>();
        _animator = Player.GetComponent<Animator>();
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
        _animator.SetBool("isSitting", true);
        _playerMover.IsMovable = false;
        _isWorking = true;        
        _pcPanel.SetActive(true);
    }

    private void DoWorkPC()
    {
        Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        Player.transform.position = _targetPcSitPosition;
        
        if (_pcPanel.activeSelf == false)
        {
            Player.transform.position = _lastPlayerPosition;
            IsFinished = true;
            _computer.DeactivateZOne();
            _playerMover.MakeAgentMovable();
            _animator.SetBool("isSitting", false);
            _playerMover.IsMovable = true;
        } 
    }
}
