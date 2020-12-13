using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selectmod : MonoBehaviour
{
    public GameObject Classic,Prop,Select;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Select.SetActive(false);
    }
    public void pclassic()
    {
        Select.SetActive(false);
        GameManager.Changscene(1);
    }
    public void ppro() 
    {
        Select.SetActive(false);
        Prop.SetActive(true);
    }
}
