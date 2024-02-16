using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public UIRace UIRace;
    private Rigidbody rb;
    public float direction;
    public GameObject Direction;
    public float speed = 1;
    public float SpeedTurn;
    public bool bool1;
    public bool bool2;

    float accelerationRight;
    public ParticleSystem RLWParticleSystem;
    public ParticleSystem RRWParticleSystem;

    [Space(10)]
    public TrailRenderer RLWTireSkid;
    public TrailRenderer RRWTireSkid;

    public float accelerationTime = 0.01f; 
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Direction.transform.rotation = Quaternion.Euler(0.0f, direction, 0.0f);

        accelerationRight = Vector3.Dot(rb.velocity, transform.right);

        if (accelerationRight > 9 || accelerationRight < -9)
        {
            RLWParticleSystem.Play();
            RRWParticleSystem.Play();
            RLWTireSkid.emitting = true;
            RRWTireSkid.emitting = true;
        }
        else
        {
            RLWParticleSystem.Stop();
            RRWParticleSystem.Stop();
            RLWTireSkid.emitting = false;
            RRWTireSkid.emitting = false;
        }
        
    }
    void FixedUpdate()
    {
        if(rb.velocity.magnitude < 20 && bool1 && bool1)
        {
            rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
            Quaternion rotation = Direction.transform.rotation;
            Vector3 forwardDirection = rotation * Vector3.forward;
            float rotateInput = Vector3.Dot(forwardDirection, transform.right);
            Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotateInput * 2000 * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
    public void Force()
    {
        if (UIRace.ForceTme >= 3)
        {
            rb.AddForce(Direction.transform.forward * 8000, ForceMode.Impulse);
            UIRace.SetForceColdawn();
        }
    }
}
