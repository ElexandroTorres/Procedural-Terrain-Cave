using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CaveEntranceBehavior : MonoBehaviour
{
    public GameObject caveProvisorio;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entrou na caverna!!!");
        }
    }
}
