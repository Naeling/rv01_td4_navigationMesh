using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDetector : MonoBehaviour {

    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("SUCCESS");
            gameManager.IncrementScore();
            gameManager.SwitchInitialPosition();
        }
    }
}
