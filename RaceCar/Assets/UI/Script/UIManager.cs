using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Purchasing;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI Money;
    public TextMeshProUGUI MoneyInSecond;

    public Slider SliderAutotap;
    public Slider SliderIncomX2;

    public GameObject Income;
    public TextMeshProUGUI IncomePrice;

    public GameObject SaleButtonFalse;
    public TextMeshProUGUI PartsSale;

    public TextMeshProUGUI PartsPrice;
    public GameObject BuyBlock;
    public TextMeshProUGUI PartsPriceBlock;

    public GameObject Race;

    private void OnEnable()
    {
        EventManager.OnClickDown += OnclickDown;
        EventManager.SetAvalebleIncpmMoney += AvalebleIncpmMoney;
    }
    private void OnDisable()
    {
        EventManager.OnClickDown += OnclickDown;
        EventManager.SetAvalebleIncpmMoney -= AvalebleIncpmMoney;
    }
    private void Start()
    {
        Race.SetActive(false);
    }
    private void OnclickDown(bool isClick)
    {
        if (isClick)
        {
            SaleButtonFalse.SetActive(true);
        }
        else
        {
            SaleButtonFalse.SetActive(false);
        }
    }
    private void AvalebleIncpmMoney(float AvalableCount)
    {
        if (AvalableCount >= 4)
        {
            Income.SetActive(false);
        }
        else
        {
            Income.SetActive(true);
        }
    }
    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
