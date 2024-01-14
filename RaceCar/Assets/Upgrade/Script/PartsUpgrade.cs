using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsUpgrade : MonoBehaviour
{
    public int ID;
    public int lvl;
    public float Priece;

    public void Buy()
    {
        Destroy(gameObject);
    }
    public void UpgradeAuto()
    {
        Destroy(gameObject);
    }
    public void UpgradeLvL()
    {
        lvl++;
    }
}
