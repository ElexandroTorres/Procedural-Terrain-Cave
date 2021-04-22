using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CaveEntranceBehavior : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 20, other.transform.position.z);
            Debug.Log("entrou!!!");
        }
    }
}
