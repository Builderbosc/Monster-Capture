using UnityEngine;
using UnityEngine.InputSystem;

public class CameraOrbit : MonoBehaviour
{
    public float rotationsSpeed = 90f;
    public float distance = 5f;
    public float yPosOffset;

    private Vector2 orbitAngles = new Vector2(45f, 0);
    private Vector2 input;

    public Transform focus;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnLook(InputValue value)
    {
        input.x = value.Get <Vector2>().y;
        input.y = value.Get<Vector2>().x;
    }

    bool ManualRotation()
    {
        float deadzone = 0.01f;
        if(input.magnitude > deadzone)
        {
            orbitAngles += input * rotationsSpeed * Time.unscaledDeltaTime;
            return true;
        }

        return false;
    }

    private void LateUpdate()
    {
        Quaternion lookRotation = transform.localRotation;

        if(ManualRotation())
        {
            orbitAngles.x = Mathf.Clamp(orbitAngles.x, -75f, 75f);
            lookRotation = Quaternion.Euler(orbitAngles);
        }

        Vector3 lookDirection = lookRotation * Vector3.forward;
        Vector3 lookPosition = focus.position - lookDirection * distance;
        lookPosition = new Vector3(lookPosition.x, lookPosition.y + yPosOffset, lookPosition.z);

        transform.SetPositionAndRotation(lookPosition, lookRotation);

    }
}
