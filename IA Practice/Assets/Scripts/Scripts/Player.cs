using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    float _movHor;
    float _movVer;
    Vector3 dir;
    [SerializeField] Rigidbody _rb;


    private void Update()
    {
        _movHor = Input.GetAxis("Horizontal");
        _movVer = Input.GetAxis("Vertical");
        dir.x = _movHor;
        dir.z = _movVer;
    }

    private void FixedUpdate() {
        _rb.velocity = dir*speed;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Goal")){
            Debug.Log("Termino");
            UnityEditor.EditorApplication.ExitPlaymode();
        }
    }

}