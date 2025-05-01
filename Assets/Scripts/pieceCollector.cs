using UnityEngine;

public class Stone : MonoBehaviour
{
    public static int collectedStones = 0;
    public static int totalStones = 4;

    private bool isPlayerNearby = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.Q))
        {
            collectedStones++;
            Debug.Log($"[STONE] Piedra recogida. Total: {collectedStones}/{totalStones}");
            gameObject.SetActive(false);
            if (collectedStones >= totalStones)
            {
                Debug.Log("🔓 La puerta se ha abierto.");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[STONE] Trigger ENTER con: {other.name}");

        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("[STONE] Jugador cerca. Presiona Q para recoger.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log($"[STONE] Trigger EXIT con: {other.name}");

        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
