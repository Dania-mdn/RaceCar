using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UIElements;

public class MuweInMeinMenu : MonoBehaviour
{
    public float rotationSpeed = 400;

    public GameObject frontLeftMesh;
    public GameObject frontRightMesh;
    public GameObject rearLeftMesh;
    public GameObject rearRightMesh;

    private float Speed = 1;
    private Rigidbody rb;

    private void OnEnable()
    {
        EventManager.AddSpeed += SetSpeed;
    }
    private void OnDisable()
    {
        EventManager.AddSpeed -= SetSpeed;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    void Update()
    {
        /*if (transform.rotation.y != 90)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), 0.1f);
        }*/

        if(rb.IsSleeping()) rb.WakeUp();

        frontLeftMesh.transform.Rotate(Vector3.right * rotationSpeed * Speed * Time.deltaTime);
        frontRightMesh.transform.Rotate(Vector3.left * rotationSpeed * Speed * Time.deltaTime);
        rearLeftMesh.transform.Rotate(Vector3.right * rotationSpeed * Speed * Time.deltaTime);
        rearRightMesh.transform.Rotate(Vector3.left * rotationSpeed * Speed * Time.deltaTime);
    }
    private void SetSpeed(float speed)
    {
        Speed = speed;
    }
}
