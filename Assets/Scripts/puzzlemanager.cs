using UnityEngine;

public class PuzzleDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    void OnMouseDown()
    {
        Vector3 mousePosition = Input.mousePosition;
        offset = transform.position - new Vector3(mousePosition.x, mousePosition.y, 0);
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Input.mousePosition;
            transform.position = (new Vector3(mousePosition.x, mousePosition.y, 0) + offset);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}
