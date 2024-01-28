using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public EnemyRace EnemyRace;
    public AutoController AutoController;

    private float Coldawn = 3;
    private float TimeStart;
    private bool isstart = false;

    private void Start()
    {
        EnemyRace.maxSpeed = 0;
        AutoController.maxSpeed = 0;
        TimeStart = Coldawn;
    }
    void Update()
    {
        if (isstart) return;

        if (TimeStart > 0)
        {
            TimeStart = TimeStart - Time.deltaTime;
        }
        else
        {
            EnemyRace.maxSpeed = EnemyRace.maxSpeedDefolt;
            AutoController.maxSpeed = AutoController.maxSpeedDefolt;
            isstart = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if ()
        //{

        //}
    }
}
