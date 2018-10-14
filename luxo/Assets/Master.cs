using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour {
    public Animator Lamp, Couch, Swivel, Fridge, FloorLamp;
    public GameObject FallenChairObjects;
    public RoomLights[] lights;
    public Light FloorLampLight;
    public Color[] lightColors;

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TriggerLamp();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TurnOnLights();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TurnOffLights();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TriggerCouch();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TriggerSwivel();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TriggerFloorLamp();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            TriggerFallenChair();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            TriggerEvilLights();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TriggerNormalLights();
        }

    }

    public void TriggerLamp()
    {
        Lamp.SetTrigger(0);
    }

    public void TurnOnLights()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].Wake();
        }
    }

    public void TurnOffLights()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].Dim();
        }
    }

    public void TriggerCouch()
    {
        Couch.SetTrigger(0);
    }

    public void TriggerSwivel()
    {
        Swivel.SetTrigger(0);
    }

    public void TriggerFloorLamp()
    {
        FloorLamp.gameObject.transform.position = new Vector3(2.67f, -1.626f, -2.2f);
        FloorLamp.SetTrigger(0);
    }

    public void ToggleFloorLampLight()
    {
        FloorLampLight.enabled = true;
        FloorLampLight.color = lightColors[Random.Range(0, lightColors.Length)];
    }

    public void TriggerFallenChair()
    {
        FallenChairObjects.SetActive(true);
    }

    public void TriggerEvilLights()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].MakeRed();
        }
    }

    public void TriggerNormalLights()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetColor(Color.white);
        }
    }

}
