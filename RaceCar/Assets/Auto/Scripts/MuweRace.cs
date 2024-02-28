using UnityEngine;

public class MuweRace : MonoBehaviour
{
    public GameObject frontLeftMesh;
    [Space(10)]
    public GameObject frontRightMesh;
    [Space(10)]
    public GameObject rearLeftMesh;
    [Space(10)]
    public GameObject rearRightMesh;
    void Update()
    {

        frontLeftMesh.transform.Rotate(Vector3.right * 500 * Time.deltaTime);
        frontRightMesh.transform.Rotate(-Vector3.left * 500 * Time.deltaTime);
        rearLeftMesh.transform.Rotate(Vector3.right * 500 * Time.deltaTime);
        rearRightMesh.transform.Rotate(-Vector3.left * 500 * Time.deltaTime);
    }
}
