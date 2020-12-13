using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{
    public GameObject play;
    int a;
    public void P()
    {
        int.TryParse(play.name, out a);
        GameManager.Changscene(a + 2);
    }
    public void Back()
    {
        GameManager.Changscene(0);
    }
    
}
