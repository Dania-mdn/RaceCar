using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAuto : MonoBehaviour
{
    public GameObject[] Body;
    public GameObject[] Engine;
    public GameObject[] While0;
    public GameObject[] While1;
    public GameObject[] While2;
    public GameObject[] While3;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Race"))
        {
            if (PlayerPrefs.HasKey("ID 0"))
            {
                Upgrade(0, PlayerPrefs.GetInt("ID 0"));
                Debug.Log(PlayerPrefs.GetInt("ID 0"));
            }
            if (PlayerPrefs.HasKey("ID 1"))
            {
                Upgrade(1, PlayerPrefs.GetInt("ID 1"));
                Debug.Log(PlayerPrefs.GetInt("ID 1"));
            }
            if (PlayerPrefs.HasKey("ID 2"))
            {
                Upgrade(2, PlayerPrefs.GetInt("ID 2"));
                Debug.Log(PlayerPrefs.GetInt("ID 2"));
            }

            PlayerPrefs.DeleteKey("Race");
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
        if(ID == 0)
        {
            PlayerPrefs.SetInt("ID " + ID, lvl);
            for (int i = 0; i < Body.Length; i++)
            {
                if (i == lvl)
                {
                    Body[i].gameObject.SetActive(true);
                }
                else
                {
                    Body[i].gameObject.SetActive(false);
                }
            }
        }
        else if(ID == 1)
        {
            PlayerPrefs.SetInt("ID " + ID, lvl);
            for (int i = 0; i < Engine.Length; i++)
            {
                if (i == lvl)
                {
                    Engine[i].gameObject.SetActive(true);
                }
                else
                {
                    Engine[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            PlayerPrefs.SetInt("ID " + ID, lvl);
            for (int i = 0; i < While0.Length; i++)
            {
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
    }
}
