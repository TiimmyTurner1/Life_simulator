using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorOpener : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out LeftDoorZone leftDoorZone))
        {
            leftDoorZone.CurrentDoor.OpenRight();
        }
        else if (other.TryGetComponent(out RightDoorZone rightDoorZone))
        {
            rightDoorZone.CurrentDoor.OpenLeft();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ExitTriggerZone exitTriggerZone))
        {
            exitTriggerZone.CurrentDoor.Close();
        }        
    }
}
