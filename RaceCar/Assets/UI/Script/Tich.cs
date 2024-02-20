using UnityEngine;

public class Tich : MonoBehaviour
{
    public GameObject[] Plane;
    private int counAvalable = 0;
    public GameObject[] RewardAndSale;
    public GameObject Race;
    public GameObject SkipButton;
    public MoneyHandler MoneyHandler;
    public PartsPositionController PartsPositionController;
    public GameObject[] PartsPosition;
    private void OnEnable()
    {
        EventManager.SetAvalebleIncpmMoney += AvalebleIncpmMoney;
        EventManager.UpgradeAuto += Upgrade;
        EventManager.AddSpeed += SetSpeed;
        EventManager.PartsUpgrade += PartsUpgrade;
    }
    private void OnDisable()
    {
        EventManager.SetAvalebleIncpmMoney -= AvalebleIncpmMoney;
        EventManager.UpgradeAuto -= Upgrade;
        EventManager.AddSpeed -= SetSpeed;
        EventManager.PartsUpgrade -= PartsUpgrade;
    }
    private void Start()
    {
        SkipButton.SetActive(true);

        if (PlayerPrefs.HasKey("Tich"))
        {
            Destroy(gameObject);
        }
        else
        {
            if (PlayerPrefs.HasKey("TichFirst"))
            {
                SkipButton.SetActive(false);
                Race.SetActive(false); 
                counAvalable = 5;
            }
            else
            {
                PartsPositionController.Parts[0] = PartsPosition[0];
                PartsPositionController.Parts[1] = PartsPosition[0];
                PartsPositionController.Parts[2] = PartsPosition[0];
                Plane[0].SetActive(true);
                Race.SetActive(false);
                RewardAndSale[0].SetActive(false);
                RewardAndSale[1].SetActive(false);
                RewardAndSale[2].SetActive(false);
            }
        }
    }
    private void AvalebleIncpmMoney(float AvalableCount)
    {
        if (counAvalable == 0)
        {
            Plane[0].SetActive(false);
            Plane[1].SetActive(true);
            counAvalable++;
            PartsPositionController.Parts[0] = PartsPosition[2];
            PartsPositionController.Parts[1] = PartsPosition[2];
            PartsPositionController.Parts[2] = PartsPosition[2];
        }
        else if(counAvalable == 1)
        {
            Plane[3].SetActive(false);
            Plane[4].SetActive(true);
            counAvalable++;
        }
        else if(counAvalable == 2)
        {
            Plane[4].SetActive(false);
            Plane[5].SetActive(true);
            counAvalable++;
        }
        else if(counAvalable == 3)
        {
            Plane[5].SetActive(false);
            Plane[6].SetActive(true);
            PartsPositionController.Parts[0] = PartsPosition[1];
            PartsPositionController.Parts[1] = PartsPosition[1];
            PartsPositionController.Parts[2] = PartsPosition[1];
            counAvalable++;
        }
    }
    private void Upgrade(int ID, int lvl)
    {
        if (counAvalable < 4)
        {
            Plane[1].SetActive(false);
            Plane[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("ID 0") >= 1 && PlayerPrefs.GetInt("ID 1") >= 1 && PlayerPrefs.GetInt("ID 2") >= 1)
        {
            SkipButton.SetActive(true);
            Plane[7].SetActive(true);
            Race.SetActive(true);
        }
    }
    private void PartsUpgrade()
    {
        if (counAvalable == 4)
        {
            Plane[6].SetActive(false);
            RewardAndSale[0].SetActive(true);
            RewardAndSale[1].SetActive(true);
            RewardAndSale[2].SetActive(true);
            PlayerPrefs.SetInt("TichFirst", 1);
            SkipButton.SetActive(false);
        }
    }
    public void Skip()
    {
        PlayerPrefs.SetInt("Tich", 1);
        PartsPositionController.Parts[0] = PartsPosition[0];
        PartsPositionController.Parts[1] = PartsPosition[1];
        PartsPositionController.Parts[2] = PartsPosition[2];
        RewardAndSale[0].SetActive(true);
        RewardAndSale[1].SetActive(true);
        RewardAndSale[2].SetActive(true);
        Race.SetActive(true);
        Destroy(gameObject);
    }
    private void SetSpeed(float speed)
    {
        if (speed > 1 && Plane[2].activeSelf == true)
        {
            Plane[2].SetActive(false);
            Plane[3].SetActive(true);
        }
    }
        
}
