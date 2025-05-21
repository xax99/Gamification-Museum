using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson; // Importa esto para usar FirstPersonController

public class CubeTextureChanger : MonoBehaviour
{
    public Texture[] textures;
    public Camera cameraUtil;
    public FirstPersonController fpc; // NUEVO: referencia al controlador FPS

    private Renderer cubeRenderer;
    private int currentTextureIndex = 0;
    private static bool isCameraActive = false;

    private Camera mainCamera;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();

        if (textures.Length > 0)
            cubeRenderer.material.mainTexture = textures[currentTextureIndex];

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

        currentTextureIndex = (currentTextureIndex + 1) % textures.Length;
        cubeRenderer.material.mainTexture = textures[currentTextureIndex];
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
