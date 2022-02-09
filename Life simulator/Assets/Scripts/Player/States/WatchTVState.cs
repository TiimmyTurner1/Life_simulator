using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WatchTVState", menuName = "States/WatchTVState")]
public class WatchTVState : State
{
    private Sofa _sofa;
    private Vector3 _targetWatchTVPosition;
    private Vector3 _lastPlayerPosition;

    private Animator _animator;
    private PlayerMover _playerMover;
    private bool _isWatching;
    private float _watchTimeLeft = 20f;
    private float _leisureBarAdding = 0.00016f;

    public override void Init()
    {
        _sofa = FindObjectOfType<Sofa>();
        _animator = Player.GetComponent<Animator>();
        _playerMover = FindObjectOfType<PlayerMover>();
        _lastPlayerPosition = Player.gameObject.transform.position;
        _targetWatchTVPosition = FindObjectOfType<WatchTVPoint>().transform.position;
        _isWatching = false;
        IsFinished = false;
    }
    public override void Run()
    {
        if (IsFinished)
        {
            return;
        }

        if (!_isWatching)
        {
            StartWatchTV();
        }
        else 
        {
            DoWatchTV();
        }

    }

    private void StartWatchTV()
    {  
        _animator.SetBool("isSitting", true);
        _playerMover.IsMovable = false;
        _isWatching = true;
    }

    private void DoWatchTV()
    {
        Player.transform.rotation = Quaternion.Euler(0, -90, 0);
        Player.transform.position = _targetWatchTVPosition;
        _watchTimeLeft -= Time.deltaTime;
        Player.AddValue(_leisureBarAdding, Player.ValueType.Leisure);

        if (_watchTimeLeft <= 0 || Player.Leisure >= 1)
        {
            Player.transform.position = _lastPlayerPosition;
            IsFinished = true;
            _animator.SetBool("isSitting", false);
            _sofa.DeactivateZone();
            _playerMover.IsMovable = true;
        }        
    }
}
