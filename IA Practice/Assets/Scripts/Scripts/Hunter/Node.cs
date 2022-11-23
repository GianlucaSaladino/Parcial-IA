using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Node : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    List<Node> _neighbors = new List<Node>();
    public bool blocked;
    Grid _grid;
    int _x;
    int _y;
    int _cost;

    public int Cost { get { return _cost; } }
    public void Initialize(Grid grid, int x, int y)
    {
        _grid = grid;
        _x = x;
        _y = y;

        SetCost(1);
    }

    public List<Node> GetNeighbors()
    {
        if (_neighbors.Count > 0)
            return _neighbors;

        Node current = _grid.GetNode(_x, _y + 1); //UP
        if (current != null)
            _neighbors.Add(current);

        current = _grid.GetNode(_x + 1, _y); //RIGHT
        if (current != null)
            _neighbors.Add(current);

        current = _grid.GetNode(_x, _y - 1); //DOWN
        if (current != null)
            _neighbors.Add(current);

        current = _grid.GetNode(_x - 1, _y); //LEFT
        if (current != null)
            _neighbors.Add(current);

        return _neighbors;
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
            GameManager.instance.SetGoalNode(this);
        else if (Input.GetMouseButtonDown(2))
        {
            blocked = !blocked;
            Color color = blocked ? Color.gray : Color.white;

            if (blocked)
                gameObject.layer = 6;
            else
                gameObject.layer = 0;

            GameManager.instance.ChangeColorNode(this, color);
        }
        else if(Input.GetMouseButton(0))
            GameManager.instance.SetStartingNode(this);

        if (Input.GetKey(KeyCode.UpArrow))
            SetCost(_cost + 1);

        if (Input.GetKey(KeyCode.DownArrow))
            SetCost(_cost - 1);

        if (Input.GetKeyDown(KeyCode.R))
            SetCost(1);

    }

    public void SetCost(int cost)
    {
        _cost = Mathf.Clamp(cost, 1, 99);
        textMesh.text = _cost.ToString();
    }
}
