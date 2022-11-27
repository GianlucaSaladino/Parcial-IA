using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    float _movHor;
    float _movVer;
    Vector3 dir;


    private void Update()
    {
        _movHor = Input.GetAxis("Horizontal");
        _movVer = Input.GetAxis("Vertical");
        dir.x = _movHor;
        dir.z = _movVer;

        transform.Translate(dir*speed*Time.deltaTime);
        

    }

}