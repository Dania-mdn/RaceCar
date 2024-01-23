using UnityEngine;

public class Joystic : MonoBehaviour
{
    public GameObject touchMarker;

    Vector3 target_vector;

    public AutoController autoController;

    void Update()
    {
        Vector3 touch_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target_vector = touch_pos - transform.position;
        if (touchMarker.gameObject.activeSelf == true)
        {
            if (target_vector.magnitude < 22)
            {
                Vector3 direction = touch_pos - transform.localPosition;
                touchMarker.transform.position = transform.localPosition + direction;
                touchMarker.transform.localPosition = new Vector3(touchMarker.transform.localPosition.x, touchMarker.transform.localPosition.y, 0).normalized * 110;

                Vector3 inputDirection = touchMarker.transform.localPosition - transform.localPosition;
                float _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg;

                autoController.direction = _targetRotation + 135;
                autoController.Turn();
                autoController.isImpuls = false;
            }
            else
            {
                Vector3 direction = touch_pos - transform.localPosition;
                touchMarker.transform.position = transform.localPosition + direction;
                touchMarker.transform.localPosition = new Vector3(touchMarker.transform.localPosition.x, touchMarker.transform.localPosition.y, 0).normalized * 200;

                Vector3 inputDirection = touchMarker.transform.localPosition - transform.localPosition;
                float _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg;

                autoController.direction = _targetRotation + 135;
                autoController.Turn();
                autoController.Force();
            }
        }
    }
}
