using UnityEngine;

public class MainJoystic : MonoBehaviour
{
    public GameObject joisticMarcer;
    public GameObject DirectionMarcer;

    private void Start()
    {
        joisticMarcer.gameObject.SetActive(false);
        DirectionMarcer.gameObject.SetActive(false);
    }
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            joisticMarcer.gameObject.SetActive(true);
            DirectionMarcer.gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            joisticMarcer.gameObject.SetActive(false);
            DirectionMarcer.gameObject.SetActive(false);
        }
    }
}
