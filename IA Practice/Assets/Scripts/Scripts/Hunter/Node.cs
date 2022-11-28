using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Node : MonoBehaviour
{

    [SerializeField] public List<Node> neighbors = new List<Node>();
    public bool blocked;

    int _cost;

    public int Cost { get { return _cost; } }
}