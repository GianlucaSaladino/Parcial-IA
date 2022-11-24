using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    List<Node> _path = new List<Node>();

    void Update()
    {
        if(_path.Count > 0)
        {
            var dir = _path[0].transform.position - transform.position;

            transform.position += dir.normalized * speed * Time.deltaTime;

            if (dir.magnitude <= 0.5f)
                _path.RemoveAt(0);
        }
    }

    public void SetPath(List<Node> newPath)
    {
        _path.Clear();

        foreach (var p in newPath)
            _path.Add(p);
    }
}