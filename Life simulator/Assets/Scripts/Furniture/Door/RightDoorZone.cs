using UnityEngine;

public class RightDoorZone : MonoBehaviour
{
    [SerializeField] private Door _door;

    public Door CurrentDoor => _door;
}
