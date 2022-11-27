// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PathFinding : MonoBehaviour
// {

//     public List<Node> CalculateDijkstra(Node startingNode, Node goalNode)
//     {
//         PriorityQueue<Node> frontier = new PriorityQueue<Node>();
//         frontier.Enqueue(startingNode, 0);

//         Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
//         cameFrom.Add(startingNode, null);

//         Dictionary<Node, int> costSoFar = new Dictionary<Node, int>();
//         costSoFar.Add(startingNode, 0);

//         while (frontier.Count > 0)
//         {
//             Node current = frontier.Dequeue();

//             if (current == goalNode)
//             {
//                 List<Node> path = new List<Node>();

//                 while (current != startingNode)
//                 {
//                     path.Add(current);
//                     current = cameFrom[current];
//                 }

//                 path.Reverse();
//                 return path;
//             }

//             foreach (var next in current.GetNeighbors())
//             {
//                 if (next.blocked)
//                     continue;

//                 int newCost = costSoFar[current] + next.Cost;

//                 if (!costSoFar.ContainsKey(next))
//                 {
//                     frontier.Enqueue(next, newCost);
//                     cameFrom.Add(next, current);
//                     costSoFar.Add(next, newCost);
//                 }
//                 else if (costSoFar[next] > newCost)
//                 {
//                     frontier.Enqueue(next, newCost);
//                     cameFrom[next] = current;
//                     costSoFar[next] = newCost;
//                 }

//             }
//         }

//         return new List<Node>();
//     }

//     public List<Node> CalculateAStar(Node startingNode, Node goalNode)
//     {
//         PriorityQueue<Node> frontier = new PriorityQueue<Node>();
//         frontier.Enqueue(startingNode, 0);

//         Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
//         cameFrom.Add(startingNode, null);

//         Dictionary<Node, int> costSoFar = new Dictionary<Node, int>();
//         costSoFar.Add(startingNode, 0);

//         while (frontier.Count > 0)
//         {
//             Node current = frontier.Dequeue();

//             if (current == goalNode)
//             {
//                 List<Node> path = new List<Node>();

//                 while (current != startingNode)
//                 {
//                     path.Add(current);
//                     current = cameFrom[current];
//                 }

//                 path.Reverse();
//                 return path;
//             }

//             foreach (var next in current.GetNeighbors())
//             {
//                 if (next.blocked)
//                     continue;

//                 int newCost = costSoFar[current] + next.Cost;
//                 float priority = newCost + Vector3.Distance(next.transform.position, goalNode.transform.position);

//                 if (!costSoFar.ContainsKey(next))
//                 {
//                     frontier.Enqueue(next, priority);
//                     cameFrom.Add(next, current);
//                     costSoFar.Add(next, newCost);
//                 }
//                 else if (costSoFar[next] > newCost)
//                 {
//                     frontier.Enqueue(next, priority);
//                     cameFrom[next] = current;
//                     costSoFar[next] = newCost;
//                 }

//             }
//         }

//         return new List<Node>();
//     }

//     public List<Node> CalculateBFS(Node startingNode, Node goalNode)
//     {
//         Queue<Node> frontier = new Queue<Node>();
//         frontier.Enqueue(startingNode);

//         Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
//         cameFrom.Add(startingNode, null);      

//         while (frontier.Count > 0)
//         {
//             Node current = frontier.Dequeue();

//             if (current == goalNode)
//             {
//                 List<Node> path = new List<Node>();

//                 while (current != startingNode)
//                 {
//                     path.Add(current);
//                     current = cameFrom[current];
//                 }

//                 path.Reverse();
//                 return path;
//             }

//             foreach (var next in current.GetNeighbors())
//             {
//                 if (!next.blocked && !cameFrom.ContainsKey(next))
//                 {
//                     frontier.Enqueue(next);
//                     cameFrom.Add(next, current);
//                 }
//             }
//         }

//         return new List<Node>();
//     }

//     public IEnumerator CoroutineCalculateGreedyBFS(Node startingNode, Node goalNode)
//     {
//         PriorityQueue<Node> frontier = new PriorityQueue<Node>();
//         frontier.Enqueue(startingNode, 0);

//         Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
//         cameFrom.Add(startingNode, null);

//         while (frontier.Count > 0)
//         {
//             Node current = frontier.Dequeue();

//             yield return new WaitForSeconds(0.1f);
//             GameManager.instance.ChangeColorNode(current, Color.blue);

//             if (current == goalNode)
//             {
//                 while (current != startingNode)
//                 {
//                     yield return new WaitForSeconds(0.1f);
//                     GameManager.instance.ChangeColorNode(current, Color.yellow);

//                     //path.Add(current);
//                     current = cameFrom[current];
//                 }

//                 break;
//             }

//             foreach (var next in current.GetNeighbors())
//             {
//                 if (!next.blocked && !cameFrom.ContainsKey(next))
//                 {
//                     float priority = Vector3.Distance(next.transform.position, goalNode.transform.position);
//                     frontier.Enqueue(next, priority);
//                     cameFrom.Add(next, current);
//                 }
//             }
//         }

//     }

//     public IEnumerator CoroutineCalculateBFS(Node startingNode, Node goalNode)
//     {
//         Queue<Node> frontier = new Queue<Node>();
//         frontier.Enqueue(startingNode);

