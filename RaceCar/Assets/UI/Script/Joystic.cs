using UnityEngine;

public class Joystic : MonoBehaviour
{
    public GameObject touchMarker;

    public float _rotationVelocity = 5;

    Vector3 target_vector;

    public AutoController autoController;

    void Update()
    {
        Vector3 touch_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target_vector = touch_pos - transform.position;
        if (target_vector.magnitude < 30)
        {
            autoController.GoForward();
            touchMarker.transform.position = transform.position + (touch_pos - transform.position).normalized * 8;
            Vector3 inputDirection = touchMarker.transform.localPosition - transform.localPosition;
            float _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg;

            autoController.direction = _targetRotation + 135;
            autoController.Turn();
        }
    }
}
