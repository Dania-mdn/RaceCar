using UnityEngine;

public class MainJoystic : MonoBehaviour
{
    public Joystic joistic;

    private void Start()
    {
        joistic.gameObject.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            joistic.gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            joistic.gameObject.SetActive(false);
        }
    }
}
