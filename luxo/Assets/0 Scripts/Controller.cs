using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    private ArrayList items;
    private Vector3 offset;

    public string buttonCode;

	// Use this for initialization
	void Start () {
        items = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
        if (items.Count > 0) {
            Collider item;
            item = (Collider)items[0];

            if (Input.GetButtonDown(buttonCode)) {
                offset = transform.position - item.transform.position;
            }

            if (Input.GetButton(buttonCode))
            {
                item.transform.position = transform.position + offset;
            }
        }
	}

    public void OnTriggerEnter(Collider other) {
        Pickupable item = other.GetComponent<Pickupable>();
        // if the trigger is a controller
        if (item) {
            items.Add(other);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (items.Contains(other))
        {
            items.Remove(other);
        }
    }
}
