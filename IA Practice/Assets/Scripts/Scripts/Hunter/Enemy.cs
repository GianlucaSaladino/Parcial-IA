using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemiesList;
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
            Debug.Log(enemy.name + " " + enemy.seePlayer);
            enemy.playerPos = playerPos;
            enemy.InLineOfSight(enemy.transform.position, playerPos);
            if (enemy.seePlayer)
            {
                enemy._hunter.boidPos = playerPos;
                enemy._hunter._boidIsNear = true;
            }
            else
            {
                Debug.Log("PathFinding " + enemy.name);
            }
        }
    }
  /// <summary>
  /// If the raycast from the start position to the end position doesn't hit anything in the maskWall
  /// layer, then return true
  /// </summary>
  /// <param name="Vector3">start - The starting position of the raycast.</param>
  /// <param name="Vector3">start - The starting position of the raycast.</param>
  /// <returns>
  /// The return value is a boolean.
  /// </returns>
    public bool InLineOfSight(Vector3 start, Vector3 end)
    {
        Vector3 dir = end - start;

        return seePlayer = !Physics.Raycast(start, dir, dir.magnitude, maskWall);
    }
}
