using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeAuto : MonoBehaviour
{
    public Animation AnimBody;
    public Animation AnimWhile1;
    public Animation AnimWhile2;
    public Animation AnimWhile3;
    public Animation AnimWhile4;
    public Animation AnimEngine;

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
        if (PlayerPrefs.HasKey("Race"))
        {
            if (PlayerPrefs.HasKey("ID 0"))
            {
                Upgrade(0, PlayerPrefs.GetInt("ID 0"));
            }
            if (PlayerPrefs.HasKey("ID 1"))
            {
                Upgrade(1, PlayerPrefs.GetInt("ID 1"));
            }
            if (PlayerPrefs.HasKey("ID 2"))
            {
                Upgrade(2, PlayerPrefs.GetInt("ID 2"));
            }

            PlayerPrefs.DeleteKey("Race");
        }
        body.text = "TIER " + lvl0.ToString();
        Wheels.text = "TIER " + lvl1.ToString();
        Engines.text = "TIER " + lvl2.ToString();
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
        if(ID == 0)
        {
            if(AnimBody != null)
                AnimBody.Play();
            PlayerPrefs.SetInt("ID " + ID, lvl);
            for (int i = 0; i < Body.Length; i++)
            {
                if (i == lvl)
                {
                    Body[i].gameObject.SetActive(true);
                    lvl0 = lvl;
                }
                else
                {
                    Body[i].gameObject.SetActive(false);
                }
            }
        }
        else if(ID == 1)
        {
            if (AnimEngine != null)
                AnimEngine.Play();
            PlayerPrefs.SetInt("ID " + ID, lvl);
            for (int i = 0; i < Engine.Length; i++)
            {
                if (i == lvl)
                {
                    Engine[i].gameObject.SetActive(true);
                    lvl1 = lvl;
                }
                else
                {
                    Engine[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (AnimWhile2 != null)
            {
                AnimWhile1.Play();
                AnimWhile2.Play();
                AnimWhile3.Play();
                AnimWhile4.Play();
            }
            PlayerPrefs.SetInt("ID " + ID, lvl);
            for (int i = 0; i < While0.Length; i++)
            {
                lvl2 = lvl;
                if (i == lvl)
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
        EventManager.DoUpgrade(lvl0 + lvl1 + lvl2);
        body.text = "TIER" + lvl0.ToString();
        Wheels.text = "TIER" + lvl1.ToString();
        Engines.text = "TIER" + lvl2.ToString();
    }
}
