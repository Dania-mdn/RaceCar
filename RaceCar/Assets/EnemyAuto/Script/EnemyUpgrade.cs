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

        Upgrade(0, PlayerPrefs.GetInt("EnemyID 0"));
        Upgrade(1, PlayerPrefs.GetInt("EnemyID 1"));
        Upgrade(2, PlayerPrefs.GetInt("EnemyID 2"));
    }
    private void OnEnable()
    {
        EventManager.UpgradeAuto += UpgradeMediate;
    }
    private void OnDisable()
    {
        EventManager.UpgradeAuto += UpgradeMediate;
    }
    private void UpgradeMediate(int ID, int lvl)
    {
        int Enemylvl = Random.Range(lvl, lvl + 2);
        Upgrade(ID, Enemylvl);
    }
    private void Upgrade(int ID, int lvl)
    {
        if (ID == 0)
        {
            if (EnemyRace != null)
                EnemyRace.accelerationMultiplier = lvl;
            PlayerPrefs.SetInt("EnemyID " + ID, lvl);
            for (int i = 0; i < Body.Length; i++)
            {
                if (i == lvl)
                {
                    if (Body[i] != null)
                        Body[i].gameObject.SetActive(true);
                    lvl0 = lvl;
                }
                else
                {
                    if (Body[i] != null)
                        Body[i].gameObject.SetActive(false);
                }
            }
        }
        else if (ID == 1)
        {
            if (EnemyRace != null)
                EnemyRace.maxSpeedDefolt = lvl * 10;
            PlayerPrefs.SetInt("EnemyID " + ID, lvl);
            for (int i = 0; i < Engine.Length; i++)
            {
                if (i == lvl)
                {
                    if(Engine[i] != null)
                        Engine[i].gameObject.SetActive(true);
                    lvl1 = lvl;
                }
                else
                {
                    if (Engine[i] != null)
                        Engine[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (EnemyRace != null)
                EnemyRace.WheelModyfer = lvl;
            PlayerPrefs.SetInt("EnemyID " + 2, lvl);
            for (int i = 0; i < While0.Length; i++)
            {
                lvl2 = lvl;
                if (i == lvl)
                {
                    if (While0[i] != null)
                    {
                        While0[i].gameObject.SetActive(true);
                        While1[i].gameObject.SetActive(true);
                        While2[i].gameObject.SetActive(true);
                        While3[i].gameObject.SetActive(true);
                    }
                }
                else
                {
                    if (While0[i] != null)
                    {
                        While0[i].gameObject.SetActive(false);
                        While1[i].gameObject.SetActive(false);
                        While2[i].gameObject.SetActive(false);
                        While3[i].gameObject.SetActive(false);
                    }
                }
            }
        }
        if (body != null)
        {
            body.text = lvl0.ToString();
            Wheels.text = lvl1.ToString();
            Engines.text = lvl2.ToString();
        }
    }
}
