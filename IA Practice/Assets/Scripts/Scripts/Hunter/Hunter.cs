using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    [SerializeField] Transform[] points;
    int _current;
    public float _speed;
    public float _maxVelocity = 8;
    public float _maxForce = 5;
    FMS _fsm;
    private float _chargeSpeed = 2.5f;
    [Range(1, 15), SerializeField] private float _boidViewRadius;
    public bool _boidIsNear;
    private Player nearestBoid;
    public Vector3 boidPos;
    private Vector3 velocity;
    [SerializeField] private float energy;
    [SerializeField] LayerMask _boidMask;
    public static Hunter instance;

    public float   Energy { get => energy; set => energy = value; }
    public Player nearstBoid { get => nearestBoid; set => nearestBoid = value; }
    public Vector3 Velocity { get => velocity; set => velocity = value; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _fsm = new FMS();
        _fsm.CreateState("Idle", new Idle(_fsm));
        _fsm.CreateState("Patrol", new Patrol(_fsm, transform, _speed * 2, _current, points));
        _fsm.CreateState("Chase", new Chase(_fsm, transform, _speed,_maxVelocity,_maxForce));

        _fsm.ChangeState("Idle");
    }

    private void Update()
    {
        _fsm.Execute();
        // var _NearBoid = Physics.OverlapSphere(transform.position, _boidViewRadius, _boidMask);
        // if (_NearBoid.Length>0)
        // {
        //     _boidIsNear = _NearBoid[0];
        //     nearestBoid = _NearBoid[0].GetComponent<boid>();
        // }
        // else
        // {
        //     _boidIsNear = false;
        // }
    }

    // public void ChargeEnergy()
    // {
    //     if (energy < 10)
    //     {
    //         energy += Time.deltaTime * _chargeSpeed;
    //     }
    // }
    //public void DecreaseEnergy()
    //{
    // energy -= Time.deltaTime;
    //}
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _boidViewRadius);
    }
}
