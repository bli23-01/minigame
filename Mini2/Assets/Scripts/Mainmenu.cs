using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu : MonoBehaviour
{
    public GameObject Select, settings, instruction;
    public GameObject restart, resume, back, pause;
    public GameObject Classic, Prop;
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && instruction.activeSelf)
        {
            instruction.SetActive(false);
        }
            
        if(Input.GetKeyUp(KeyCode.Escape) && settings.activeSelf && !instruction.activeSelf)
            settings.SetActive(false);
    }
    public void SelectMod()
    {
        GameManager.Changscene(2);
       // Select.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Settings()
    {
        settings.SetActive(true);
    }
    public void Instruction()
    {
        instruction.SetActive(true);
    }
    /*public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Resume()
    {
        pause.SetActive(false);
    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }*/
    public void sclass()
    {
        GameManager.Changscene(1);
    }
    
}
