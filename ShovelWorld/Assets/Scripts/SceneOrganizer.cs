using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOrganizer : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene(9);
        while (Time.timeSinceLevelLoad < 10)
        {
            if (Time.timeSinceLevelLoad > 5)
                Initiate.Fade("_Red", Color.black, 1.0f);
        }
    }

    public void RedScene()
    {
        Initiate.Fade("_Red", Color.black, 1.0f);
        //SceneManager.LoadScene(1);
    }

    public void OrangeScene()
    {
        Initiate.Fade("_Orange", Color.red, 1.0f);
        //SceneManager.LoadScene(2);
    }

    public void YellowScene()
    {
        Color temp = new Color(155f, 140f, 0f);
        Initiate.Fade("_Yellow", temp, 1.0f);
        //SceneManager.LoadScene(3);
    }

    public void GreenScene()
    {
        Initiate.Fade("_Green", Color.yellow, 1.0f);
        //SceneManager.LoadScene(4);
    }
    public void BlueScene()
    {
        Initiate.Fade("_Blue", Color.green, 1.0f);
        //SceneManager.LoadScene(5);
    }

    public void PurpleScene()
    {
        Initiate.Fade("_Purple", Color.blue, 1.0f);
        //SceneManager.LoadScene(6);
    }

    public void WhiteScene()
    {
        Color temp = new Color(86f, 4f, 110f);
        Initiate.Fade("_White", temp, 1.0f);
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
