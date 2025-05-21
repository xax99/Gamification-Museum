using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SimpleJoystickMovement : MonoBehaviour
{
    public GameObject JoystickObject;  // Joystick de rotación

    public VariableJoystick moveJoystick;
    public VariableJoystick lookJoystick;
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    public Transform cameraPivot;  // ← Agrega esto en el inspector

    private CharacterController controller;
    private float verticalRotation = 0f;
    private float verticalRotationLimit = 90f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        bool isMobile = Application.isMobilePlatform;

        JoystickObject.SetActive(isMobile);
        if (isMobile)
        {
            FirstPersonController controller = GetComponent<FirstPersonController>();
            controller.enabled = false;
        }
    }

    void Update()
    {
        if (!Application.isMobilePlatform)
            return;

        // Movimiento
        float moveX = moveJoystick.Horizontal;
        float moveZ = moveJoystick.Vertical;
        Vector3 move = new Vector3(moveX, 0f, moveZ);
        move = transform.TransformDirection(move);
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Rotación horizontal (jugador)
        float lookX = lookJoystick.Horizontal;
        transform.Rotate(0f, lookX * rotationSpeed * Time.deltaTime, 0f);

        // Rotación vertical (cámara)
        float lookY = lookJoystick.Vertical;
        verticalRotation -= lookY * rotationSpeed * Time.deltaTime; // Invertido: hacia arriba es negativo
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);

        cameraPivot.localEulerAngles = new Vector3(verticalRotation, 0f, 0f);
    }
}
