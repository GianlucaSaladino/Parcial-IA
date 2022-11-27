using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : IState
{
    [SerializeField] private Node[] _nodeArray;
    [SerializeField] private bool _startPathFinding;
    FMS _fsm;
    Transform _transform;
    Hunter _hunter;
    float _speed;
    float minDetectPoint = 0.1f;
    int _current = 0;
    int _last = -1;
    public Pathfinding(FMS fsm, Transform transform, Node[] nodeArray, Hunter hunter, float speed)
    {
        _fsm = fsm;
        _transform = transform;
        _nodeArray = nodeArray;
        _hunter = hunter;
        _speed = speed;

        // _speed = speed;
        // _maxVelocity = maxVelocity;
        // _maxForce = maxForce;
    }


    public void OnEnter()
    {
        Debug.Log("Entre al PathFinding " + _transform.name);

        _hunter._nodeNewArray = CalculateAStar(GetClosestEnemy(_nodeArray, _transform.position), GetClosestEnemy(_nodeArray, _hunter.boidPos));
    }

    public void OnUpdate()
    {
        Debug.Log("Updating PathFinding " + _transform.name);
        Debug.Log(GetClosestEnemy(_nodeArray, _transform.position).name);
        MovePath(_hunter._nodeNewArray);

        Debug.Log("Voy al nodo: " + _current);

    }

    public void OnExit()
    {

    }
    void MovePath(List<Node> _points)
    {

        var dir = _points[_current].transform.position - _transform.position;
        _transform.forward = dir;
        _transform.position += dir.normalized * _speed * Time.deltaTime;
        //Hunter.instance.DecreaseEnergy();

        if (dir.magnitude <= minDetectPoint)
        {

            if (_current > _last)
            {

                _last = _current - 1;
            }
            // else
            // {
            //     _current--;
            //     _last = _current + 1;
            // }

            if (_current >= _points.Count - 1)
            {
                _current = 0;
                _last = -1;
                Debug.Log("Quedarese quieto");
                _hunter.startPathFinding = false;
                dir = Vector3.zero;
                if(!_hunter._boidIsNear){
                    _hunter._nodeNewArray = CalculateAStar(GetClosestEnemy(_nodeArray, _transform.position), GetClosestEnemy(_nodeArray, _hunter.points[0].position));
                    //_hunter._nodeNewArray.Reverse();
                    if( (_hunter.points[0].position - _transform.position).magnitude <= minDetectPoint  )
                        _fsm.ChangeState("Patrol");

                }
                else{
                    _fsm.ChangeState("Chase");
                }
                //_fsm.ChangeState("Patrol");
                return;
            }
            // else if (_current == 0)
            // {
            //     _current = 1;
            //     _last = 0;
            // }
            if (_current < _points.Count - 1)
                _current++;
            else
                return;
        }

    }

    public Node GetClosestEnemy(Node[] nodes, Vector3 pos)
    {
        Node bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = pos;
        foreach (Node potentialTarget in nodes)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }



    public List<Node> CalculateAStar(Node startingNode, Node goalNode)
    {
        PriorityQueue<Node> frontier = new PriorityQueue<Node>();
        frontier.Enqueue(startingNode, 0);

        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
        cameFrom.Add(startingNode, null);

        Dictionary<Node, int> costSoFar = new Dictionary<Node, int>();
        costSoFar.Add(startingNode, 0);

        while (frontier.Count > 0)
        {
            Node current = frontier.Dequeue();

            if (current == goalNode)
            {
                List<Node> path = new List<Node>();

                while (current != startingNode)
                {
                    path.Add(current);
                    current = cameFrom[current];
                }

                path.Reverse();
                return path;
            }

            foreach (var next in current.neighbors)
            {
                if (next.blocked)
                    continue;

                int newCost = costSoFar[current] + next.Cost;
                float priority = newCost + Vector3.Distance(next.transform.position, goalNode.transform.position);

                if (!costSoFar.ContainsKey(next))
                {
                    frontier.Enqueue(next, priority);
                    cameFrom.Add(next, current);
                    costSoFar.Add(next, newCost);
                }
                else if (costSoFar[next] > newCost)
                {
                    frontier.Enqueue(next, priority);
                    cameFrom[next] = current;
                    costSoFar[next] = newCost;
                }

            }
        }

        return new List<Node>();
    }

}
