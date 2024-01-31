using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PartsPositionController : MonoBehaviour
{
    private RaycastHit hit;
    private GameObject Mediate;
    private Ray ray;
    private GameObject startMediate;
    public PositionAuto PositionAuto;
    public GameObject[] Parts;
    public GameObject[] PositionArray;

    public GameObject[] BlockPositionArray;

    private void OnEnable()
    {
        EventManager.avalableCount += SetAvailableBlock; 
        load();
    }
    private void OnDisable()
    {
        EventManager.avalableCount -= SetAvailableBlock;
        Save();
    }
    
    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        if (Mediate != null)
            Mediate.transform.position = hit.point + Mediate.transform.up / 5;
    }
    public void OnClickDown()
    {
        if (hit.transform != null)
        {
            if (hit.transform.gameObject.layer == 3)
            {
                Position MediatePosition = hit.transform.GetComponent<Position>();

                if (MediatePosition.Parts != null)
                {
                    Mediate = MediatePosition.Parts.gameObject;
                    Mediate.transform.parent = null;
                    MediatePosition.Parts = null;
                    startMediate = hit.transform.gameObject;
                }
            }
            else if(hit.transform.gameObject.layer == 8)
            {
                hit.transform.GetChild(0).GetComponent<BlockPosition>().Click();
            }
        }

        if(Mediate != null)
            EventManager.DuOnClickDown(true);
    }
    public void OnClickUp()
    {
        if(hit.transform != null)
        {
            if (hit.transform.gameObject.layer == 3)
            {
                Position MediatePosition = hit.transform.GetComponent<Position>();

                if (Mediate != null)
                {
                    if (MediatePosition.Parts == null)
                    {
                        Mediate.transform.position = hit.transform.position;
                        Mediate.transform.parent = hit.transform;
                        MediatePosition.Parts = Mediate.transform;
                    }
                    else
                    {
                        if (Mediate.GetComponent<PartsUpgrade>().ID == MediatePosition.Parts.gameObject.GetComponent<PartsUpgrade>().ID &&
                            Mediate.GetComponent<PartsUpgrade>().lvl == MediatePosition.Parts.gameObject.GetComponent<PartsUpgrade>().lvl)
                        {
                            Destroy(MediatePosition.Parts.gameObject.GetComponent<PartsUpgrade>().gameObject);

                            Mediate.transform.position = hit.transform.position;
                            Mediate.transform.parent = hit.transform;
                            MediatePosition.Parts = Mediate.transform;

                            Mediate.GetComponent<PartsUpgrade>().UpgradeLvL();
                        }
                        else
                        {
                            MediatePosition.Parts.transform.position = startMediate.transform.position;
                            MediatePosition.Parts.transform.parent = startMediate.transform;
                            startMediate.GetComponent<Position>().Parts = MediatePosition.Parts;

                            Mediate.transform.position = hit.transform.position;
                            Mediate.transform.parent = hit.transform;
                            MediatePosition.Parts = Mediate.transform;
                        }
                    }
                }
            }
            else if (hit.transform.gameObject.layer == 7)
            {
                if (Mediate != null)
                {
                    Mediate.GetComponent<PartsUpgrade>().Sale();
                }
            }
            else if (hit.transform.gameObject.layer == 6)
            {
                PositionAuto MediatePosition = hit.transform.GetComponent<PositionAuto>();

                if (Mediate != null)
                {
                    if (MediatePosition.Parts[Mediate.GetComponent<PartsUpgrade>().ID] == null)
                    {
                        Mediate.transform.position = hit.transform.position;
                        Mediate.transform.parent = hit.transform;
                        MediatePosition.Parts[Mediate.GetComponent<PartsUpgrade>().ID] = Mediate.transform;
                    }
                    else
                    {
                        if (Mediate.GetComponent<PartsUpgrade>().ID == MediatePosition.Parts[Mediate.GetComponent<PartsUpgrade>().ID].gameObject.GetComponent<PartsUpgrade>().ID &&
                            Mediate.GetComponent<PartsUpgrade>().lvl == MediatePosition.Parts[Mediate.GetComponent<PartsUpgrade>().ID].gameObject.GetComponent<PartsUpgrade>().lvl)
                        {
                            Destroy(MediatePosition.Parts[Mediate.GetComponent<PartsUpgrade>().ID].gameObject.GetComponent<PartsUpgrade>().gameObject);

                            Mediate.transform.position = hit.transform.position;
                            Mediate.transform.parent = hit.transform;
                            MediatePosition.Parts[Mediate.GetComponent<PartsUpgrade>().ID] = Mediate.transform;

                            Mediate.GetComponent<PartsUpgrade>().UpgradeLvL();
                        }
                        else
                        {
                            MediatePosition.Parts[Mediate.GetComponent<PartsUpgrade>().ID].transform.position = startMediate.transform.position;
                            MediatePosition.Parts[Mediate.GetComponent<PartsUpgrade>().ID].transform.parent = startMediate.transform;
                            startMediate.GetComponent<Position>().Parts = MediatePosition.Parts[Mediate.GetComponent<PartsUpgrade>().ID];

                            Mediate.transform.position = hit.transform.position;
                            Mediate.transform.parent = hit.transform;
                            MediatePosition.Parts[Mediate.GetComponent<PartsUpgrade>().ID] = Mediate.transform;
                        }
                    }
                    EventManager.DuUpgradeAuto(Mediate.GetComponent<PartsUpgrade>().ID, Mediate.GetComponent<PartsUpgrade>().lvl);
                }
            }
            else
            {
                if (Mediate != null)
                {
                    Mediate.transform.position = startMediate.transform.position;
                    Mediate.transform.parent = startMediate.transform;
                    startMediate.GetComponent<Position>().Parts = Mediate.transform;
                }
            }

            Mediate = null;
        }
        startMediate = null;
        EventManager.DuOnClickDown(false);
    }
    public bool TryParts()
    {
        for (int i = 0; i < PositionArray.Length; i++)
        {
            if(PositionArray[i].transform.childCount == 0)
            {
                return true;
            }
        }
        return false;
    }
    public void BuyParts()
    {
        for (int i = 0; i < PositionArray.Length; i++)
        {
            if(PositionArray[i].transform.childCount == 0)
            {
                GameObject parts = Instantiate(Parts[Random.Range(0, 3)], PositionArray[i].transform.position, PositionArray[i].transform.rotation, PositionArray[i].transform);
                parts.transform.parent.GetComponent<Position>().Parts = parts.transform;
                break;
            }
        }
    }
    private void SetAvailableBlock()
    {
        int avalableCount = 0;
        avalableCount = PlayerPrefs.GetInt("alableCount"); 

        for (int i = 0; i <= avalableCount; i++)
        {
            if (i < avalableCount)
            {
                if (BlockPositionArray[i] != null)
                    Destroy(BlockPositionArray[i].gameObject);
            }
        }
        if (BlockPositionArray[avalableCount] != null)
        {
            BlockPositionArray[avalableCount].transform.GetChild(0).GetComponent<BlockPosition>().Open();
        }
    }
    private void Save()
    {
        for (int i = 0; i < PositionArray.Length; i++)
        {
            PlayerPrefs.DeleteKey(i + "i");
            PlayerPrefs.DeleteKey(i + "ID");
            PlayerPrefs.DeleteKey(i + "lvl");

            if (PositionArray[i].transform.GetComponent<Position>().Parts != null)

            if (PositionArray[i].transform.GetComponent<Position>().Parts.GetComponent<PartsUpgrade>() != null)
            {
                PartsUpgrade PartsUpgrade = PositionArray[i].transform.GetComponent<Position>().Parts.GetComponent<PartsUpgrade>();
                PlayerPrefs.SetInt(i + "i", i);
                PlayerPrefs.SetInt(i + "ID", PartsUpgrade.ID);
                PlayerPrefs.SetInt(i + "lvl", PartsUpgrade.lvl);
            }
        }

        for (int i = 0; i < PositionAuto.Parts.Length; i++)
        {
            PlayerPrefs.DeleteKey(i + "iAuto");
            PlayerPrefs.DeleteKey(i + "IDAuto");
            PlayerPrefs.DeleteKey(i + "lvlAuto");

            if (PositionAuto.Parts[i] != null)

            if (PositionAuto.Parts[i].GetComponent<PartsUpgrade>() != null)
            {
                PartsUpgrade PartsUpgrade = PositionAuto.Parts[i].GetComponent<PartsUpgrade>().GetComponent<PartsUpgrade>();
                PlayerPrefs.SetInt(i + "iAuto", i);
                PlayerPrefs.SetInt(i + "IDAuto", PartsUpgrade.ID);
                PlayerPrefs.SetInt(i + "lvlAuto", PartsUpgrade.lvl);
            }
        }
    }
    private void load()
    {
        SetAvailableBlock();

        for (int i = 0; i < PositionArray.Length; i++)
        {
            //if (PositionArray[i].transform.GetChild(0) != null) return;
            
            if (PlayerPrefs.HasKey(i + "i"))

            if (PlayerPrefs.GetInt(i + "i") == i)
            {
                GameObject parts = Instantiate(Parts[PlayerPrefs.GetInt(i + "ID")], PositionArray[i].transform.position, PositionArray[i].transform.rotation, PositionArray[i].transform);
                parts.transform.parent.GetComponent<Position>().Parts = parts.transform;
                parts.transform.parent.GetComponent<Position>().Parts.GetComponent<PartsUpgrade>().SetLvL(PlayerPrefs.GetInt(i + "lvl"));
            }
        }
        for (int i = 0; i < PositionAuto.Parts.Length; i++)
        {
            //if (PositionAuto.Parts[PlayerPrefs.GetInt(i + "iAuto")] != null) return;

            if (PlayerPrefs.HasKey(i + "iAuto"))

            if (PlayerPrefs.GetInt(i + "iAuto") == i)
            {
                GameObject parts = Instantiate(Parts[PlayerPrefs.GetInt(i + "IDAuto")], PositionAuto.transform.position, PositionAuto.transform.rotation, PositionArray[0].transform);
                parts.transform.parent = PositionAuto.transform;
                parts.transform.parent.GetComponent<PositionAuto>().Parts[PlayerPrefs.GetInt(i + "IDAuto")] = parts.transform;
                parts.transform.parent.GetComponent<PositionAuto>().Parts[PlayerPrefs.GetInt(i + "IDAuto")].GetComponent<PartsUpgrade>().SetLvL(PlayerPrefs.GetInt(i + "lvlAuto"));
            }
        }
    }
}
