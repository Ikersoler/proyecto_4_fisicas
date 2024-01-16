using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float speed = 30f;
    private float forwardInput;

    [SerializeField] private GameObject focalPointGameObject;

    public bool hasPowerup;
    [SerializeField] private float powerupForce = 10f;

    [SerializeField] private GameObject[] powerupIndicators;

    private int lives;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        hasPowerup = false;
        lives = 3;
        
    }

    

    private void Start()
    {
        HideAllINdicators();
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = other.gameObject.
                 GetComponent<Rigidbody>();

            Vector3 direction = (other.transform.position -
                                 transform.position).normalized;

            enemyRigidbody.AddForce(direction * powerupForce,
                ForceMode.Impulse);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("powerup"))
        {
            hasPowerup = true;
            StartCoroutine(PowerupCountdown());
            Destroy(other.gameObject);
        }
    }

    private IEnumerator PowerupCountdown()
    {
       
        //ejercicio bucle con tres iteraciones que dunciones (debug.lo provisional)
        for(int i = 0; i < powerupIndicators.Length; i++)
        {
            powerupIndicators[i].SetActive(true);
           
            yield return new WaitForSeconds(2);

            powerupIndicators[i].SetActive(false);

            
        }

        hasPowerup = false;
    }

    
    private void HideAllINdicators()
    {
        foreach (GameObject indicator in powerupIndicators)
        {
            indicator.SetActive(false);
        }
    }











    //crear uns scrip para los indicadores para que siga al player


   






}
