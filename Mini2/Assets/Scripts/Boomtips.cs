using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomtips : MonoBehaviour
{
    public GameObject BoomPraticle;
    private int Count;
    private void Start() 
    {
        Count=gameObject.transform.childCount;    
    }
    private void OnMouseEnter() 
    {
        for(int i=0;i<Count;i++)
        {
            Transform Child=gameObject.transform.GetChild(i);
            Child.gameObject.SetActive(true);
        }
    }
    private void OnDestroy() 
    {
        GameObject.Instantiate(BoomPraticle,this.transform.position,Quaternion.identity);
    }
    private void OnMouseExit() 
    {
        for(int i=0;i<Count;i++)
        {
            Transform Child=gameObject.transform.GetChild(i);
            Child.gameObject.SetActive(false);
        }
    }
}
