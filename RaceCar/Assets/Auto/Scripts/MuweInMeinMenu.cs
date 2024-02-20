using System;
using UnityEngine;

public class MuweInMeinMenu : MonoBehaviour
{
    private float bazespeed = 200;
    private float rotationSpeed = 200;

    public GameObject frontLeftMesh;
    public WheelCollider frontLeftCollider;
    [Space(10)]
    public GameObject frontRightMesh;
    public WheelCollider frontRightCollider;
    [Space(10)]
    public GameObject rearLeftMesh;
    public WheelCollider rearLeftCollider;
    [Space(10)]
    public GameObject rearRightMesh;
    public WheelCollider rearRightCollider;

    private float Speed = 1;
    private Rigidbody rb;

    private void OnEnable()
    {
        EventManager.AddSpeed += SetSpeed;
        EventManager.Upgrade += UpgradeSpeed;
    }
    private void OnDisable()
    {
        EventManager.AddSpeed -= SetSpeed;
        EventManager.Upgrade -= UpgradeSpeed;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    void Update()
    {
        if(rb.IsSleeping()) rb.WakeUp();

        frontLeftMesh.transform.Rotate(Vector3.right * rotationSpeed * Speed * Time.deltaTime);
        frontRightMesh.transform.Rotate(Vector3.left * rotationSpeed * Speed * Time.deltaTime);
        rearLeftMesh.transform.Rotate(Vector3.right * rotationSpeed * Speed * Time.deltaTime);
        rearRightMesh.transform.Rotate(Vector3.left * rotationSpeed * Speed * Time.deltaTime);

        AnimateWheelMeshes();
    }
    void AnimateWheelMeshes()
    {
        try
        {
            Quaternion FLWRotation;
            Vector3 FLWPosition;
            frontLeftCollider.GetWorldPose(out FLWPosition, out FLWRotation);
            frontLeftMesh.transform.position = FLWPosition;

            Quaternion FRWRotation;
            Vector3 FRWPosition;
            frontRightCollider.GetWorldPose(out FRWPosition, out FRWRotation);
            frontRightMesh.transform.position = FRWPosition;

            Quaternion RLWRotation;
            Vector3 RLWPosition;
            rearLeftCollider.GetWorldPose(out RLWPosition, out RLWRotation);
            rearLeftMesh.transform.position = RLWPosition;

            Quaternion RRWRotation;
            Vector3 RRWPosition;
            rearRightCollider.GetWorldPose(out RRWPosition, out RRWRotation);
            rearRightMesh.transform.position = RRWPosition;
        }
        catch (Exception ex)
        {
            Debug.LogWarning(ex);
        }
    }
    private void SetSpeed(float speed)
    {
        Speed = speed;
    }
    private void UpgradeSpeed(float speed)
    {
        rotationSpeed = bazespeed + speed * 8;
    }
}
