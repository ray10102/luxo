using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPoint : MonoBehaviour {
    public float angle;
    public Vector2 relativeXY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A)) {
            Rotate();
        }
	}

    public void Rotate() {
        gameObject.transform.RotateAround(new Vector3(transform.position.x /*+ relativeXY.x*/, transform.position.y, transform.position.z /*+ relativeXY.y*/), Vector3.up, angle);
    }
}
