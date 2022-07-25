using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayArea1()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayArea2()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayArea3()
    {
        SceneManager.LoadScene(3);
    }

    public void PlayArea4()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
