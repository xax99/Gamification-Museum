using UnityEngine;

public class Door : MonoBehaviour
{
    private bool opened = false;

    void Update()
    {
        if (!opened && Stone.collectedStones >= Stone.totalStones)
        {
            Debug.Log("✅ Todas las piedras recolectadas. Puerta desaparece.");
            gameObject.SetActive(false);  // Desactiva la puerta
            opened = true;                // Para no repetir
        }
    }
}
