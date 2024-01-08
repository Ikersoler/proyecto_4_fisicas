using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float speed = 30f;
    private float forwardInput;

    [SerializeField] private GameObject focalPointGameObject;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        //se para cuando dejas de pulsar
        /*
        if (Mathf.Abs(forwardInput) < 0.01f) 
        {
            playerRigidbody.velocity = Vector3.zero;
        }
        */



        forwardInput = Input.GetAxis("Vertical");
        playerRigidbody.AddForce(focalPointGameObject.transform.forward * speed * forwardInput);
    }
}
