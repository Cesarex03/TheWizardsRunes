using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public void PlayScene()
    {

        SceneManager.LoadScene("Level1");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT GAME !");
        Application.Quit();
    }
}
