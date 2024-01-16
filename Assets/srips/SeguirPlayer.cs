using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransfom;


    private void LateUpdate()
    {
        transform.position = playerTransfom.position;
    }

}
