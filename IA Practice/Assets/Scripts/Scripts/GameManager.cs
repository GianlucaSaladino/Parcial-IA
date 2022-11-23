using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    float _width = 15;
    [SerializeField]
    float _height = 9;
    float _timeToSpawn = 2.5f;
    float _currentTime;
    public boid[] boids;

    public GameObject food;

    [Range(0, 3)]
    public float weightSeparation = 1;
    [Range(0, 3)]
    public float weightCohesion = 1;
    [Range(0, 3)]
    public float weightAlignment = 1;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        _currentTime = _timeToSpawn;
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0)
        {
            //SpawnFood();
            _currentTime = _timeToSpawn;
        }
    }
    public Vector3 ApplyBound(Vector3 objectPosition)
    {
        if (objectPosition.x > _width)
            objectPosition.x = -_width;
        if (objectPosition.x < -_width)
            objectPosition.x = _width;

        if (objectPosition.z > _height)
            objectPosition.z = -_height;
        if (objectPosition.z < -_height)
            objectPosition.z = _height;

        return objectPosition;
    }

    //void SpawnFood()
    //{
    //    float x = Random.Range(-_width, _width);
    //    float z = Random.Range(-_height, _height);
    //
    //    Vector3 spawnPos = new Vector3(x, 0, z);
    //    Instantiate(food, spawnPos, Quaternion.identity);
    //}
        private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 topLeft = new Vector3(-_width, 0, _height);
        Vector3 topRight = new Vector3(_width, 0, _height);
        Vector3 botRight = new Vector3(_width, 0, -_height);
        Vector3 botLeft = new Vector3(-_width, 0, -_height);


        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, botRight);
        Gizmos.DrawLine(botRight, botLeft);
        Gizmos.DrawLine(botLeft, topLeft);

    }
}
