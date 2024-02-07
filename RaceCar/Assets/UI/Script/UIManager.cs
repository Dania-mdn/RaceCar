using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Purchasing;
using Unity.VisualScripting;

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

    public TextMeshProUGUI RaceTime;

    public TextMeshProUGUI SaleText;
    public TextMeshProUGUI RaceText;

    public Toggle TogglAudio;
    private bool isMuteAudio;
    public AudioSource A0;
    public AudioSource A1;

    private void OnEnable()
    {
        EventManager.OnClickDown += OnclickDown;
        EventManager.SetAvalebleIncpmMoney += AvalebleIncpmMoney;
        EventManager.MuteAudio += AudioMute;
        EventManager.PlayAudio += AudioPlay;
    }
    private void OnDisable()
    {
        EventManager.OnClickDown -= OnclickDown;
        EventManager.SetAvalebleIncpmMoney -= AvalebleIncpmMoney;
        EventManager.MuteAudio -= AudioMute;
        EventManager.PlayAudio -= AudioPlay;
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("MuteAudio"))
            TogglAudio.isOn = true;
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
    public void Audio()
    {
        if (isMuteAudio == false)
        {
            isMuteAudio = true;
            EventManager.DoMuteAudio();
            PlayerPrefs.SetInt("MuteAudio", 1);
        }
        else
        {
            isMuteAudio = false;
            EventManager.DoPlayAudio();
            PlayerPrefs.DeleteKey("MuteAudio");
        }
    }
    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        EventManager.DoDeleteAll();
    }
    public void AudioMute()
    {
        A0.mute = true;
        A1.mute = true;
    }
    public void AudioPlay()
    {
        A0.mute = false;
        A1.mute = false;
    }
}
