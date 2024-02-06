using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PartsUpgrade : MonoBehaviour
{
    public int ID;
    public int lvl;
    public float Priece;
    public Transform Mesh;
    public GameObject[] MeshLvl;

    public TextMeshProUGUI TMPlvl;

    private void Awake()
    {
        TMPlvl.text = lvl.ToString();

        int childCount = Mesh.childCount;
        MeshLvl = new GameObject[childCount];

        for (int i = 0; i < childCount; i++)
        {
            MeshLvl[i] = Mesh.GetChild(i).gameObject;
        }
    }
    public void Sale()
    {
        Destroy(gameObject);
        EventManager.DuSale();
    }
    public void UpgradeLvL()
    {
        EventManager.DoPartsUpgrade();

        if (lvl + 1 > MeshLvl.Length) return;

        lvl++;
        SetLvL(lvl);
    }
    public void SetLvL(int LVL)
    {
        lvl = LVL;
        TMPlvl.text = lvl.ToString();

        for (int i = 0; i < MeshLvl.Length; i++)
        {
            if (i == lvl - 1)
            {
                MeshLvl[i].gameObject.SetActive(true);
            }
            else
            {
                MeshLvl[i].gameObject.SetActive(false);
            }
        }
    }
}
