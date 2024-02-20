using UnityEngine;
using UnityEngine.UI;

public class UIRace : MonoBehaviour
{
    public Slider SliderForce;

    private float ForceColdawn = 0;
    public float ForceTme;
    private void Start()
    {
        SliderForce.maxValue = 3;
    }
    void Update()
    {
        if (ForceTme < 3)
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
