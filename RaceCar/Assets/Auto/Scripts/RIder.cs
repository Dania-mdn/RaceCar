using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIder : MonoBehaviour
{
    public CharacterJoint character;
    public FixedJoint[] joint;
    private void Start()
    {
        character.connectedBody = transform.root.GetComponent<Rigidbody>();

        for (int i = 0; i < joint.Length; i++)
        {
            joint[i].connectedBody = transform.root.GetComponent<Rigidbody>();
        }
    }
}
