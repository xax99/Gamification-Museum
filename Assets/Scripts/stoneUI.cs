using UnityEngine;
using UnityEngine.UI; // o TMPro si usas TextMeshPro
using TMPro;

public class StoneUI : MonoBehaviour
{
    public TMP_Text stoneCounterText; // o public TMP_Text si usas TextMeshPro

    void Update()
    {
        stoneCounterText.text = $"{Stone.collectedStones}/{Stone.totalStones} pieces";
    }
}
