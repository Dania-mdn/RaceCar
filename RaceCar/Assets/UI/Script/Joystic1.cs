using UnityEngine;

public class Joystic1 : MonoBehaviour
{
    public GameObject touchMarker;
    public GameObject Rull;

    Vector3 target_vector;

    public Test autoController;

    void Update()
    {
        if (autoController == null) return;

        Vector3 touch_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target_vector = touch_pos - transform.position;

        if (touchMarker.gameObject.activeSelf == true)
        {
            if (target_vector.magnitude < 39.1f)
            {
                Vector3 direction = touch_pos - transform.localPosition;
                touchMarker.transform.position = transform.localPosition + direction;
                touchMarker.transform.localPosition = new Vector3(touchMarker.transform.localPosition.x, touchMarker.transform.localPosition.y, 0).normalized * 105;

                Vector3 inputDirection = touchMarker.transform.localPosition - transform.localPosition;
                float _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg;
                touchMarker.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -_targetRotation);
                Rull.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -_targetRotation);

                autoController.direction = _targetRotation - 50;
            }
            else
            {
                Vector3 direction = touch_pos - transform.localPosition;
                touchMarker.transform.position = transform.localPosition + direction;
                touchMarker.transform.localPosition = new Vector3(touchMarker.transform.localPosition.x, touchMarker.transform.localPosition.y, 0).normalized * 225;

                Vector3 inputDirection = touchMarker.transform.localPosition - transform.localPosition;
                float _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg;
                touchMarker.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -_targetRotation);
                Rull.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -_targetRotation);

                autoController.direction = _targetRotation - 50;
                autoController.Force();
            }
        }
    }
}
