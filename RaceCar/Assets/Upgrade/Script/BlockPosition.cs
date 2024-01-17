using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlockPosition : MonoBehaviour
{
    private Animation block;
    public MoneyHandler MoneyHandler;

    private SpriteRenderer SpriteRenderer;
    public Sprite SpriteUnlock;
    public GameObject PriceGameObject;
    public TextMeshProUGUI PriceText;
    private bool isOpen = false;

    public int alableCount;
    public int Price;

    private void Start()
    {
        block = GetComponent<Animation>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
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
            }
            else
            {
                AnimPlay();
            }
        }
        else
        {
            AnimPlay();
        }
    }

    private void AnimPlay()
    {
        block.Play();
    }

    public void Open()
    {
        SpriteRenderer.sprite = SpriteUnlock;
        PriceGameObject.SetActive(true);
        FormaterCount(Price);
        isOpen = true;
    }
    private void FormaterCount(float Value)
    {
        if (Value >= 1000000000)
        {
            PriceText.text = (Value / 1000000000f).ToString("F1") + "B";
        }
        else if (Value >= 1000000)
        {
            PriceText.text = (Value / 1000000f).ToString("F1") + "M";
        }
        else if (Value >= 1000)
        {
            PriceText.text = (Value / 1000f).ToString("F1") + "K";
        }
        else
        {
            PriceText.text = Value.ToString();
        }
    }
}
