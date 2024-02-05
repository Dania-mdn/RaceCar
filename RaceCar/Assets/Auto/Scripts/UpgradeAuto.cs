using UnityEngine;
using TMPro;

public class UpgradeAuto : MonoBehaviour
{
    private AutoController AutoController;

    public Animation AnimBody;
    public Animation AnimWhile1;
    public Animation AnimWhile2;
    public Animation AnimWhile3;
    public Animation AnimWhile4;
    public Animation AnimEngine;

    public GameObject ActivBody;
    public GameObject[] Body;
    public GameObject ActivEngine;
    public GameObject[] Engine;
    public AudioSource[] EngineAud;
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

    public AudioSource UpgradeAudio;

    private void Start()
    {
        AutoController = GetComponent<AutoController>();

        Upgrade(0, PlayerPrefs.GetInt("ID 0"));
        Upgrade(1, PlayerPrefs.GetInt("ID 1"));
        Upgrade(2, PlayerPrefs.GetInt("ID 2"));

        if (body != null)
        {
            body.text = lvl0.ToString();
            Wheels.text = lvl1.ToString();
            Engines.text = lvl2.ToString();
        }
    }
    private void OnEnable()
    {
        EventManager.UpgradeAuto += Upgrade;
    }
    private void OnDisable()
    {
        EventManager.UpgradeAuto -= Upgrade;
    }
    private void Upgrade(int ID, int lvl)
    {
        if(UpgradeAudio != null)
            UpgradeAudio.Play();

        if (ID == 0)
        {
            if(AutoController != null)
             AutoController.accelerationMultiplier = lvl;
            if (AnimBody != null)
                AnimBody.Play();
            PlayerPrefs.SetInt("ID " + ID, lvl);
            for (int i = 0; i < Body.Length; i++)
            {
                if (i == lvl)
                {
                    Body[i].gameObject.SetActive(true);
                    ActivBody = Body[i];
                    if(ActivEngine != null)
                        ActivEngine.transform.position = ActivBody.transform.GetChild(0).position;
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
            if (AutoController != null)
                AutoController.maxSpeedDefolt = lvl * 10;
            if (AnimEngine != null)
                AnimEngine.Play();
            PlayerPrefs.SetInt("ID " + ID, lvl);
            for (int i = 0; i < Engine.Length; i++)
            {
                if (i == lvl)
                {
                    Engine[i].gameObject.SetActive(true);
                    ActivEngine = Engine[i];
                    Engine[i].transform.position = ActivBody.transform.GetChild(0).position;
                    if (Engine[i].transform.GetChild(0).GetComponent<ParticleSystem>() != null)
                        Engine[i].transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                    if (EngineAud.Length > 1)
                        EngineAud[i].Play();
                    lvl1 = lvl;
                }
                else
                {
                    Engine[i].gameObject.SetActive(false);
                    if (EngineAud.Length > 1)
                        EngineAud[i].Stop();
                }
            }
        }
        else
        {
            if (AutoController != null)
                AutoController.WheelModyfer = lvl;
            if (AnimWhile2 != null)
            {
                AnimWhile1.Play();
                AnimWhile2.Play();
                AnimWhile3.Play();
                AnimWhile4.Play();
            }
            PlayerPrefs.SetInt("ID " + 2, lvl);
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
        if (body != null)
        {
            body.text = lvl0.ToString();
            Wheels.text = lvl1.ToString();
            Engines.text = lvl2.ToString();
        }
    }
}
