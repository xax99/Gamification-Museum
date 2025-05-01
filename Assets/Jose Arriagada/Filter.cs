using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterCube : MonoBehaviour
{
    public Color filterColor; // Color que este cubo aplicará
    public GameObject targetCube; // Objeto con el script ColorFilter

    void OnMouseDown()
    {
        // Llama al método ApplyFilter del script ColorFilter
        if (targetCube != null)
        {
            targetCube.GetComponent<ColorFilter>().ApplyUniformColor(filterColor);
        }
    }
}
