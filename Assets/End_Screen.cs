using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Screen : MonoBehaviour
{
    public void Menu()
    {

        SceneManager.LoadScene("menu");
        
    }
    public void Quit()
    {
        Application.Quit();
    }
}
