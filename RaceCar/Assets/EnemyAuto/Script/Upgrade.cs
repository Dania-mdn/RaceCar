using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public bool isEnemy;

    private GameObject ActivBody;
    public GameObject[] Body;
    private GameObject ActivEngine;
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

    public void UpgradeParts()
    {
        if (isEnemy)
        {
            UpgradeMediate(0, PlayerPrefs.GetInt("ID 0"));
            UpgradeMediate(1, PlayerPrefs.GetInt("ID 1"));
            UpgradeMediate(2, PlayerPrefs.GetInt("ID 2"));
        }
        else
        {
            Upgrade1(0, PlayerPrefs.GetInt("ID 0"));
            Upgrade1(1, PlayerPrefs.GetInt("ID 1"));
            Upgrade1(2, PlayerPrefs.GetInt("ID 2"));
        }
    }
    private void UpgradeMediate(int ID, int lvl)
    {
        int Enemylvl = Random.Range(lvl-1, lvl + 2);
        Enemylvl = Mathf.Clamp(Enemylvl, 0, 10);
        Upgrade1(ID, Enemylvl);
    }
    private void Upgrade1(int ID, int lvl)
    {
        if (ID == 0)
        {
            if (isEnemy)
                PlayerPrefs.SetInt("EnemyID " + ID, lvl);
            for (int i = 0; i < Body.Length; i++)
            {
                if (i == lvl)
                {
                    if (Body[i] != null)
                        Body[i].gameObject.SetActive(true);
                    ActivBody = Body[i];
                    if (ActivEngine != null)
                        ActivEngine.transform.position = ActivBody.transform.GetChild(0).position;
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
            if (isEnemy)
                PlayerPrefs.SetInt("EnemyID " + ID, lvl);
            for (int i = 0; i < Engine.Length; i++)
            {
                if (i == lvl)
                {
                    if (Engine[i] != null)
                        Engine[i].gameObject.SetActive(true);
                    ActivEngine = Engine[i];
                    Engine[i].transform.position = ActivBody.transform.GetChild(0).position;
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
            if (isEnemy)
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
