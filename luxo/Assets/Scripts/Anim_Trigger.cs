using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Trigger : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Animation anim = other.gameObject.GetComponent<Animation>();
        if (anim)
        {
            anim.Play();
        }

        AudioSource audio = other.gameObject.GetComponent<AudioSource>();
        if (audio && !audio.isPlaying)
        {
            audio.Play();
        }
    }
}
