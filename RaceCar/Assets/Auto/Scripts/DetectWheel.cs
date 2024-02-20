using UnityEngine;

public class DetectWheel : MonoBehaviour
{
    public Test Test;
    public EnemyRace EnemyRace;
    public bool IsRight;

    private void OnCollisionEnter(Collision collision)
    {
        if (IsRight)
        {
            if(Test != null)
                Test.bool1 = true;

            if (EnemyRace != null)
                EnemyRace.bool1 = true;
        }
        else
        {
            if (Test != null)
                Test.bool2 = true;

            if (EnemyRace != null)
                EnemyRace.bool2 = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (IsRight)
        {
            if (Test != null)
                Test.bool1 = false;

            if (EnemyRace != null)
                EnemyRace.bool1 = false;
        }
        else
        {
            if (Test != null)
                Test.bool1 = false;

            if (EnemyRace != null)
                EnemyRace.bool1 = false;
        }
    }
}
