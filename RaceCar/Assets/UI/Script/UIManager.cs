using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Image SaleButton;

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
            SaleButton.color = new Color(1f, 0f, 0f, 0.2f);
        }
        else
        {
            SaleButton.color = new Color(1f, 1f, 1f, 0.2f);
        }
    }
}
