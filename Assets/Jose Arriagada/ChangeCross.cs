using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTextureChanger : MonoBehaviour
{
    public Texture[] textures; // Array de texturas (PNG) a usar
    private Renderer cubeRenderer;
    private int currentTextureIndex = 0;

    void Start()
    {
        // Obtén el Renderer del cubo
        cubeRenderer = GetComponent<Renderer>();

        // Asegúrate de que una textura inicial está asignada
        if (textures.Length > 0)
        {
            cubeRenderer.material.mainTexture = textures[currentTextureIndex];
        }
    }

    void OnMouseDown()
    {
        // Cambia al siguiente PNG en el array
        currentTextureIndex = (currentTextureIndex + 1) % textures.Length;

        // Asigna la nueva textura al material del cubo
        cubeRenderer.material.mainTexture = textures[currentTextureIndex];
    }
}
