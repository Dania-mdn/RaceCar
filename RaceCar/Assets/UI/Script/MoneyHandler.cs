using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyHandler : MonoBehaviour
{
    public UIManager UIManager;
    public PartsPositionController PartsPositionController;
    private float money;
    private float moneyInSecond = 5;
    private float coldawn = 1;
    private float timespeed;
    private float coefMnog = 1;

    private float AutoTapColdawn = 60;
    private float AutoTapTme;

    private float IncomX2Coldawn = 60;
    private float IncomX2Tme;
    private int coefX2 = 1;

    private float IncomCount = 4;
    private float MoneyIncom;

    private float PartsPrize = 100;

    private void OnEnable()
    {
        EventManager.OnClickDown += PrepeaToSale;
        EventManager.Sale += Sale;
    }
    private void OnDisable()
    {
        EventManager.OnClickDown += PrepeaToSale;
        EventManager.Sale -= Sale;
    }
    private void Start()
    {
        UIManager.PartsPrice.text = PartsPrize.ToString();
    }
    private void Update()
    {
        if (timespeed <= 0)
        {
            if(coefMnog > 1)
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

        UIManager.MoneyInSecond.text = Mathf.Round(moneyInSecond * coefMnog * coefX2).ToString();
        UIManager.Money.text = Mathf.Round(money).ToString();

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
    }
    public void AddSpeed()
    {
        timespeed = coldawn;
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
        }
    }
    public void PrepeaToSale(bool isClick)
    {
        UIManager.PartsSale.text = Mathf.Round(PartsPrize / 2).ToString();
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
            UIManager.PartsPrice.text = Mathf.Round(PartsPrize).ToString();
            money = money - PartsPrize;
            PartsPositionController.BuyParts(); 
            IncomCount++;
        }
    }
    public void Race()
    {
        SceneManager.LoadScene(1);
    }
}
