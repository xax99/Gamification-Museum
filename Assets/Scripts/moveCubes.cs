using UnityEngine;

public class PieceMover : MonoBehaviour
{
    private Vector3 offset;
    private bool isBeingHeld = false;
    private float constantZ;

    void Start()
    {
        // Guardar el valor de Z para mantenerlo constante
        constantZ = transform.position.z;
    }

    void Update()
    {
        if (isBeingHeld)
        {
            MovePieceWithMouse();
        }

        if (Input.GetMouseButtonUp(0) && isBeingHeld)
        {
            // Cuando sueltes la pieza, ajusta su posición al lugar más cercano en la cuadrícula
            Vector3 closestGridPos = GetClosestGridPosition(transform.position);
            transform.position = closestGridPos;
            isBeingHeld = false;
        }
    }

    void OnMouseDown()
    {
        // Calcular el offset de la pieza cuando se hace clic
        Vector3 mousePos = GetMouseWorldPosition();
        offset = new Vector3(mousePos.x - transform.position.x, mousePos.y - transform.position.y, 0); // Ignorar Z
        isBeingHeld = true;
    }

    void MovePieceWithMouse()
    {
        // Mover la pieza con el mouse solo en el plano XY
        Vector3 mousePos = GetMouseWorldPosition();
        transform.position = new Vector3(mousePos.x - offset.x, mousePos.y - offset.y, constantZ); // Mantener Z constante
    }

    Vector3 GetMouseWorldPosition()
    {
        // Obtener la posición del mouse en el mundo, manteniendo Z constante
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return Vector3.zero; // Si no se puede encontrar la posición, devolver 0
    }

    Vector3 GetClosestGridPosition(Vector3 piecePos)
    {
        // Ajustar la pieza al lugar más cercano en la cuadrícula
        float x = Mathf.Round(piecePos.x);
        float y = Mathf.Round(piecePos.y);
        return new Vector3(x, y, constantZ); // Mantener Z constante
    }
}
