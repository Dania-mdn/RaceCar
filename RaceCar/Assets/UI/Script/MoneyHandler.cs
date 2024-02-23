using TMPro;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{
    public UIManager UIManager;
    public PartsPositionController PartsPositionController;
    public float money = 140;
    private float moneyInSecond = 5;
    public Animation AnimMoneyInSecond;
    private float coldawn = 1;

    private float timespeed;
    private float coefMnog = 1;

    private float speed;
    private float coefspeed = 0.2f;

    private float AutoTapColdawn = 60;
    private float AutoTapTme;

    private float IncomX2Coldawn = 60;
    private float IncomX2Tme;
    private int coefX2 = 1;

    private float IncomCount = 4;

    private float IncomPriece = 20;
    private float PartsPrize = 50;

    private float RaceColdawn = 60;
    private float RaceTme;
    public GameObject RaceTmeObject;
    public GameObject RaceTmeObject1;
    public ParticleSystem ParticleSystem;

    private void OnEnable()
    {
        EventManager.OnClickDown += PrepeaToSale;
        EventManager.Sale += Sale;
        EventManager.DeleteAll += DeleteAll;
    }
    private void OnDisable()
    {
        EventManager.OnClickDown -= PrepeaToSale;
        EventManager.Sale -= Sale;
        EventManager.DeleteAll -= DeleteAll;
    }
    private void Start()
    {
        EventManager.DoShowAdd();

        if (PlayerPrefs.HasKey("money"))
        {
            if (PlayerPrefs.HasKey("rewardMoney"))
            {
                money = PlayerPrefs.GetFloat("money") + PlayerPrefs.GetFloat("rewardMoney");
                UIManager.RaceText.gameObject.GetComponent<Animation>().Play();
                FormaterCount1(Mathf.Round(PlayerPrefs.GetFloat("rewardMoney")), UIManager.RaceText);
            }
            else
            {
                money = PlayerPrefs.GetFloat("money");
            }
        }

        if (PlayerPrefs.HasKey("PartsPrize"))
        {
            PartsPrize = PlayerPrefs.GetFloat("PartsPrize");
            PartsPrize = Mathf.Clamp(PartsPrize, 0, 1000000000000000000);
        }
        else
        {
            PlayerPrefs.SetFloat("PartsPrize", PartsPrize);
        }


        if (PlayerPrefs.HasKey("IncomPriece"))
        {
            IncomPriece = PlayerPrefs.GetFloat("IncomPriece");
            IncomPriece = Mathf.Clamp(IncomPriece, 0, 1000000000000000000);
        }
        else
        {
            PlayerPrefs.SetFloat("IncomPriece", PartsPrize);
        }

        if (PlayerPrefs.HasKey("moneyInSecond"))
        {
            moneyInSecond = PlayerPrefs.GetFloat("moneyInSecond");
            moneyInSecond = Mathf.Clamp(moneyInSecond, 0, 1000000000000000000);
        }
        else
        {
            PlayerPrefs.SetFloat("moneyInSecond", moneyInSecond);
        }

        if (PlayerPrefs.HasKey("RaceCuldawn"))
        {
            RaceCuldawn();
        }

        FormaterCount(Mathf.Round(IncomPriece), UIManager.IncomePrice);
        FormaterCount(Mathf.Round(PartsPrize), UIManager.PartsPrice);
    }
    private void Update()
    {
        if (timespeed <= 0)
        {
            if (coefMnog > 1)
            {
                coefMnog = coefMnog - 1 * Time.deltaTime;
            }
        }
        else
        {
            if (coefMnog < 2)
            {
                coefMnog = coefMnog + 2f * Time.deltaTime;
            }
            timespeed = timespeed - Time.deltaTime;
        }

        money = money + (moneyInSecond * coefMnog * coefX2) * Time.deltaTime;
        money = Mathf.Clamp(money, 0, 1000000000000000000);
        PlayerPrefs.SetFloat("money", money);

        FormaterCount2(Mathf.Round(Mathf.Round(moneyInSecond * coefMnog * coefX2)), UIManager.MoneyInSecond);
        FormaterCount(Mathf.Round(money), UIManager.Money);

        if (AutoTapTme > 0)
        {
            AddSpeed();
            UIManager.SliderAutotap.value = AutoTapTme;
            AutoTapTme = AutoTapTme - Time.deltaTime;
        }

        if (IncomX2Tme > 0)
        {
            coefX2 = 2;
            IncomX2Tme = IncomX2Tme - Time.deltaTime;
            UIManager.SliderIncomX2.value = IncomX2Tme;
        }
        else
        {
            coefX2 = 1;
        }

        if (speed <= 0)
        {
            EventManager.DoAddSpeed(1);
            ParticleSystem.emissionRate = 0;
        }
        else
        {
            ParticleSystem.emissionRate = 3;
            speed = speed - Time.deltaTime;
        }

        if(PartsPrize + (PartsPrize * 0.1f) > money)
        {
            UIManager.BuyBlock.SetActive(true);
        }
        else
        {
            UIManager.BuyBlock.SetActive(false);
        }

        if (RaceTme > 0)
        {
            RaceTme = RaceTme - Time.deltaTime;
            UIManager.RaceTime.text = "0:" + Mathf.Round(RaceTme).ToString();
        }
        else
        {
            if (RaceTmeObject.activeSelf == true)
            {
                RaceTmeObject.SetActive(false);
                RaceTmeObject1.SetActive(true);
            }
        }
    }
    public void AddSpeed()
    {
        timespeed = coldawn;
        EventManager.DoAddSpeed(2.5f);
        speed = coefspeed;
    }
    public void SetRewardAutoTap()
    {
        AutoTapTme = AutoTapColdawn;
        EventManager.DoReward();
    }
    public void SetRewardIncomX2()
    {
        IncomX2Tme = IncomX2Coldawn;
        EventManager.DoReward();
    }
    public void AddMonneyInSecond()
    {
        if(IncomCount >= 4)
        {
            moneyInSecond = moneyInSecond + (moneyInSecond * 0.25f);
            moneyInSecond = Mathf.Clamp(moneyInSecond, 0, 1000000000000000000);
            PlayerPrefs.SetFloat("moneyInSecond", moneyInSecond);
            IncomCount = IncomCount - 4;
            EventManager.DuSetAvalebleIncpmMoney(IncomCount);
            IncomPriece = IncomPriece + (IncomPriece * 0.25f);
            IncomPriece = Mathf.Clamp(IncomPriece, 0, 1000000000000000000);
            PlayerPrefs.SetFloat("IncomPriece", IncomPriece);
            FormaterCount(Mathf.Round(IncomPriece), UIManager.IncomePrice); 
            AnimMoneyInSecond.Play();
        }
    }
    public void PrepeaToSale(bool isClick)
    {
        FormaterCount(Mathf.Round(PartsPrize / 2), UIManager.PartsSale);
    }
    public void Sale()
    {
        money = money + PartsPrize / 2;
        UIManager.SaleText.gameObject.GetComponent<Animation>().Play();
        FormaterCount1(Mathf.Round(PartsPrize/2), UIManager.SaleText);
    }
    public void SetBuyParts()
    {
        float Money = money - PartsPrize;

        if (Money >= 0 && PartsPositionController.TryParts())
        {
            PartsPrize = PartsPrize + (PartsPrize * 0.05f);
            PartsPrize = Mathf.Clamp(PartsPrize, 0, 1000000000000000000);
            PlayerPrefs.SetFloat("PartsPrize", PartsPrize);
            FormaterCount(Mathf.Round(PartsPrize), UIManager.PartsPrice);
            FormaterCount(Mathf.Round(PartsPrize), UIManager.PartsPriceBlock);
            money = money - PartsPrize;
            PartsPositionController.BuyParts(); 
            IncomCount++;
            EventManager.DuSetAvalebleIncpmMoney(IncomCount);
        }
    }
    public bool TryBuyBlocks(int Price)
    {
        if (money >= Price)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SetBuyBlocks(int Price)
    {
        money = money - Price;
    }
    private void RaceCuldawn()
    {
        RaceTmeObject.SetActive(true);
        RaceTmeObject1.SetActive(false);
        RaceTme = RaceColdawn;
        PlayerPrefs.DeleteKey("RaceCuldawn");
    }
    public void AddMoney()
    {
        money = money + 10000000000;
    }
    public void DeleteAll()
    {
        money = 150;
    }

    private void FormaterCount(float Value, TextMeshProUGUI TextValue)
    {
        if (Value >= 1000000000000000)
        {
            TextValue.text = "$" + (Value / 1000000000000000f).ToString("F1") + "Q";
        }
        else if (Value >= 1000000000000)
        {
            TextValue.text = "$" + (Value / 1000000000000f).ToString("F1") + "T";
        }
        else if (Value >= 1000000000)
        {
            TextValue.text = "$" + (Value / 1000000000f).ToString("F1") + "B";
        }
        else if (Value >= 1000000)
        {
            TextValue.text = "$" + (Value / 1000000f).ToString("F1") + "M";
        }
        else if (Value >= 1000)
        {
            TextValue.text = "$" + (Value / 1000f).ToString("F1") + "K";
        }
        else
        {
            TextValue.text = "$" + Value.ToString();
        }
    }
    private void FormaterCount1(float Value, TextMeshProUGUI TextValue)
    {
        if (Value >= 1000000000000000)
        {
            TextValue.text = "+$" + (Value / 1000000000f).ToString("F1") + "Q";
        }
        else if (Value >= 1000000000000)
        {
            TextValue.text = "+$" + (Value / 1000000000f).ToString("F1") + "T";
        }
        else if (Value >= 1000000000)
        {
            TextValue.text = "+$" + (Value / 1000000000f).ToString("F1") + "B";
        }
        else if (Value >= 1000000)
        {
            TextValue.text = "+$" + (Value / 1000000f).ToString("F1") + "M";
        }
        else if (Value >= 1000)
        {
            TextValue.text = "+$" + (Value / 1000f).ToString("F1") + "K";
        }
        else
        {
            TextValue.text = "+$" + Value.ToString();
        }
    }
    private void FormaterCount2(float Value, TextMeshProUGUI TextValue)
    {
        if(Value >= 1000000000000000)
        {
            TextValue.text = "+$" + (Value / 1000000000f).ToString("F1") + "Q/s";
        }
        else if(Value >= 1000000000000)
        {
            TextValue.text = "+$" + (Value / 1000000000f).ToString("F1") + "T/s";
        }
        else if(Value >= 1000000000)
        {
            TextValue.text = "+$" + (Value / 1000000000f).ToString("F1") + "B/s";
        }
        else if (Value >= 1000000)
        {
            TextValue.text = "+$" + (Value / 1000000f).ToString("F1") + "M/s";
        }
        else if (Value >= 1000)
        {
            TextValue.text = "+$" + (Value / 1000f).ToString("F1") + "K/s";
        }
        else
        {
            TextValue.text = "+$" + Value.ToString() + "/s";
        }
    }
}
