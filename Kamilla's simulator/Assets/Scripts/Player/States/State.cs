using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class State : ScriptableObject
{
    public bool IsFinished { get; protected set; }

    [HideInInspector] public Player Player;

    public virtual void Init() { }

    public abstract void Run();
}
    
