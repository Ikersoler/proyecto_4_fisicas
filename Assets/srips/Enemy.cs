using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;

    private Rigidbody enemyRigidbody;

    private GameObject player;

    private float lowerLimit = -3f;

    private SpawnManager spawnManager;

    private void Awake()
    {
         enemyRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        player = GameObject.Find("player");


        spawnManager= FindObjectOfType<SpawnManager>();



    }

    private void Update()
    {
        GoToPlayer();

        if (transform.position.y < lowerLimit)
        {
            spawnManager.EnemyDestroy();
            Destroy(gameObject);
        }
    }

    private void GoToPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;

        direction = direction.normalized;

        enemyRigidbody.AddForce(direction * speed);
    }
}
