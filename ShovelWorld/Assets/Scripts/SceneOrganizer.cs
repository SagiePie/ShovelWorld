using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOrganizer : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene(9);
    }

    public void RedScene()
    {
        SceneManager.LoadScene(1);
    }

    public void OrangeScene()
    {
        SceneManager.LoadScene(2);
    }

    public void YellowScene()
    {
        SceneManager.LoadScene(3);
    }

    public void GreenScene()
    {
        SceneManager.LoadScene(4);
    }
    public void BlueScene()
    {
        SceneManager.LoadScene(5);
    }

    public void PurpleScene()
    {
        SceneManager.LoadScene(6);
    }

    public void WhiteScene()
    {
        SceneManager.LoadScene(7);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(8);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
