using PathCreation.Examples;
using System;
using UnityEngine;

public class EnemyRace : MonoBehaviour
{
    public PathFollower PathFollower;
    private float FoolowDistance;
    private float FoolowDistanceNext = 0;
    public GameObject FolowObject; 

    [Range(8, 18)]
    public float MaxSpeed = 20;
    [Range(0.3f, 0.9f)]
    public float speedAceleration = 0.9f;
    [Range(5000, 10000)]
    public float ForcePuwer = 10000;

    private Rigidbody rb;
    public float direction;
    public GameObject Direction;
    public float SpeedTurn;
    public bool bool1;
    public bool bool2;
    public bool isUp = false;

    float accelerationRight;
    public ParticleSystem RLWParticleSystem;
    public ParticleSystem RRWParticleSystem;

    [Space(10)]
    public TrailRenderer RLWTireSkid;
    public TrailRenderer RRWTireSkid;

    public AudioSource tireScreechSound;
    public AudioSource boom;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (PlayerPrefs.HasKey("MuteAudio"))
        {
            AudioMute();
        }
    }
    private void Update()
    {
        Vector3 inputDirection = FolowObject.transform.position - Direction.transform.position;
        float rotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
        Direction.transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);

        FoolowDistance = (FolowObject.transform.position - Direction.transform.position).magnitude;
        if (FoolowDistance > 3 + rb.velocity.magnitude / 1.5f)
        {
            PathFollower.speed = 0;
        }
        else
        {
            PathFollower.speed = 50;
        }

        accelerationRight = Vector3.Dot(rb.velocity, transform.right);

        if (accelerationRight > 6 || accelerationRight < -6)
        {
            rb.velocity = rb.velocity * 0.98f;

            RLWParticleSystem.Play();
            RRWParticleSystem.Play();
            RLWTireSkid.emitting = true;
            RRWTireSkid.emitting = true;
            if (!tireScreechSound.isPlaying)
                tireScreechSound.Play();
        }
        else
        {
            RLWParticleSystem.Stop();
            RRWParticleSystem.Stop();
            RLWTireSkid.emitting = false;
            RRWTireSkid.emitting = false;
            if (tireScreechSound.isPlaying)
                tireScreechSound.Stop();
        }

        if (rb.velocity.magnitude < 0.1f && (!bool1 && !bool2) && !isUp)
        {
            isUp = true;
            Invoke("Force1", 1);
        }
    }
    void FixedUpdate()
    {
        if (bool1 || bool2)
        {
            if (rb.velocity.magnitude < MaxSpeed)
            {
                rb.velocity = rb.velocity + transform.forward * speedAceleration;
            }
            Quaternion rotation = Direction.transform.rotation;
            Vector3 forwardDirection = rotation * Vector3.forward;
            float rotateInput = Vector3.Dot(forwardDirection, transform.right);
            Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotateInput * 1000 * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        rb.angularVelocity = new Vector3(0, rb.angularVelocity.y, 0);
    }
    public void SetParametr(int ParametrCount, int lvl)
    {
        if (ParametrCount == 1)
        {
            MaxSpeed = 8 + lvl;
        }
        else if (ParametrCount == 2)
        {
            speedAceleration = 0.3f + ((float)lvl / 20);
        }
        else
        {
            ForcePuwer = 5000 + lvl * 500;
        }
    }
    public void Force1()
    {
        rb.AddForce(Direction.transform.up * 1000, ForceMode.Impulse);
        isUp = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 13)
            if (!boom.isPlaying)
                boom.Play();
    }
    public void AudioMute()
    {
        tireScreechSound.mute = true;
        boom.mute = true;
    }
    public void AudioPlay()
    {
        tireScreechSound.mute = false;
        boom.mute = false;
    }
}
