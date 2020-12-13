using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject restart, resume, back, pause, winMenu, endMenu;

    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        pause.SetActive(false);
        GameManager.Changscene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Resume()
    {
        pause.SetActive(false);
    }
    public void Back()
    {
        pause.SetActive(false);
        GameManager.Changscene(0);
    }
    public void Baktomap()
    {
        winMenu.SetActive(false);
        GameManager.Changscene(2);
    }
    public void Next()
    {
        winMenu.SetActive(false);
        GameManager.Changscene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
