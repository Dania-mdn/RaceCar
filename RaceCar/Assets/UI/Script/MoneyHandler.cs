using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyHandler : MonoBehaviour
{
    public UIManager UIManager;
    public PartsPositionController PartsPositionController;
    public float money;
    private float moneyInSecond = 5;
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

    private float IncomPriece = 100;
    private float PartsPrize = 100;

    private void OnEnable()
    {
        EventManager.OnClickDown += PrepeaToSale;
        EventManager.Sale += Sale;
    }
    private void OnDisable()
    {
        EventManager.OnClickDown -= PrepeaToSale;
        EventManager.Sale -= Sale;
    }
    private void Start()
    {

        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetFloat("money");
        }

        if (PlayerPrefs.HasKey("PartsPrize"))
        {
            PartsPrize = PlayerPrefs.GetFloat("PartsPrize");
        }
        else
        {
            PlayerPrefs.SetFloat("PartsPrize", PartsPrize);
        }


        if (PlayerPrefs.HasKey("IncomPriece"))
        {
            IncomPriece = PlayerPrefs.GetFloat("IncomPriece");
        }
        else
        {
            PlayerPrefs.SetFloat("IncomPriece", PartsPrize);
        }

        FormaterCount(IncomPriece, UIManager.IncomePrice);
        FormaterCount(PartsPrize, UIManager.PartsPrice);
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
        PlayerPrefs.SetFloat("money", money);

        FormaterCount(Mathf.Round(moneyInSecond * coefMnog * coefX2), UIManager.MoneyInSecond);
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
        }
        else
        {
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
    }
    public void SetRewardIncomX2()
    {
        IncomX2Tme = IncomX2Coldawn;
    }
    public void AddMonneyInSecond()
    {
        if(IncomCount >= 4)
        {
            moneyInSecond = moneyInSecond + (moneyInSecond * 0.5f);
            IncomCount = IncomCount - 4;
            EventManager.DuSetAvalebleIncpmMoney(IncomCount);
            IncomPriece = IncomPriece + (IncomPriece * 0.5f);
            PlayerPrefs.SetFloat("IncomPriece", IncomPriece);
            FormaterCount(IncomPriece, UIManager.IncomePrice);
        }
    }
    public void PrepeaToSale(bool isClick)
    {
        FormaterCount(Mathf.Round(PartsPrize / 2), UIManager.PartsSale);
    }
    public void Sale()
    {
        money = money + PartsPrize / 2;
    }
    public void SetBuyParts()
    {
        float Money = money - (PartsPrize + (PartsPrize * 0.1f));

        if (Money >= 0 && PartsPositionController.TryParts())
        {
            PartsPrize = PartsPrize + (PartsPrize * 0.1f);
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
    public void Race()
    {
        SceneManager.LoadScene(Random.Range(1, 3));
        PlayerPrefs.SetInt("Race", 1);
    }
    private void FormaterCount(float Value, TextMeshProUGUI TextValue)
    {
        if (Value >= 1000000000)
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
}
