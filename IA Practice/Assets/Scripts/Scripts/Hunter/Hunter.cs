using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    [SerializeField] public Transform[] points;
    [SerializeField] Node[] _nodeArray;
    public List<Node> _nodeNewArray;
    int _current;
    public float _speed;
    public float _maxVelocity = 8;
    public float _maxForce = 5;
    FMS _fsm;
    private float _chargeSpeed = 2.5f;
    [Range(1, 15), SerializeField] private float _boidViewRadius;
    public bool _boidIsNear;
    public bool startPathFinding;
    private Player nearestBoid;
    public Vector3 boidPos;
    private Vector3 velocity;

    public Player nearstBoid { get => nearestBoid; set => nearestBoid = value; }
    public Vector3 Velocity { get => velocity; set => velocity = value; }

    private void Awake()
    {

    }

    private void Start()
    {
        _fsm = new FMS();
        _fsm.CreateState("Idle", new Idle(_fsm));
        _fsm.CreateState("Patrol", new Patrol(_fsm, transform, _speed * 2, _current, points, this));
        _fsm.CreateState("Chase", new Chase(_fsm, transform, _speed, _maxVelocity, _maxForce, this));
        _fsm.CreateState("PathFinding", new Pathfinding(_fsm, transform, _nodeArray, this, _speed * 2));



        _fsm.ChangeState("Idle");
    }

    private void Update()
    {
        _fsm.Execute();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _boidViewRadius);
    }
}
