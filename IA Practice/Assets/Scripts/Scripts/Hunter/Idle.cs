using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : IState
{
    FMS _fsm;

    public Idle(FMS fsm)
    {
        _fsm = fsm;
    }

    public void OnEnter()
    {
        Debug.Log("EMPEZO IDLE");
    }

    public void OnUpdate()
    {
        _fsm.ChangeState("Patrol");
    }

    public void OnExit()
    {

    }
}
