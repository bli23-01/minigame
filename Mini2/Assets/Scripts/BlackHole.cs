using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    private GameObject [] pieces;
    //private bool if_Destroy;
    public int Force;
    public float StartSpeed;
    public float DestroyTime;
    private int Temp_Force;
    private GameObject piece;
    private Rigidbody2D temp;
    private bool if_Start;
    private void Start() 
    {
        //if_Destroy=true;
        if_Start=false;
    }
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            Invoke("Dealer",0.1f);
        }
        if(if_Start&&pieces.Length>0&&pieces[0]!=null)
        {
            if(Temp_Force<=200)
                Temp_Force+=10;
            foreach(var piece in pieces)
            {   
                if(piece.TryGetComponent<Rigidbody2D>(out Rigidbody2D temp))
                    piece.GetComponent<Rigidbody2D>().AddForce((new Vector3(5.34f,4.72f,1.6f)-piece.transform.position).normalized*Temp_Force);
                piece.transform.localScale-=new Vector3(0.27f,0.27f,1f)/DestroyTime*Time.deltaTime;
            }
        }
    }
    void ChangeBool()
    {
        //if_Destroy=true;
    }
    void Dealer()
    {
        if(if_Start&&pieces.Length>0&&pieces[0]!=null)
        {
            GameObject.Destroy(pieces[0]);
        }
        if_Start=true;
        pieces=GameObject.FindGameObjectsWithTag("pieces");
        if(pieces.Length!=0)
        {
            Mouseclicked();
        }
    }
    void Mouseclicked()
    {
        //Debug.Log(1);
        Temp_Force=Force;
        //if_Destroy=false;
        piece=pieces[0];
        GameObject.Destroy(piece,DestroyTime);
        Invoke("ChangeBool",DestroyTime);           //这个地方！！！有问题！！！！！算哩先不改了
        Destroy(piece.GetComponent<SphereCollider>());
        Invoke("RigidGet",0.01f);
    }
    void RigidGet()
    {
        piece.tag="Untagged";
        piece.AddComponent<Rigidbody2D>();
        //piece.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Static;
        piece.GetComponent<Rigidbody2D>().gravityScale=0;
        Vector3 direction=-(new Vector3(5.34f,4.72f,1.6f)-piece.transform.position).normalized;
        piece.GetComponent<Rigidbody2D>().velocity=new Vector3(direction.y,-direction.x,direction.z)*StartSpeed;   
    }
}


