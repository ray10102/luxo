using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevCam : MonoBehaviour {
    private float speedMultiplier;
    public float quickSpeed;
    public float rotationMulti;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Camera movement
        
        // Holding left shift makes all transformations faster
        // If holding down left alt, arrow keys control rotation
        // Else, arrow keys control translation

        // Speed
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            speedMultiplier = quickSpeed;
        } if (Input.GetKeyUp(KeyCode.LeftShift)) {
            speedMultiplier = 1;
        }

        // Rotation
        if (Input.GetKeyDown(KeyCode.Escape)) {
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (Input.GetKey(KeyCode.LeftAlt)) {
            Debug.Log("left alt");
            if (Input.GetKey(KeyCode.LeftArrow)) {
                transform.Rotate(Vector3.down * Time.deltaTime * rotationMulti * speedMultiplier);
            } else if (Input.GetKey(KeyCode.RightArrow)) {
                transform.Rotate(Vector3.up * Time.deltaTime * rotationMulti * speedMultiplier);
            } else if (Input.GetKey(KeyCode.UpArrow)) {
                transform.Rotate(Vector3.left * Time.deltaTime * rotationMulti * speedMultiplier);
            } else if (Input.GetKey(KeyCode.DownArrow)) {
                transform.Rotate(Vector3.right * Time.deltaTime * rotationMulti * speedMultiplier);
            } 
        } else {
            // Translation
            if (Input.GetKey(KeyCode.LeftArrow)) {
                transform.Translate(Vector3.left * Time.deltaTime * speedMultiplier);
            } else if (Input.GetKey(KeyCode.RightArrow)) {
                transform.Translate(Vector3.right * Time.deltaTime * speedMultiplier);
            } else if (Input.GetKey(KeyCode.UpArrow)) {
                transform.Translate(Vector3.forward * Time.deltaTime * speedMultiplier);
            } else if (Input.GetKey(KeyCode.DownArrow)) {
                transform.Translate(Vector3.back * Time.deltaTime * speedMultiplier);
            } else if (Input.GetKey(KeyCode.Space)) {
                transform.Translate(Vector3.up * Time.deltaTime * speedMultiplier);
            } else if (Input.GetKey(KeyCode.LeftControl)) {
                transform.Translate(Vector3.down * Time.deltaTime * speedMultiplier);
            }
        }
    }
}
