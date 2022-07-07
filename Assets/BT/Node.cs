using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : ScriptableObject
{
    public enum State
    {
        Running,
        Failure,
        Success
    }

    public bool started = false;
    public State state = State.Running;

    protected abstract void OnStart();
    protected abstract void OnStop();
    protected abstract State OnUpdate();
   

    public State Update()
    {
        if (started == false)
        {
            OnStart();
            started = true;
        }

        state = OnUpdate();

        if (state == State.Failure || state == State.Success)
        {
            OnStop();
            started = false;
        }
        return state;
    }
    
}
