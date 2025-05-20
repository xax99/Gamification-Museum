/*using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject mobileControls; // Asigna aquí el contenedor de los joysticks

    private Camera mainCamera;
    private CharacterController controller;
    private Vector2 moveInput;
    private bool isMobile;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        mainCamera = Camera.main;

        isMobile = Application.isMobilePlatform;

        if (isMobile)
        {
            if (mobileControls != null)
                mobileControls.SetActive(true);
        }
        else
        {
            // Bloquear cursor solo en PC
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (mobileControls != null)
                mobileControls.SetActive(false);
        }
    }

    private void Update()
    {
        // Movimiento
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (!isMobile)
        {
            // Solo en PC: rotar hacia el mouse
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (groundPlane.Raycast(ray, out float enter))
            {
                Vector3 hitPoint = ray.GetPoint(enter);
                Vector3 lookDir = hitPoint - transform.position;
                lookDir.y = 0f;
                if (lookDir != Vector3.zero)
                    transform.rotation = Quaternion.LookRotation(lookDir);
            }

            // Salir con escape
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
*/