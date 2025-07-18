using UnityEngine;

public class PieceMover : MonoBehaviour
{
    [Header("Parámetros configurables")]
    public Camera raycastCamera;
    public GameObject raycastPlane;
    public Vector3 correctPosition;
    public float snapThreshold = 0.5f;

    private bool isDragging = false;
    private Vector3 offset;
    private float fixedX;
    private int planeLayer;

    void Start()
    {
        // Guardar el layer del plano
        planeLayer = raycastPlane.layer;
    }

    void Update()
    {
        if (raycastCamera == null || raycastPlane == null)
            return;

        // Presionar mouse
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = raycastCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform == transform)
            {
                isDragging = true;
                fixedX = transform.position.x;
                offset = transform.position - hit.point;
            }
        }

        // Mientras arrastras
        if (isDragging && Input.GetMouseButton(0))
        {
            Ray ray = raycastCamera.ScreenPointToRay(Input.mousePosition);

            // Hacer raycast solo contra el layer del plano
            int mask = 1 << planeLayer;

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, mask))
            {
                Vector3 target = hit.point + offset;
                target.x = fixedX;
                transform.position = target; // usar directamente, sin Lerp
            }
        }

        // Soltar mouse
        if (isDragging && Input.GetMouseButtonUp(0))
        {
            float dist = Vector3.Distance(transform.localPosition, correctPosition);
            if (dist <= snapThreshold)
            {
                transform.localPosition = correctPosition;

                Collider col = GetComponent<Collider>();
                if (col != null)
                {
                    col.enabled = false;
                }
            }

            isDragging = false;
        }
    }
}
