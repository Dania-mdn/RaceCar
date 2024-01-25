using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRace : MonoBehaviour
{
    public Slider SliderForce;

    private float ForceColdawn = 0;
    public float ForceTme;

    void Update()
    {
        if (ForceTme < 2)
        {
            ForceTme = ForceTme + Time.deltaTime;
            SliderForce.value = ForceTme;
        }
    }
    public void SetForceColdawn()
    {
        ForceTme = ForceColdawn;
    }
}
