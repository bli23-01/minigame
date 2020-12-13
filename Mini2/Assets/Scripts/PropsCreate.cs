using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsCreate : MonoBehaviour
{
    public GameObject[] Props_Perfabs;
    public int []X,Y,Which_Perfabs;
    //private GameObject CreatScene;
    void Start()
    {
        int Num=X.Length;
        GameObject []Props=new GameObject[Num];
        GameObject PloyProps=GameObject.Find("PloyProps");
        //CreatScene=GameObject.Find("CreatScene");
        for(int i=0;i<Num;i++)
        {
            Props[i]=Creat(X[i],Y[i],Which_Perfabs[i]);
            Props[i].transform.parent=PloyProps.transform;
        }
        
    }

    private GameObject Creat(int X,int Y,int Perfabs_Num)
    {
        if(Y%2==0)
            return GameObject.Instantiate(Props_Perfabs[Perfabs_Num-1],new Vector3(X,Y+0.3f,-0.7f),Quaternion.identity);
        else
            return GameObject.Instantiate(Props_Perfabs[Perfabs_Num-1],new Vector3(X+0.5f,Y+0.3f,-0.7f),Quaternion.identity);
    }
}
