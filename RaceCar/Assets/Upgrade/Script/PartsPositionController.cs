using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsPositionController : MonoBehaviour
{
    private RaycastHit hit;
    private GameObject Mediate;
    private Ray ray;
    private GameObject startMediate;
    public GameObject[] Parts;
    public GameObject[] PositionArray;

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        if (Mediate != null)
            Mediate.transform.position = hit.point;
    }
    public void OnClickDown()
    {
        if (hit.transform != null && hit.transform.gameObject.layer == 3)
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
        EventManager.DuOnClickDown(true);
    }
    public void OnClickUp()
    {
        if(hit.transform != null)
        {
            if (hit.transform.gameObject.layer == 3)
            {
                Position MediatePosition = hit.transform.GetComponent<Position>();

                if (MediatePosition.Parts == null)
                {
                    if (Mediate != null)
                    {
                        Mediate.transform.position = hit.transform.position;
                        Mediate.transform.parent = hit.transform;
                        MediatePosition.Parts = Mediate.transform;
                        Mediate = null;
                    }
                }
                else
                {
                    if (Mediate != null)
                    {
                        if(Mediate.GetComponent<PartsUpgrade>().ID == MediatePosition.Parts.gameObject.GetComponent<PartsUpgrade>().ID &&
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

                        Mediate = null;
                    }
                }
            }
            else if (hit.transform.gameObject.layer == 6)
            {
                if (Mediate != null)
                {
                    Mediate.GetComponent<PartsUpgrade>().UpgradeAuto();
                    Mediate = null;
                }
            }
            else if (hit.transform.gameObject.layer == 7)
            {
                if (Mediate != null)
                {
                    Mediate.GetComponent<PartsUpgrade>().Buy();
                    Mediate = null;
                }
            }
            else
            {
                Mediate.transform.position = startMediate.transform.position;
                Mediate.transform.parent = startMediate.transform;
                startMediate.GetComponent<Position>().Parts = Mediate.transform;
                Mediate = null;
            }
        }
        startMediate = null;
        EventManager.DuOnClickDown(false);
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
}
