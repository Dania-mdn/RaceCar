using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public AutoController AutoController;
    public EnemyRace EnemyRacePlayer;
    public EnemyRace EnemyRace;

    public Canvas Canvas;
    public GameObject Joistick;
    public GameObject TextWinner;
    public Camera Camera;
    public CinemachineVirtualCamera VirtualCamera;

    private float Coldawn = 3;
    private float TimeStart;
    private bool isstart = false;
    private bool isFinish = false;

    public int RaceCountforWinn = 2;
    private int RaceCountPlayer = 0;
    public bool isCheckRacePlayer = true;
    private int RaceCountEnemy = 0;
    public bool isCheckRaceEnemy = true;


    public GameObject StartObject;
    public GameObject[] StartLight;

    private void Start()
    {
        EnemyRace.maxSpeed = 0;
        AutoController.maxSpeed = 0;
        TimeStart = Coldawn;
        StartObject.SetActive(true);
    }
    void Update()
    {
        if (!isFinish)
        {
            if (RaceCountPlayer > RaceCountforWinn)
            {
                Finish(true);
            }
            else if (RaceCountEnemy > RaceCountforWinn)
            {
                Finish(false);
            }
        }

        if (isstart) return;

        if (TimeStart > 0)
        {
            TimeStart = TimeStart - Time.deltaTime;

            if (TimeStart > 2)
            {
                StartLight[0].SetActive(true);
                StartLight[1].SetActive(false);
                StartLight[2].SetActive(false);
            }
            else if (TimeStart > 1)
            {
                StartLight[0].SetActive(false);
                StartLight[1].SetActive(true);
                StartLight[2].SetActive(false);
            }
            else
            {
                StartLight[0].SetActive(false);
                StartLight[1].SetActive(false);
                StartLight[2].SetActive(true);
            }
        }
        else
        {
            EnemyRace.maxSpeed = EnemyRace.maxSpeedDefolt;
            AutoController.maxSpeed = AutoController.maxSpeedDefolt;
            EnemyRacePlayer.maxSpeed = EnemyRacePlayer.maxSpeedDefolt;
            isstart = true;

            if (StartObject.activeSelf == true)
                StartObject.SetActive(false);
        }
    }
    public void Finish(bool isWin)
    {
        Destroy(AutoController);
        EnemyRacePlayer.enabled = true;
        VirtualCamera.Priority = 3;
        isFinish = true;
        Canvas.planeDistance = 2;
        Joistick.SetActive(false);
        TextWinner.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            if (isCheckRacePlayer)
            {
                RaceCountPlayer++;
                isCheckRacePlayer = false;
            }
        }
        else if (other.gameObject.layer == 11)
        {
            if (isCheckRaceEnemy)
            {
                RaceCountEnemy++;
                isCheckRaceEnemy = false;
            }
        }
    }
}
