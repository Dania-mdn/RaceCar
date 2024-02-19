using PathCreation.Examples;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EventManager: MonoBehaviour
{
    public static event Action<int, int> UpgradeAuto;
    public static event Action<bool> OnClickDown;
    public static event Action Sale;
    public static event Action<float> SetAvalebleIncpmMoney;
    public static event Action avalableCount;
    public static event Action<float> AddSpeed;
    public static event Action<float> Upgrade;
    public static event Action PartsUpgrade;
    public static event Action DeleteAll;
    public static event Action MuteAudio;
    public static event Action PlayAudio;
    public static event Action ShowAdd;
    public static event Action Reward;
    public static void DuUpgradeAuto(int ID, int lvl)
    {
        UpgradeAuto?.Invoke(ID, lvl);
    }
    public static void DuOnClickDown(bool isClick)
    {
        OnClickDown?.Invoke(isClick);
    }
    public static void DuSale()
    {
        Sale?.Invoke();
    }
    public static void DuSetAvalebleIncpmMoney(float count)
    {
        SetAvalebleIncpmMoney?.Invoke(count);
    }
    public static void DuavalableCount()
    {
        avalableCount?.Invoke();
    }
    public static void DoAddSpeed(float speed)
    {
        AddSpeed?.Invoke(speed);
    }
    public static void DoUpgrade(float speed)
    {
        Upgrade?.Invoke(speed);
    }
    public static void DoPartsUpgrade()
    {
        PartsUpgrade?.Invoke();
    }
    public static void DoDeleteAll()
    {
        DeleteAll?.Invoke();
    }
    public static void DoMuteAudio()
    {
        MuteAudio?.Invoke();
    }
    public static void DoPlayAudio()
    {
        PlayAudio?.Invoke();
    }
    public static void DoShowAdd()
    {
        ShowAdd?.Invoke();
    }
    public static void DoReward()
    {
        Reward?.Invoke();
    }
}
