using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
   public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuitButton()
    {
        Application.Quit();
        Debug.Log("QUIT");       
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
