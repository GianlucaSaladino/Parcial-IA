using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : IState
{
    Transform _transform;
    float _speed;
    float _maxVelocity;
    float _maxForce;
    Vector3 _velocity;
    FMS _fsm;
    boid _nearestBoid;

    public Chase(FMS fsm, Transform transform, float speed, float maxVelocity, float maxForce)
    {
        _fsm = fsm;
        _transform = transform;
        _speed = speed;
        _maxVelocity = maxVelocity;
        _maxForce = maxForce;
    }

    public void OnEnter()
    {
        Debug.Log("ENTER ESTADO PERSEGUIR");
        _nearestBoid = Hunter.instance.nearstBoid;
    }

    public void OnUpdate()
    {

        if (!Hunter.instance._boidIsNear)
        {
            _fsm.ChangeState("Patrol");
        }
        _transform.position += _velocity * Time.deltaTime;
        Move(Pursuit(_nearestBoid));
    }

 

    Vector3 Pursuit(boid target)
    {
        Vector3 finalPos = target.transform.position + target.Velocity * Time.deltaTime;
        Vector3 desired = finalPos - _transform.position;
        desired.Normalize();
        desired *= _maxVelocity;

        Vector3 steering = desired - _velocity;

        return steering;
    }

    void Move(Vector3 force)
    {
        _velocity = Vector3.ClampMagnitude(_velocity + force, _maxForce);
        Hunter.instance.Velocity = _velocity;
    }

    public void OnExit()
    {
        Debug.Log("EXIT ESTADO PERSEGUIR");
    }
}
