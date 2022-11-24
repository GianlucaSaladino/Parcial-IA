using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boid : MonoBehaviour
{
    Vector3 _velocity;
    public Vector3 Velocity { get => _velocity; set => _velocity = value; }

}
//     [SerializeField, Range(1, 15)] int _maxSpeed;
//     [SerializeField, Range(1, 15)] int _maxForce;
//     public float maxSpeed;
//     public float viewRadius = 5;
//     public float viewFoodRadius = 5;
//     public float radiusSeparation = 5;
//     public float hunterViewRaidus = 4;

//     [SerializeField] LayerMask _foodMask;
//     [SerializeField] LayerMask _hunterMask;

//     bool _isFoodNear;
//     [SerializeField] bool _isHunterNear;



//     void Start()
//     {
//         Vector3 randomDir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized * maxSpeed;
//         AddForce(randomDir);
//     }

//     void Update()
//     {
//         AddForce(Separation() * GameManager.instance.weightSeparation);
//         AddForce(Cohesion() * GameManager.instance.weightCohesion);
//         AddForce(Alignment() * GameManager.instance.weightAlignment);

//         transform.position += _velocity * Time.deltaTime;
//         transform.forward = _velocity;

//         var nearFood = Physics.OverlapSphere(transform.position, viewFoodRadius, _foodMask);
//         var nearHunter = Physics.OverlapSphere(transform.position, hunterViewRaidus, _hunterMask);

//         transform.position = GameManager.instance.ApplyBound(transform.position);

//         foreach(var item in nearFood)
//         {
//             if (!_isHunterNear)
//             {
//                 AddForce(Arrive(item.transform.position));
//             }
//             if ((item.transform.position - transform.position).magnitude < 1)
//             {
//                 Destroy(item.gameObject);
//             }

//         }
//          if (nearHunter.Length > 0)
//          {
//              _isHunterNear = true;
//          }
//          else
//          {
//              _isHunterNear = false;
//          }
//         if (_isHunterNear)
//         {
//             AddForce(Evade(nearHunter[0].GetComponent<Hunter>()));
//         }

//     }

//     Vector3 Alignment()
//     {
//         Vector3 desired = Vector3.zero;
//         int count = 0;
//         foreach (var item in GameManager.instance.boids)
//         {
//             if (item == this)
//                 continue;

//             Vector3 dist = item.transform.position - transform.position;

//             if (dist.magnitude <= viewRadius)
//             {
//                 desired += item._velocity;
//                 count++;
//             }
//         }

//         if (count <= 1)
//             return desired;

//         desired /= count;

//         desired.Normalize();
//         desired *= maxSpeed;

//         return desired;
//     }

//     Vector3 Cohesion()
//     {
//         Vector3 desired = Vector3.zero;
//         int count = 0;

//         foreach (var item in GameManager.instance.boids)
//         {
//             if (item == this)
//                 continue;

//             Vector3 dist = item.transform.position - transform.position;

//             if (dist.magnitude <= viewRadius)
//             {
//                 desired += item.transform.position;
//                 count++;
//             }
//         }

//         if (count <= 1)
//             return desired;

//         desired /= count;
//         desired -= transform.position;

//         desired.Normalize();
//         desired *= maxSpeed;

//         return desired;
//     }

//     Vector3 Arrive(Vector3 actualTarget)
//     {
//         Vector3 desired = actualTarget - transform.position;
//         float dist = desired.magnitude;
//         desired.Normalize();
//         if (dist <= viewFoodRadius)
//         {
//             desired *= _maxSpeed * (dist / viewFoodRadius);
//         }
//         else
//         {
//             desired *= _maxSpeed;
//         }

//         Vector3 steering = desired - _velocity;

//         return steering;
//     }

//     Vector3 Separation()
//     {
//         Vector3 desired = Vector3.zero;

//         foreach (var item in GameManager.instance.boids)
//         {
//             Vector3 dist = item.transform.position - transform.position;

//             if (dist.magnitude <= radiusSeparation)
//                 desired += dist;
//         }

//         if (desired == Vector3.zero)
//             return desired;

//         desired = -desired;

//         desired.Normalize();
//         desired *= maxSpeed;

//         return desired;
//     }

//     Vector3 Evade(Hunter target)
//     {
//         Vector3 finalPos = target.transform.position + target.Velocity * Time.deltaTime;
//         Vector3 desired = transform.position - finalPos;
//         desired.Normalize();
//         desired *= _maxForce;

//         Vector3 steering = desired - _velocity;

//         return steering;
//     }


//     void AddForce(Vector3 force)
//     {
//         _velocity = Vector3.ClampMagnitude(_velocity + force, maxSpeed);
//     }

//     private void OnDrawGizmos()
//     {
//         Gizmos.DrawWireSphere(transform.position, viewRadius);

//         Gizmos.color = Color.red;
//         Gizmos.DrawWireSphere(transform.position, radiusSeparation);

//         Gizmos.color = Color.blue;
//         Gizmos.DrawWireSphere(transform.position, viewFoodRadius);

//         Gizmos.color = Color.green;
//         Gizmos.DrawWireSphere(transform.position, hunterViewRaidus);
//     }

// }
