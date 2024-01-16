using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<int, int> UpgradeAuto;
    public static event Action<bool> OnClickDown;
    public static event Action Sale;
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
}
