using UnityEngine;

public class SimpleJoystickMovement : MonoBehaviour
{
    //public GameObject moveJoystickObject;  // GameObject padre del joystick de movimiento
    public GameObject JoystickObject;  // GameObject padre del joystick de rotación

    public VariableJoystick moveJoystick;
    public VariableJoystick lookJoystick;
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Activar o desactivar joysticks según la plataforma
        bool isMobile = Application.isMobilePlatform;

        JoystickObject.SetActive(isMobile);
    }

    void Update()
    {
        if (!Application.isMobilePlatform)
            return; // No hagas nada si no es móvil

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
