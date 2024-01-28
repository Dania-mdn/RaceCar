using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Cinemachine;

public class Enviroment : MonoBehaviour
{
    public GameObject[] road;
    private float bazespeed = 2.5f;
    public float moveSpeed = 2.5f;

    public GameObject MeinRoad;
    public GameObject SecondRoad;

    private float Speed = 1;

    public ParticleSystem ParticleSystem;
    public CinemachineVirtualCamera VirtualCamera;

    void Start()
    {
        ParticleSystem.Stop();
    }
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
    private void Update()
    {
        MeinRoad.transform.Translate(Vector3.left * moveSpeed * Speed * Time.deltaTime);
        SecondRoad.transform.Translate(Vector3.left * moveSpeed * Speed * Time.deltaTime);

        if (MeinRoad.transform.position.x < -24)
        {
            Destroy(SecondRoad);
            SecondRoad = MeinRoad;
            MeinRoad = Instantiate(road[Random.Range(0, road.Length)], SecondRoad.transform.position + (SecondRoad.transform.right * SecondRoad.transform.localScale.x * 10), Quaternion.identity, transform);
        }
    }
    private void SetSpeed(float speed)
    {
        Speed = speed;
        if (speed > 1)
        {
            VirtualCamera.Priority = 11;
            ParticleSystem.Play();
        }
        else
        {
            VirtualCamera.Priority = 9;
            ParticleSystem.Stop();
        }
    }
    private void UpgradeSpeed(float speed)
    {
        moveSpeed = bazespeed + speed / 2;
    }
}
