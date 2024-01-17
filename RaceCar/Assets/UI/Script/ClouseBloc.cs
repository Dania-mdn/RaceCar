using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClouseBloc : MonoBehaviour
{
    private Animation block;
    private void Start()
    {
        block = GetComponent<Animation>();
    }
    public void SetAnimation()
    {
        block.Play();
    }
}
