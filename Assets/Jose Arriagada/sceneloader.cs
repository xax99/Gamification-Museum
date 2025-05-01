using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
   
    private void Start()
    {
        // Cargar la escena "Noradus" de forma aditiva
        SceneManager.LoadScene("Noradus", LoadSceneMode.Additive);
        SceneManager.LoadScene("Wall", LoadSceneMode.Additive);
        SceneManager.LoadScene("EchmiyadzinAlly", LoadSceneMode.Additive);
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
