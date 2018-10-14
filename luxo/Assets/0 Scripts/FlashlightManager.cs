using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightManager : MonoBehaviour {

    public Flashlight left;
    public Flashlight right;

    void Update()
    {
        if (Input.GetButtonDown("14"))
        {
            if (!left.isOn)
            {
                right.SetLight(false);
            }
            left.SetLight(!left.isOn);
        }
        if (Input.GetButtonDown("15"))
        {
            if (!right.isOn)
            {
                left.SetLight(false);
            }
            right.SetLight(!right.isOn);
        }
    }
}