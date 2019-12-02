using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public void LoadMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LoadGameOver() {
        SceneManager.LoadScene("Game Over");
    }

     public void LoadGame()
    {
        SceneManager.LoadScene("Level 1");
    }
}
