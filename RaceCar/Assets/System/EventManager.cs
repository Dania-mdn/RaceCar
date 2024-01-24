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
}
