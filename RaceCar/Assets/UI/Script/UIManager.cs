using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject SaleButtonTrue;
    public GameObject SaleButtonFalse;
    public GameObject Income;
    public TextMeshProUGUI IncomePrice;
    public TextMeshProUGUI Money;
    public TextMeshProUGUI MoneyInSecond;
    public TextMeshProUGUI PartsPrice;
    public TextMeshProUGUI PartsSale;
    public Slider SliderAutotap;
    public Slider SliderIncomX2;

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

    private void OnclickDown(bool isClick)
    {
        if (isClick)
        {
            SaleButtonFalse.SetActive(true);
            SaleButtonTrue.SetActive(false);
        }
        else
        {
            SaleButtonFalse.SetActive(false);
            SaleButtonTrue.SetActive(true);
        }
    }
    private void AvalebleIncpmMoney(float AvalableCount)
    {
        Debug.Log(1);
        if (AvalableCount >= 4)
        {
            Income.SetActive(false);
        }
        else
        {
            Income.SetActive(true);
        }
    }
}
