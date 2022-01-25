using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Refrigerator _refrigerator;

    private Player _player;    

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out GoToSleepZone goToSleepZone))
        {            
            _player.SetState(_player.SleepState);
        }

        if (other.TryGetComponent(out OpenFridgeZone openFridgeZone))
        {
            _refrigerator.OpenFridge();
            //меню холодильника
        }
    }

    private void OnTriggerExit(Collider other)
    {     
        if (other.TryGetComponent(out OpenFridgeZone openFridgeZone))
        {
            _refrigerator.CloseFridge();
        }
    }
}
