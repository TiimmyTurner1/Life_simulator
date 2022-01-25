using UnityEngine;

public class OpenFridgeZone : MonoBehaviour
{
    [SerializeField] private Refrigerator _refrigerator;
    
    private void OnDisable()
    {
        _refrigerator.CloseFridge();
    }
}
