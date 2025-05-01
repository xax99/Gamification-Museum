using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFilter : MonoBehaviour
{
    public List<GameObject> targetCubes; // Lista de cubos que recibirán el filtro

    // Aplica un color uniforme a todos los cubos
    public void ApplyUniformColor(Color filterColor)
    {
        foreach (GameObject cube in targetCubes)
        {
            Renderer renderer = cube.GetComponent<Renderer>();
            if (renderer != null)
            {
                // Si hay una textura, la reemplazamos para darle un color uniforme
                if (renderer.material.mainTexture != null)
                {
                    // Establecemos el color en todo el material
                    renderer.material.color = filterColor;
                }
                else
                {
                    // Si no hay textura, simplemente cambiamos el color del material
                    renderer.material.color = filterColor;
                }
            }
        }
    }
}
