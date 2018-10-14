using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLights : MonoBehaviour {
    private Light lightComponent;
    private Color color;

    public bool isLit;
    public float initialIntensity;
    public float maxIntensity;
    public float brightenSpeed;
    [Range(0,1)]
    public float colorLerp;

	// Use this for initialization
	void Start () {
        lightComponent = GetComponent<Light>();
        lightComponent.intensity = initialIntensity;
        color = lightComponent.color;
        isLit = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (isLit && lightComponent.intensity < maxIntensity) {
            lightComponent.intensity = lightComponent.intensity + (brightenSpeed * Time.deltaTime);
        } else if (!isLit && lightComponent.intensity > 0) {
            lightComponent.intensity = lightComponent.intensity - (brightenSpeed * Time.deltaTime);
        }

        if (color != lightComponent.color) {
            lightComponent.color = Color.Lerp(lightComponent.color, color, colorLerp);
        }
	}

    public void Wake() {
        isLit = true;
    }

    public void Dim() {
        isLit = false;
    }

    public void SetColor(Color color) {
        this.color = color;
    }

    public void SetColor(string hex) {
        Color color;
        if (ColorUtility.TryParseHtmlString(hex, out color)) {
            SetColor(color);
        } else {
            Debug.LogError("Unable to parse hex code: " + hex);
        }
    }

    public void MakeRed() {
        SetColor("9C4051");
    }
}
