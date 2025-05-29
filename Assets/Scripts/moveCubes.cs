using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class PieceMover : MonoBehaviour
{
    public Vector3 correctPosition;            // Posición LOCAL relativa al padre
    public float snapThreshold = 0.5f;
    public Camera cameraUtil;
    public FirstPersonController fpc;
    private Vector3 offset;
    private bool isBeingHeld = false;
    private float constantX;
    private static bool isCameraActive = false;
    private Camera mainCamera;


    void Start()
    {
        constantX = transform.position.x;
        mainCamera = Camera.main;

        if (cameraUtil != null)
            cameraUtil.gameObject.SetActive(false);

        // Buscar el FirstPersonController automáticamente si no está asignado
        if (fpc == null)
        {
            fpc = FindObjectOfType<FirstPersonController>();
            if (fpc == null)
            {
                Debug.LogWarning("No se encontró un FirstPersonController en la escena.");
            }
        }
    }

    void Update()
    {
        if (isBeingHeld)
            MovePieceWithMouse();

        if (Input.GetMouseButtonUp(0) && isBeingHeld)
        {
            // Convertir posición local deseada a posición global
            Vector3 worldCorrectPos = transform.parent != null ?
                transform.parent.TransformPoint(correctPosition) :
                correctPosition;

            // Comparar posición actual con la posición objetivo global
            float dist = Vector3.Distance(transform.position, worldCorrectPos);
            Debug.Log("Distancia: " + dist);

            if (dist <= snapThreshold)
            {
                transform.position = worldCorrectPos;
                Debug.Log("¡Pieza encajada!");
            }

            isBeingHeld = false;
        }
    }

    void OnMouseDown()
    {
        if (!isCameraActive)
        {
            if (cameraUtil != null && mainCamera != null)
            {
                cameraUtil.gameObject.SetActive(true);
                mainCamera.gameObject.SetActive(false);
                isCameraActive = true;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                if (fpc != null)
                    fpc.enabled = false; // NUEVO: desactiva el control FPS
            }
            return;
        }

        Vector3 mousePos = GetMouseWorldPosition();
        offset = new Vector3(0, mousePos.y - transform.position.y, mousePos.z - transform.position.z);
        isBeingHeld = true;
    }

    void MovePieceWithMouse()
    {
        Vector3 mousePos = GetMouseWorldPosition();
        transform.position = new Vector3(constantX, mousePos.y - offset.y, mousePos.z - offset.z);
    }

    Vector3 GetMouseWorldPosition()
    {
        Camera camToUse = isCameraActive ? cameraUtil : mainCamera;

        Ray ray = camToUse.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }

    public void ResetToMainCamera()
    {
        if (cameraUtil != null && mainCamera != null)
        {
            cameraUtil.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
            isCameraActive = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (fpc != null)
                fpc.enabled = true; // NUEVO: reactiva el control FPS
        }
    }
}
