using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public UIRace UIRace;
    private Rigidbody rb;
    public float direction;
    public GameObject Direction;
    private float speed = 50;
    public float SpeedTurn;

    float accelerationRight;
    public ParticleSystem RLWParticleSystem;
    public ParticleSystem RRWParticleSystem;

    [Space(10)]
    public TrailRenderer RLWTireSkid;
    public TrailRenderer RRWTireSkid;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //Direction.transform.rotation = Quaternion.Euler(0.0f, direction, 0.0f);

        //Quaternion targetRotation = Direction.transform.rotation;

        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, SpeedTurn * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0.0f, direction, 0.0f);

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
        rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
    }
    public void Force()
    {
        if (UIRace.ForceTme >= 3)
        {
            rb.AddForce(transform.forward * -7200, ForceMode.Impulse);
            UIRace.SetForceColdawn();
        }
    }
    /*public UIRace UIRace;
    private Rigidbody rb;
    public float direction;
    public GameObject Direction;
    public float speed = 4;
    public float SpeedTurn;
    private float _rotationVelocity;

    float accelerationRight;
    public ParticleSystem RLWParticleSystem;
    public ParticleSystem RRWParticleSystem;

    [Space(10)]
    public TrailRenderer RLWTireSkid;
    public TrailRenderer RRWTireSkid;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, direction, ref _rotationVelocity,
            SpeedTurn);
        gameObject.transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);

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
        rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
    }
    public void Force()
    {
        if (UIRace.ForceTme >= 3)
        {
            rb.AddForce(transform.forward * -7200, ForceMode.Impulse);
            UIRace.SetForceColdawn();
        }
    }*/
}
