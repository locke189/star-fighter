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
        StartCoroutine(GameOverCoroutine());
    }

     public void LoadGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    IEnumerator GameOverCoroutine() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Game Over");
    }
}
