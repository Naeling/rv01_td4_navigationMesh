using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horn : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip hornClip;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision with a player");
            audioSource.PlayOneShot(hornClip);
        }
    }
}