//         Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
//         cameFrom.Add(startingNode, null);

//         while (frontier.Count > 0)
//         {
//             Node current = frontier.Dequeue();

//             yield return new WaitForSeconds(0.1f);
//             GameManager.instance.ChangeColorNode(current, Color.blue);

//             if (current == goalNode)
//             {
//                 while (current != startingNode)
//                 {
//                     yield return new WaitForSeconds(0.1f);
//                     GameManager.instance.ChangeColorNode(current, Color.yellow);

//                     //path.Add(current);
//                     current = cameFrom[current];
//                 }

//                 break;
//             }

//             foreach (var next in current.GetNeighbors())
//             {
//                 if (!next.blocked && !cameFrom.ContainsKey(next))
//                 {
//                     frontier.Enqueue(next);
//                     cameFrom.Add(next, current);
//                 }
//             }
//         }

//     }

//     public IEnumerator CoroutineCalculateDijkstra(Node startingNode, Node goalNode)
//     {
//         PriorityQueue<Node> frontier = new PriorityQueue<Node>();
//         frontier.Enqueue(startingNode, 0);

//         Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
//         cameFrom.Add(startingNode, null);

//         Dictionary<Node, int> costSoFar = new Dictionary<Node, int>();
//         costSoFar.Add(startingNode, 0);

//         while (frontier.Count > 0)
//         {
//             Node current = frontier.Dequeue();

//             if (current == goalNode)
//             {
//                 List<Node> path = new List<Node>();

//                 while (current != startingNode)
//                 {
//                     path.Add(current);
//                     current = cameFrom[current];

//                     yield return new WaitForSeconds(0.1f);
//                     GameManager.instance.ChangeColorNode(current, Color.yellow);
//                 }

                
//                 break;
//             }

//             foreach (var next in current.GetNeighbors())
//             {
//                 if (next.blocked)
//                     continue;

//                 int newCost = costSoFar[current] + next.Cost;

//                 if (!costSoFar.ContainsKey(next))
//                 {
//                     frontier.Enqueue(next, newCost);
//                     cameFrom.Add(next, current);
//                     costSoFar.Add(next, newCost);
//                 }
//                 else if (costSoFar[next] > newCost)
//                 {
//                     frontier.Enqueue(next, newCost);
//                     cameFrom[next] = current;
//                     costSoFar[next] = newCost;
//                 }

//                 yield return new WaitForSeconds(0.02f);
//                 GameManager.instance.ChangeColorNode(current, Color.blue);
//             }
//         }
//     }

//     public IEnumerator CoroutineCalculateAStar(Node startingNode, Node goalNode)
//     {
//         PriorityQueue<Node> frontier = new PriorityQueue<Node>();
//         frontier.Enqueue(startingNode, 0);

//         Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
//         cameFrom.Add(startingNode, null);

//         Dictionary<Node, int> costSoFar = new Dictionary<Node, int>();
//         costSoFar.Add(startingNode, 0);

//         while (frontier.Count > 0)
//         {
//             Node current = frontier.Dequeue();

//             if (current == goalNode)
//             {
//                 List<Node> path = new List<Node>();

//                 while (current != startingNode)
//                 {
//                     path.Add(current);
//                     current = cameFrom[current];

//                     yield return new WaitForSeconds(0.1f);
//                     GameManager.instance.ChangeColorNode(current, Color.yellow);
//                 }


//                 break;
//             }

//             foreach (var next in current.GetNeighbors())
//             {
//                 if (next.blocked)
//                     continue;

//                 int newCost = costSoFar[current] + next.Cost;
//                 float priority = newCost + Vector3.Distance(next.transform.position, goalNode.transform.position);

//                 if (!costSoFar.ContainsKey(next))
//                 {
//                     frontier.Enqueue(next, priority);
//                     cameFrom.Add(next, current);
//                     costSoFar.Add(next, newCost);
//                 }
//                 else if (costSoFar[next] > newCost)
//                 {
//                     frontier.Enqueue(next, priority);
//                     cameFrom[next] = current;
//                     costSoFar[next] = newCost;
//                 }

//                 yield return new WaitForSeconds(0.02f);
//                 GameManager.instance.ChangeColorNode(current, Color.blue);
//             }
//         }
//     }

//     public IEnumerator CoroutineCalculateThetaStar(Node startingNode, Node goalNode)
//     {
//         var listNodes = CalculateAStar(startingNode, goalNode);

//         foreach (var item in listNodes)
//         {
//             GameManager.instance.ChangeColorNode(item, Color.blue);
//         }

//         int current = 0;

//         while (current + 2 < listNodes.Count)
//         {
//             GameManager.instance.ChangeColorNode(listNodes[current], Color.red);
//             GameManager.instance.ChangeColorNode(listNodes[current + 2], Color.green);

//             yield return new WaitForSeconds(1);

//             // if (GameManager.instance.InLineOfSight(listNodes[current].transform.position, listNodes[current + 2].transform.position))
//             // {
//             //     GameManager.instance.ChangeColorNode(listNodes[current + 1], Color.white);
//             //     listNodes.RemoveAt(current + 1);
//             // }
//             // else
//             //     current++;
//         }


//     }


// }