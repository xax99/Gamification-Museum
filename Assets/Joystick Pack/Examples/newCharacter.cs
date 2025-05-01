using UnityEngine;

public class SimpleJoystickMovement : MonoBehaviour
{
    public VariableJoystick moveJoystick;   // Joystick para moverse
    public VariableJoystick lookJoystick;   // Joystick para rotar la cámara
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Movimiento
        float moveX = moveJoystick.Horizontal;
        float moveZ = moveJoystick.Vertical;
        Vector3 move = new Vector3(moveX, 0f, moveZ);
        move = transform.TransformDirection(move);
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Rotación (horizontal del segundo joystick)
        float lookX = lookJoystick.Horizontal;
        transform.Rotate(0f, lookX * rotationSpeed * Time.deltaTime, 0f);
    }
}
