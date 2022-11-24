using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : IState
{
    Transform[] _points;
    Transform _transform; 
    float _speed;
    FMS _fsm;
    int _current = 1;
    int _last = 0;
    public float minDetectPoint = 0.5f;

    public float viewRadius = 5;


    public Patrol(FMS fsm,Transform transform , float speed, int current, Transform[] points )
    {
        _points = points;
        _fsm = fsm;
        _transform = transform;
        _current = current;
        _speed = speed;
    }
    

    public void OnEnter()
    {
        //Debug.Log("EMPECE A PATRULLAR");
    }

    public void OnUpdate()
    {

        PointPatrol();

        if (Hunter.instance._boidIsNear)
        {
            _fsm.ChangeState("Chase");
        }

        // if (Hunter.instance.Energy <= 0)
        // {
        //     _fsm.ChangeState("Idle");
        // }

        // Debug.Log("current" + _current);
        // Debug.Log("last" + _last);
    }

    public void OnExit()
    {
        //Debug.Log("DEJE DE PATRULLAR");
    }

    private void PointPatrol()
    {
        var dir = _points[_current].position - _transform.position;
        _transform.position += dir.normalized * _speed * Time.deltaTime;
        //Hunter.instance.DecreaseEnergy();

        if (dir.magnitude <= minDetectPoint)
        {
            _current++;

            if (_current > _last)
            {
                _last = _current - 1;
            }
            else
            {
                _current--;
                _last = _current + 1;                   
            }

            if (_current >= _points.Length)
            {
                _current = 0;
                _last = _points.Length - 1;
            }
            else if (_current == 0)
            {
                _current = 1;
                _last = 0;
            }
        }
    }    

}
