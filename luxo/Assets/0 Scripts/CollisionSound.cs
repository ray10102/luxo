using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour {
    public AudioClip[] clips;

    private AudioSource source;

	// Use this for initialization
	void Start () {
        Debug.Log("add sounds to beer!!");
        source = GetComponent<AudioSource>();
	}

    public void OnCollisionEnter(Collision other) {
        // if soft, don't make noise
        if (other.gameObject.GetComponentInParent<SoftObject>()) {
            return;
        }

        source.PlayOneShot(clips[Random.Range(0, clips.Length)], 1f);
    }
}
