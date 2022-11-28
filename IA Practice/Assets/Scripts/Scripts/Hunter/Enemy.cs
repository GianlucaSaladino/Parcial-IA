using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemiesList;
    [SerializeField] private Node[] _nodeArray;
    public Vector3 playerPos;
    [SerializeField] LayerMask maskWall;
    public Hunter _hunter;
    public bool seePlayer;

    void Start()
    {
        _hunter = GetComponent<Hunter>();

    }

    void Update()
    {
    }

    public void SendPlayerPos(Vector3 playerPos)
    {
        foreach (var enemy in _enemiesList)
        {
            enemy.playerPos = playerPos;
            enemy.InLineOfSight(enemy.transform.position, playerPos);
            if (enemy.seePlayer)
            {

                Debug.Log(enemy.name + "Persiguiendo");
                enemy._hunter.boidPos = playerPos;
                enemy._hunter._boidIsNear = true;

            }
            else
            {
                Debug.Log("PathFinding " + enemy.name);
                enemy._hunter.boidPos = playerPos;
                enemy._hunter.startPathFinding = true;


            }
        }
    }

    public bool InLineOfSight(Vector3 start, Vector3 end)
    {
        Vector3 dir = end - start;

        return seePlayer = !Physics.Raycast(start, dir, dir.magnitude, maskWall);
    }
}
