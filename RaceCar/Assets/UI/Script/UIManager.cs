using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject SaleButtonTrue;
    public GameObject SaleButtonFalse;
    public TextMeshProUGUI Money;
    public TextMeshProUGUI MoneyInSecond;
    public TextMeshProUGUI PartsPrice;
    public TextMeshProUGUI PartsSale;
    public Slider SliderAutotap;
    public Slider SliderIncomX2;

    private void OnEnable()
    {
        EventManager.OnClickDown += OnclickDown;
    }
    private void OnDisable()
    {
        EventManager.OnClickDown += OnclickDown;
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
}
