using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyUpgrade : MonoBehaviour
{
    private EnemyRace EnemyRace;

    public GameObject[] Body;
    public GameObject[] Engine;
    public GameObject[] While0;
    public GameObject[] While1;
    public GameObject[] While2;
    public GameObject[] While3;

    public int lvl0 = 0;
    public TextMeshProUGUI body;
    public int lvl1 = 0;
    public TextMeshProUGUI Wheels;
    public int lvl2 = 0;
    public TextMeshProUGUI Engines;

    private void Start()
    {
        EnemyRace = GetComponent<EnemyRace>();

        if (PlayerPrefs.HasKey("EnemyID 0"))
        {
            Upgrade(0, PlayerPrefs.GetInt("ID 0"));
        }
        if (PlayerPrefs.HasKey("EnemyID 1"))
        {
            Upgrade(1, PlayerPrefs.GetInt("ID 1"));
        }
        if (PlayerPrefs.HasKey("EnemyID 2"))
        {
            Upgrade(2, PlayerPrefs.GetInt("ID 2"));
        }
    }
    private void OnEnable()
    {
        EventManager.UpgradeAuto += Upgrade;
    }
    private void OnDisable()
    {
        EventManager.UpgradeAuto += Upgrade;
    }
    private void Upgrade(int ID, int lvl)
    {
        if (ID == 0)
        {
            int Enemylvl = Random.Range(lvl - 1, lvl + 1);

            if (EnemyRace != null)
                EnemyRace.accelerationMultiplier = Enemylvl;
            PlayerPrefs.SetInt("EnemyID " + ID, Enemylvl);
            for (int i = 0; i < Body.Length; i++)
            {
                if (i == Enemylvl)
                {
                    Body[i].gameObject.SetActive(true);
                    lvl0 = Enemylvl;
                }
                else
                {
                    Body[i].gameObject.SetActive(false);
                }
            }
        }
        else if (ID == 1)
        {
            int Enemylvl = Random.Range(lvl - 1, lvl + 1);

            if (EnemyRace != null)
                EnemyRace.maxSpeedDefolt = Enemylvl * 10;
            PlayerPrefs.SetInt("EnemyID " + ID, Enemylvl);
            for (int i = 0; i < Engine.Length; i++)
            {
                if (i == Enemylvl)
                {
                    Engine[i].gameObject.SetActive(true);
                    lvl1 = Enemylvl;
                }
                else
                {
                    Engine[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            int Enemylvl = Random.Range(lvl - 1, lvl + 1);

            if (EnemyRace != null)
                EnemyRace.WheelModyfer = Enemylvl;
            PlayerPrefs.SetInt("EnemyID " + ID, Enemylvl);
            for (int i = 0; i < While0.Length; i++)
            {
                lvl2 = Enemylvl;
                if (i == Enemylvl)
                {
                    While0[i].gameObject.SetActive(true);
                    While1[i].gameObject.SetActive(true);
                    While2[i].gameObject.SetActive(true);
                    While3[i].gameObject.SetActive(true);
                }
                else
                {
                    While0[i].gameObject.SetActive(false);
                    While1[i].gameObject.SetActive(false);
                    While2[i].gameObject.SetActive(false);
                    While3[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
