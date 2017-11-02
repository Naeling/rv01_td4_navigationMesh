using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Contact with a trigger");
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
