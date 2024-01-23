using UnityEngine;

public class MainJoystic : MonoBehaviour
{
    public GameObject joisticMarcer;

    public AutoController autoController;

    private void Start()
    {
        joisticMarcer.gameObject.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            joisticMarcer.gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            joisticMarcer.gameObject.SetActive(false);
        }

        if(joisticMarcer.gameObject.activeSelf == false)
        {
            autoController.Handbrake();
        }
        else
        {
            autoController.GoForward();
        }
    }
}
