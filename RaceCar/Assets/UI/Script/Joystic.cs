using UnityEngine;

public class Joystic : MonoBehaviour
{
    public GameObject touchMarker;

    public GameObject up;
    public float _rotationVelocity = 5;

    Vector3 target_vector;

    public AutoController autoController;

    void Update()
    {
        Vector3 touch_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target_vector = touch_pos - transform.position;
        if (target_vector.magnitude < 30)
        {
            touchMarker.transform.position = transform.position + (touch_pos - transform.position).normalized * 1;
            Vector3 inputDirection = touchMarker.transform.localPosition - transform.localPosition;
            float _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg;

            autoController.direction = _targetRotation;
            up.transform.rotation = Quaternion.Euler(0.0f, _targetRotation, 0.0f);
        }
    }
}
