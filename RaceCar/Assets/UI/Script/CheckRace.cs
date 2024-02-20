using UnityEngine;

public class CheckRace : MonoBehaviour
{
    public RaceManager RaceManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            RaceManager.isCheckRacePlayer = true;
        }
        else if (other.gameObject.layer == 11)
        {
            RaceManager.isCheckRaceEnemy = true;
        }
    }
}
