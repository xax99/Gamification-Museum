using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text messageText; // Texto en pantalla

    void Awake()
    {
        Instance = this;
        messageText.gameObject.SetActive(false); // Ocultar al inicio
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
    }

    public void HideMessage()
    {
        messageText.gameObject.SetActive(false);
    }
}
