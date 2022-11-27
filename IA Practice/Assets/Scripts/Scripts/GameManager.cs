using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public LayerMask maskWall;
    public Pathfinding pathfinding;
    public Player player;
    Node _startingNode;
    Node _goalNode;

    void Awake()
    {
        instance = this;
    }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         StartCoroutine(pathfinding.CoroutineCalculateThetaStar(_startingNode, _goalNode));
    //         //player.SetPath(pathfinding.CalculateBFS(_startingNode, _goalNode));
    //     }
    // }

    public void SetStartingNode(Node node)
    {
        if (_startingNode != null)
            ChangeColorNode(_startingNode, Color.white);

        _startingNode = node;
        ChangeColorNode(_startingNode, Color.red);
        player.transform.position = _startingNode.transform.position;
    }

    public void SetGoalNode(Node node)
    {
        if (_goalNode != null)
            ChangeColorNode(_goalNode, Color.white);

        _goalNode = node;
        ChangeColorNode(_goalNode, Color.green);
    }

    public void ChangeColorNode(Node node, Color color)
    {
        node.GetComponent<Renderer>().material.color = color;
    }




}