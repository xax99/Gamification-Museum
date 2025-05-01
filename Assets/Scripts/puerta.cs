using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cambiar de escena

public class Door : MonoBehaviour
{
    private bool isPlayerNearby = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.Q))
        {
            if (Stone.collectedStones >= Stone.totalStones) 
            {
                Debug.Log("✅ Todas las piedras recolectadas. Cambiando de escena...");
                SceneManager.LoadScene("inside_church"); // Reemplaza con el nombre real de la escena
            }
            else
            {
                Debug.Log("❌ Todavía no tienes todas las piedras.");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
