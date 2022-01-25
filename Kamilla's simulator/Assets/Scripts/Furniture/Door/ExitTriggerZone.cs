using UnityEngine;

public class ExitTriggerZone : MonoBehaviour
{
    [SerializeField] private Door _door;

    public Door CurrentDoor => _door;
}
