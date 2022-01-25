using UnityEngine;

public class Bed : MonoBehaviour
{    
    [SerializeField] private GameObject _goToSleepZone;
    
    public void ActivateZone()
    {
        _goToSleepZone.SetActive(true);
    }

    public void DeactivateZone()
    {
        _goToSleepZone.SetActive(false);
    }
}
