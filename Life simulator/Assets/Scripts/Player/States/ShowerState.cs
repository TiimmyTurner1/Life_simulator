using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ShowerState", menuName = "States/ShowerState")]
public class ShowerState : State

{
    private PlayerMover _playerMover;
    private Shower _shower;
    private ShowerParticle _particleShower;
    private Vector3 _targetShowerPosition;
    private Vector3 _lastPlayerPosition;

    private bool _isWashing;
    private float _showerTimeLeft = 20f;
    private float _hygieneBarAdding = 0.00010f;

    public override void Init()
    {
        _playerMover = FindObjectOfType<PlayerMover>();
        _shower = FindObjectOfType<Shower>();
        _particleShower = FindObjectOfType<ShowerParticle>();
        _particleShower.GetComponent<ParticleSystem>().Play(true);
        _lastPlayerPosition = Player.gameObject.transform.position;
        _targetShowerPosition = FindObjectOfType<ShowerPoint>().transform.position;
        _isWashing = false;
        IsFinished = false;
    }
    public override void Run()
    {
        if (IsFinished)
        {
            return;
        }

        if (!_isWashing)
        {
            StartShower();
        }
        else 
        {
            DoShower();
        }

    }

    private void StartShower()
    {  
        _isWashing = true;
        _playerMover.IsMovable = false;
    }

    private void DoShower()
    {
        Player.transform.position = _targetShowerPosition;
        _showerTimeLeft -= Time.deltaTime;
        Player.AddValue(_hygieneBarAdding, Player.ValueType.Hygiene);

        if (_showerTimeLeft <= 0 || Player.Hygiene >= 1)
        {
            Player.transform.position = _lastPlayerPosition;
            IsFinished = true;
            _particleShower.GetComponent<ParticleSystem>().Stop(true);
            _shower.DeactivateZone();
            _playerMover.IsMovable = true;
        }
    }
}
