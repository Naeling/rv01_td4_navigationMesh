using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform initialPosition1;
    public Transform initialPosition2;
    public GameObject player;

    public Collider targetZoneCollider1;
    public Collider targetZoneCollider2;

    private int score = 0;
    private Transform currentInitialPosition;

    public ScoreText scoreText;

    private void Start()
    {
        currentInitialPosition = initialPosition1;    
    }

    public void IncrementScore()
    {
        Debug.Log("score PLUS");
        scoreText.UpdateScore(++score);
    }

    public void DecrementScore()
    {
        Debug.Log("score MINUS");
        scoreText.UpdateScore(--score);
    }

    public void SwitchInitialPosition()
    {
        if (currentInitialPosition == initialPosition1)
        {
            currentInitialPosition = initialPosition2;
            targetZoneCollider1.enabled = false;
            targetZoneCollider2.enabled = true;
        }
        else if (currentInitialPosition == initialPosition2)
        {
            currentInitialPosition = initialPosition1;
            targetZoneCollider2.enabled = false;
            targetZoneCollider1.enabled = true;
        } else
        {
            throw new System.Exception("GameManager: Error, unrecognized initialPosition given");
        }
    }

    public void ResetInitialPosition()
    {
        Debug.Log("Reset Player");
        player.transform.position = currentInitialPosition.position;
    }

}
