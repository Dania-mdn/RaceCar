using UnityEngine;

public class MainJoystic : MonoBehaviour
{
    public GameObject joisticMarcer;
    public GameObject DirectionMarcer;

    //public AutoController autoController;

    private void Start()
    {
        joisticMarcer.gameObject.SetActive(false);
        DirectionMarcer.gameObject.SetActive(false);
    }
    public void Update()
    {
        //if (autoController == null) return;

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

        //if (joisticMarcer.gameObject.activeSelf == false)
        //{
        //    autoController.Handbrake();
        //}
        //else
        //{
        //    autoController.GoForward();
        //}
    }
}
