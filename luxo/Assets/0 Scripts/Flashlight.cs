using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

    private Light lightComponent;

	// Use this for initialization
	void Start () {
        lightComponent = GetComponent<Light>();
	}
	
    public void SetLight(bool on) {
        if (!lightComponent) {
            Debug.LogWarning("Couldn't find flashlight light on start.");
            lightComponent = GetComponent<Light>();
        }
        if (on) {
            lightComponent.enabled = on;
        }
    }
}
