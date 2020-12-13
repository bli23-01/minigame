using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTips : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Cat;
    void Start()
    {
        Cat=GameObject.FindGameObjectWithTag("Cat");
    }

    // Update is called once per frame
    private void OnMouseEnter() 
    {
        Cat.transform.GetChild(0).gameObject.SetActive(true);
    }
    private void OnMouseExit() 
    {
        Cat.transform.GetChild(0).gameObject.SetActive(false);   
    }
}
