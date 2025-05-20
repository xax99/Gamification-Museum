/*
    MainMenuScript.cs
    
    @author Gabriel Azócar Cárcamo <azocarcarcamo@gmail.com>
 */

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //public GameObject enterScreen;
    //public GameObject loadScreen;
    private StoneService stoneService;
    public GameObject credits;
    private bool creditShow = false;
    // Use this for initialization
    public void OpenCredits(String name)
    {
        creditShow = !creditShow;
        credits.SetActive(creditShow);
    }
    public void Exit()
    {
        Application.Quit();
    }
    
}
