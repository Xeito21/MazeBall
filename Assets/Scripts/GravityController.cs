using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] private float acceleration = 9.8f;

    private Quaternion gravityOffset = Quaternion.identity;
    private bool isActive = true;

    private void Start()
    {
        if (SystemInfo.supportsGyroscope)
            Input.gyro.enabled = true;
    }

    private void Update()
    {
        Physics.gravity = isActive ? gravityOffset * GravityFromSensor() : Vector3.zero;
    }

    public void CalibrateGravity()
    {
        gravityOffset = Quaternion.FromToRotation(GravityFromSensor(), Vector3.down * acceleration);
    }

    public Vector3 GravityFromSensor()
    {
        Vector3 gravity = Input.gyro.gravity != Vector3.zero ? Input.gyro.gravity * acceleration : Input.acceleration * acceleration;
        gravity.z = Mathf.Clamp(gravity.z, float.MinValue, -1f);
        return new Vector3(gravity.x, gravity.z, gravity.y);
    }

    public void SetActive(bool value)
    {
        isActive = value;
    }
}
