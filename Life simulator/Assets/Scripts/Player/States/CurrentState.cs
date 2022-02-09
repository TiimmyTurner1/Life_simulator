using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrentState", menuName = "States/CurrentState")]
public class CurrentState : State
{
    public override void Run()
    {
        IsFinished = true;
    }
}
