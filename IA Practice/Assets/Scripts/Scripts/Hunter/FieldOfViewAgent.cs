using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewAgent : MonoBehaviour
{
    public Transform target;
    public float viewRadius;
    public float viewAngle;
    private Enemy _enemy;

    private void Start() {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {

        if (InFOV(target))
        {
            Debug.Log("LO VEO" + transform.name);
            //_enemy._hunter._boidIsNear = true;
           // _enemy._hunter.boidPos = target.position;
            _enemy.SendPlayerPos(target.position);
        }
        else
        {
            _enemy._hunter.boidPos = Vector3.zero;
            _enemy._hunter._boidIsNear = false;
        }

    }

    bool InFOV(Transform obj)
    {
        Vector3 dir = obj.position - transform.position;
        var viewRadiusSqr = viewRadius*viewRadius;
        if (dir.sqrMagnitude < viewRadiusSqr)
        {
            if (Vector3.Angle(transform.forward, dir) <= viewAngle / 2)
            {
                return _enemy.InLineOfSight(transform.position, obj.position);
            }
        }
        
        return false;       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Vector3 lineA = GetVectorFromAngle(viewAngle / 2 + transform.eulerAngles.y);
        Vector3 lineB = GetVectorFromAngle(-viewAngle / 2 + transform.eulerAngles.y);

        Gizmos.DrawLine(transform.position, transform.position + lineA * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + lineB * viewRadius);
    }

    Vector3 GetVectorFromAngle(float angle)
    {
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }

    
}