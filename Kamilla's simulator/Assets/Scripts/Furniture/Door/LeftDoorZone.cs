using UnityEngine;

public class LeftDoorZone : MonoBehaviour
{
    [SerializeField] private Door _door;

    public Door CurrentDoor => _door;
}
