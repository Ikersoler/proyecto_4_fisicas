using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private float Horizontalimput;


    void Update()
    {
        Horizontalimput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, speed * Time.deltaTime * Horizontalimput);
    }
}
