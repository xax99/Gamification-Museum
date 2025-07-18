using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFilter : MonoBehaviour
{
    public List<GameObject> parentObjects; // Padres que contienen varios sub-objetos

    // Aplica un color uniforme a todos los hijos con Renderer
    public void ApplyUniformColor(Color filterColor)
    {
        foreach (GameObject parent in parentObjects)
        {
            // Recorre todos los Renderers en este padre y sus hijos
            Renderer[] renderers = parent.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
                renderer.material.color = filterColor;
            }
        }
    }
}
