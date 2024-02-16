using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWheel : MonoBehaviour
{
    public Test Test;
    public bool IsRight;

    private void OnCollisionEnter(Collision collision)
    {
        if(IsRight)
            Test.bool1 = true;
        else
            Test.bool2 = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (IsRight)
            Test.bool1 = false;
        else
            Test.bool2 = false;
    }
}
