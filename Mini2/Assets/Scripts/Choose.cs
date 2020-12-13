using System.Net.Mime;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Choose : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject [] Choose_Level;
    void Start()
    {
        int Level=GameManager.a;
        for(int i=0;i<Level;++i)
        {
            Choose_Level[i].SetActive(true);
        }
    }
}
