using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    
    public void StartLevel2()
    {
        SceneManager.LoadScene("Scenes/Level2");
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
