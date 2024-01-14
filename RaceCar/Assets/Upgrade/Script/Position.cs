using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public Transform Parts;

    private void Start()
    {
        if(transform.childCount > 0)
            Parts = transform.GetChild(0);
    }
}
