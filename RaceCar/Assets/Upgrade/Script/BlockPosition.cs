using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class BlockPosition : MonoBehaviour
{
    private Animation block;
    public MoneyHandler MoneyHandler;

    public GameObject SpriteOpen;
    public GameObject PriceGameObject;
    public TextMeshProUGUI PriceTextUnloc;
    public TextMeshProUGUI PriceTextloc;
    private bool isOpen = false;

    public int alableCount;
    public int Price;

    public AudioSource Close;
    public AudioSource open;

    private void Awake()
    {
        block = GetComponent<Animation>();
        SpriteOpen.SetActive(false);
        PriceGameObject.SetActive(false);
    }
    private void OnEnable()
    {
        EventManager.MuteAudio += AudioMute;
        EventManager.PlayAudio += AudioPlay;
    }
    private void OnDisable()
    {
        EventManager.MuteAudio -= AudioMute;
        EventManager.PlayAudio -= AudioPlay;
    }
    private void Update()
    {
        if (!isOpen) return;

        PriceGameObject.SetActive(true);
        if (MoneyHandler.money > Price)
        {
            SpriteOpen.SetActive(true);
            PriceTextUnloc.gameObject.SetActive(true);
        }
        else
        {
            SpriteOpen.SetActive(false);
            PriceTextUnloc.gameObject.SetActive(false);
        }
    }
    public void Click()
    {
        if (isOpen)
        {
            if (MoneyHandler.TryBuyBlocks(Price))
            {
                Destroy(transform.parent.gameObject);
                PlayerPrefs.SetInt("alableCount", alableCount + 1);
                EventManager.DuavalableCount();
                MoneyHandler.SetBuyBlocks(Price);
                open.Play();
            }
            else
            {
                AnimPlay();
            }
        }
        else
        {
            Close.Play();
            AnimPlay();
        }
    }

    private void AnimPlay()
    {
        block.Play();
    }

    public void Open()
    {
        PriceGameObject.SetActive(true);
        FormaterCount(Price);
        isOpen = true;
    }
    private void FormaterCount(float Value)
    {
        if (Value >= 1000000000000000)
        {
            PriceTextUnloc.text = "$" + (Value / 1000000000000000f).ToString("F1") + "Q";
            PriceTextloc.text = "$" + (Value / 1000000000000000f).ToString("F1") + "Q";
        }
        else if (Value >= 1000000000000)
        {
            PriceTextUnloc.text = "$" + (Value / 1000000000000f).ToString("F1") + "T";
            PriceTextloc.text = "$" + (Value / 1000000000000f).ToString("F1") + "T";
        }
        else if (Value >= 1000000000)
        {
            PriceTextUnloc.text = "$" + (Value / 1000000000f).ToString("F1") + "B";
            PriceTextloc.text = "$" + (Value / 1000000000f).ToString("F1") + "B";
        }
        else if (Value >= 1000000)
        {
            PriceTextUnloc.text = "$" + (Value / 1000000f).ToString("F1") + "M";
            PriceTextloc.text = "$" + (Value / 1000000f).ToString("F1") + "M";
        }
        else if (Value >= 1000)
        {
            PriceTextUnloc.text = "$" + (Value / 1000f).ToString("F1") + "K";
            PriceTextloc.text = "$" + (Value / 1000f).ToString("F1") + "K";
        }
        else
        {
            PriceTextUnloc.text = "$" + Value.ToString();
            PriceTextloc.text = "$" + Value.ToString();
        }
    }
    public void AudioMute()
    {
        Close.mute = true;
        open.mute = true;
    }
    public void AudioPlay()
    {
        Close.mute = false;
        open.mute = false;
    }
}
