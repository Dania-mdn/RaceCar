using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Enviroment : MonoBehaviour
{
    public GameObject[] road;
    public float moveSpeed;

    public GameObject MeinRoad;
    public GameObject SecondRoad;

    private float Speed;

    private void OnEnable()
    {
        EventManager.AddSpeed += SetSpeed;
    }
    private void OnDisable()
    {
        EventManager.AddSpeed -= SetSpeed;
    }
    private void Update()
    {
        MeinRoad.transform.Translate(Vector3.left * moveSpeed * Speed * Time.deltaTime);
        SecondRoad.transform.Translate(Vector3.left * moveSpeed * Speed * Time.deltaTime);

        if(MeinRoad.transform.position.x < -24)
        {
            Destroy(SecondRoad);
            SecondRoad = MeinRoad;
            MeinRoad = Instantiate(road[Random.Range(0, road.Length)], SecondRoad.transform.position + (SecondRoad.transform.right * SecondRoad.transform.localScale.x * 10), Quaternion.identity, transform);
        }
    }
    private void SetSpeed(float speed)
    {
        Speed = speed;
    }
}
