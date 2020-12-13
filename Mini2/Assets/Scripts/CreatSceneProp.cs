﻿using System.Net;
using System.Transactions;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatSceneProp : MonoBehaviour
{   
    public int Height;
    public int Length;
    public int Cat_firstX,Cat_firstY;
    public GameObject Cylinder_Perfabs1;
    public GameObject Cylinder_Perfabs2;
    public GameObject Cylinder_Perfabs3;
    public GameObject Cylinder_Perfabs4;
    public GameObject Cylinder_Perfabs5;
    public GameObject Cylinder_Perfabs6;

    public GameObject Cat_Perfabs;
    public GameObject pauseMenu;
    public GameObject endMenu;
    public GameObject winMenu;
    public GameObject Ice1;
    private bool If_ice1True;
    public GameObject Ice2;
    public int [] Wall_x;
    public int [] Wall_y;
    public int StartStep;
    
    //public GameObject Wall_Perfabs;
    private GameObject [,]plate;
    private GameObject Cat;
    public Solver solver;
    private bool [,]blocksIsWall;
    private int cat_x,cat_y,target_x,target_y;
    private bool Moving;
    private int FrozenStep;
    private bool if_Win;
    private bool if_turn;
    void Start()
    {
        If_ice1True=false;
        if_turn=false;
        Moving=false;
        FrozenStep=0;
        if_Win=false;
        plate=new GameObject[Length,Height];
        blocksIsWall=new bool[Length,Height];
        this.InitialAndSpecificWall();
        GameObject CylinderBox=GameObject.Find("Cylinder Box");
        for(int i=Length-1;i>=0;i--)
        {
            for(int j=Height-1;j>=0;j--)
            {
                if(j%2==0)
                {
                    int temp=Random.Range(0,2);
                    if(!blocksIsWall[i,j]&&temp==0&&((i==1||i==9)||(j==1||j==9))&&!solver.blocks.getBlock(i,j).isEdge)
                    {
                        plate[i,j]=GameObject.Instantiate(Cylinder_Perfabs5,new Vector3(i,j,-0.5f),Quaternion.identity);
                        //plate[i,j].transform.Rotate(new Vector3(0,0,30));
                        plate[i,j].transform.parent=CylinderBox.transform;
                    }
                    else if(!blocksIsWall[i,j]&&temp==1&&((i==1||i==9)||(j==1||j==9))&&!solver.blocks.getBlock(i,j).isEdge)
                    {
                        plate[i,j]=GameObject.Instantiate(Cylinder_Perfabs6,new Vector3(i,j,-0.5f),Quaternion.identity);
                        //plate[i,j].transform.Rotate(new Vector3(0,0,30));
                        plate[i,j].transform.parent=CylinderBox.transform;
                    }
                    else if(!blocksIsWall[i,j]&&temp==0&&!solver.blocks.getBlock(i,j).isEdge)
                    {
                        plate[i,j]=GameObject.Instantiate(Cylinder_Perfabs1,new Vector3(i,j,-0.5f),Quaternion.identity);
                        //plate[i,j].transform.Rotate(new Vector3(0,0,30));
                        plate[i,j].transform.parent=CylinderBox.transform;
                    }
                    else if(!blocksIsWall[i,j]&&temp==1&&!solver.blocks.getBlock(i,j).isEdge)
                    {
                        plate[i,j]=GameObject.Instantiate(Cylinder_Perfabs2,new Vector3(i,j,-0.5f),Quaternion.identity);
                        //plate[i,j].transform.Rotate(new Vector3(0,0,30));
                        plate[i,j].transform.parent=CylinderBox.transform;
                    }
                    else if(!blocksIsWall[i,j]&&temp==0&&solver.blocks.getBlock(i,j).isEdge)
                    {
                        plate[i,j]=GameObject.Instantiate(Cylinder_Perfabs3,new Vector3(i,j,-0.5f),Quaternion.identity);
                        //plate[i,j].transform.Rotate(new Vector3(0,0,30));
                        plate[i,j].transform.parent=CylinderBox.transform;
                    }
                    else if(!blocksIsWall[i,j]&&temp==1&&solver.blocks.getBlock(i,j).isEdge)
                    {
                        plate[i,j]=GameObject.Instantiate(Cylinder_Perfabs4,new Vector3(i,j,-0.5f),Quaternion.identity);
                        //plate[i,j].transform.Rotate(new Vector3(0,0,30));
                        plate[i,j].transform.parent=CylinderBox.transform;
                    }
                    /*else
                    {
                        plate[i,j]=GameObject.Instantiate(Wall_Perfabs,new Vector3(i,j,0),Quaternion.identity);
                        plate[i,j].transform.Rotate(new Vector3(0,0,30));
                        plate[i,j].transform.parent=CylinderBox.transform;
                    }*/
                    if(i==cat_x&&j==cat_y)
                    {
                        Cat=GameObject.Instantiate(Cat_Perfabs,new Vector3(i,j+0.7f,-1f),Quaternion.identity);
                        //plate[i,j].transform.Rotate(new Vector3(90,0,0));
                    }
                        
                }   
                else
                {
                    int temp=Random.Range(0,2);
                    if(!blocksIsWall[i,j]&&temp==0&&((i==1||i==9)||(j==1||j==9))&&!solver.blocks.getBlock(i,j).isEdge)
                    {
                        plate[i,j]=GameObject.Instantiate(Cylinder_Perfabs5,new Vector3(i+0.5f,j,-0.5f),Quaternion.identity);
                        //plate[i,j].transform.Rotate(new Vector3(0,0,30));
                        plate[i,j].transform.parent=CylinderBox.transform;
                    }
                    else if(!blocksIsWall[i,j]&&temp==1&&((i==1||i==9)||(j==1||j==9))&&!solver.blocks.getBlock(i,j).isEdge)
                    {
                        plate[i,j]=GameObject.Instantiate(Cylinder_Perfabs6,new Vector3(i+0.5f,j,-0.5f),Quaternion.identity);
                        //plate[i,j].transform.Rotate(new Vector3(0,0,30));
                        plate[i,j].transform.parent=CylinderBox.transform;
                    }
                    else if(!blocksIsWall[i,j]&&temp==0&&!solver.blocks.getBlock(i,j).isEdge)
                    {
                        plate[i,j]=GameObject.Instantiate(Cylinder_Perfabs1,new Vector3(i+0.5f,j,-0.5f),Quaternion.identity);
                        //plate[i,j].transform.Rotate(new Vector3(0,0,30));
                        plate[i,j].transform.parent=CylinderBox.transform;
                    }
                    else if(!blocksIsWall[i,j]&&temp==1&&!solver.blocks.getBlock(i,j).isEdge)
                    {
                        plate[i,j]=GameObject.Instantiate(Cylinder_Perfabs2,new Vector3(i+0.5f,j,-0.5f),Quaternion.identity);
                        //plate[i,j].transform.Rotate(new Vector3(0,0,30));
                        plate[i,j].transform.parent=CylinderBox.transform;
                    }
                    else if(!blocksIsWall[i,j]&&temp==0&&solver.blocks.getBlock(i,j).isEdge)
                    {
                        plate[i,j]=GameObject.Instantiate(Cylinder_Perfabs3,new Vector3(i+0.5f,j,-0.5f),Quaternion.identity);
                        //plate[i,j].transform.Rotate(new Vector3(0,0,30));
                        plate[i,j].transform.parent=CylinderBox.transform;
                    }
                    else if(!blocksIsWall[i,j]&&temp==1&&solver.blocks.getBlock(i,j).isEdge)
                    {
                        plate[i,j]=GameObject.Instantiate(Cylinder_Perfabs4,new Vector3(i+0.5f,j,-0.5f),Quaternion.identity);
                        //plate[i,j].transform.Rotate(new Vector3(0,0,30));
                        plate[i,j].transform.parent=CylinderBox.transform;
                    }
                    /*else
                    {
                        plate[i,j]=GameObject.Instantiate(Wall_Perfabs,new Vector3(i+0.5f,j,0),Quaternion.identity);
                        plate[i,j].transform.Rotate(new Vector3(0,0,30));
                        plate[i,j].transform.parent=CylinderBox.transform;
                    }*/
                    if(i==cat_x&&j==cat_y)
                    {
                        Cat=GameObject.Instantiate(Cat_Perfabs,new Vector3(i+0.5f,j+0.7f,-1f),Quaternion.identity);
                        //Cat.transform.Rotate(new Vector3(90,0,0));
                    }
                        
                }
                
            }
        }
        
    }
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !endMenu.activeSelf&& !winMenu.activeSelf)
        {
            pauseMenu.SetActive(true);
        }
        else if (!pauseMenu.activeSelf && !endMenu.activeSelf&& !winMenu.activeSelf)
        {
            if (Input.GetMouseButtonDown(0) && !Moving)
            {
                /*foreach (var item in solver.blocks.getBlock(solver.cat_x,solver.cat_y).neighbours())
                {
                    Debug.Log(item.i);
                }*/
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    //Debug.Log(hit.collider.gameObject.name);
                    if (hit.collider.tag == "Cylinder")
                    {
                        bool if_break=false;
                        if(Mathf.Abs(hit.collider.transform.position.x-Cat.transform.position.x)<0.001f&&Mathf.Abs(hit.collider.transform.position.y-Cat.transform.position.y+0.7f)<0.001f)
                            return;
                        for (int i = 0; i < Length; i++)
                        {
                            for (int j = 0; j < Height; j++)
                            {
                                if (plate[i, j] != null && plate[i, j].transform == hit.collider.transform)
                                {
                                    blocksIsWall[i, j] = true;
                                    solver.updateWall(i, j);
                                    //Debug.Log(hit.collider.gameObject.name);
                                    Explode(i,j);
                                    //GameObject.Destroy(hit.collider.gameObject);
                                    //plate[i,j]=GameObject.Instantiate(Wall_Perfabs,plate[i,j].transform.localPosition,Quaternion.identity);
                                    //plate[i,j].transform.Rotate(new Vector3(90,0,0));
                                    if(FrozenStep==0)
                                        SetSolver();
                                    SetMoving();
                                    if_break=true;
                                    break;
                                }
                            }
                            if(if_break)
                                break;
                        }
                    }
                    else if(hit.collider.tag=="PropBoom1")
                    {
                        //Debug.Log("pa");
                        bool if_break=false;
                        for (int i = 0; i < Length; i++)
                        {
                            for (int j = 0; j < Height; j++)
                                if (plate[i, j] != null && plate[i, j].transform.position.x == hit.collider.transform.position.x
                                && Mathf.Abs(plate[i, j].transform.position.y+0.3f-hit.collider.transform.position.y)<=0.001f)
                                {
                                    Point []DestoryRange=new Point[3];
                                    if((i+1)!=cat_x||(j)!=cat_y)
                                        DestoryRange[0]=new Point(i+1,j);
                                    else
                                        DestoryRange[0]=new Point(-1,-1);
                                    if(i!=cat_x||(j)!=cat_y)
                                        DestoryRange[1]=new Point(i,j);
                                    else
                                        DestoryRange[1]=new Point(-1,-1);    
                                    if((i-1)!=cat_x||(j)!=cat_y) 
                                        DestoryRange[2]=new Point(i-1,j);
                                    else
                                        DestoryRange[2]=new Point(-1,-1);
                                    GameObject.Destroy(hit.collider.gameObject);
                                    foreach(var Range in DestoryRange)
                                    {
                                        //Debug.Log(Range.X+","+Range.Y);
                                        DestoryBlocks(Range.X,Range.Y);
                                    }
                                    if(FrozenStep==0)
                                        SetSolver();
                                    SetMoving();
                                    if_break=true;
                                    break;
                                }
                            if(if_break)
                                break;
                        }
                    }
                    else if(hit.collider.tag=="PropBoom2")
                    {
                        //Debug.Log("pa");
                        bool if_break=false;
                        for (int i = 0; i < Length; i++)
                        {
                            for (int j = 0; j < Height; j++)
                                if (plate[i, j] != null && plate[i, j].transform.position.x == hit.collider.transform.position.x
                                && (Mathf.Abs(plate[i, j].transform.position.y+0.3f-hit.collider.transform.position.y)<=0.001f))
                                {
                                    Point []DestoryRange=new Point[7];
                                    int index=0;
                                    foreach(var point in solver.blocks.getBlock(i,j).getNeighbours())
                                    {
                                        if(point.X!=cat_x||point.Y!=cat_y)
                                            DestoryRange[index]=point;
                                        else
                                            DestoryRange[index]=new Point(-1,-1);
                                        index++;
                                    }
                                    DestoryRange[index]=new Point(i,j);
                                    /*if(i!=cat_x||(j-1)!=cat_y)
                                        DestoryRange[0]=new Point(i,j-1);
                                    else
                                        DestoryRange[0]=new Point(-1,-1);
                                    if(i!=cat_x||(j)!=cat_y)
                                        DestoryRange[1]=new Point(i,j);
                                    else
                                        DestoryRange[1]=new Point(-1,-1);    
                                    if(i!=cat_x||(j+1)!=cat_y) 
                                        DestoryRange[2]=new Point(i,j+1);
                                    else
                                        DestoryRange[2]=new Point(-1,-1);*/
                                    GameObject.Destroy(hit.collider.gameObject);
                                    foreach(var Range in DestoryRange)
                                    {
                                        //Debug.Log(Range.X+","+Range.Y);
                                        DestoryBlocks(Range.X,Range.Y);
                                    }
                                    if(FrozenStep==0)
                                        SetSolver();
                                    SetMoving();
                                    if_break=true;
                                    break;
                                }
                            if(if_break)
                                break;
                        }
                    }
                    else if(hit.collider.tag=="PropBoom3")
                    {
                        //Debug.Log("pa");
                        bool if_break=false;
                        for (int i = 0; i < Length; i++)
                        {
                            for (int j = 0; j < Height; j++)
                                if (plate[i, j] != null && plate[i, j].transform.position.x == hit.collider.transform.position.x
                                && Mathf.Abs(plate[i, j].transform.position.y+0.3f-hit.collider.transform.position.y)<=0.001f)
                                {
                                    Point []DestoryRange=new Point[7];
                                    if((i)!=cat_x||(j)!=cat_y)
                                        DestoryRange[0]=new Point(i,j);
                                    else
                                        DestoryRange[0]=new Point(-1,-1);
                                    if((i-1)!=cat_x||(j)!=cat_y)
                                        DestoryRange[1]=new Point(i-1,j);
                                    else
                                        DestoryRange[1]=new Point(-1,-1);    
                                    if((i-2)!=cat_x||(j)!=cat_y) 
                                        DestoryRange[2]=new Point(i-2,j);
                                    else
                                        DestoryRange[2]=new Point(-1,-1);
                                    if((i-3)!=cat_x||(j)!=cat_y) 
                                        DestoryRange[3]=new Point(i-3,j);
                                    else
                                        DestoryRange[3]=new Point(-1,-1);
                                    if((i)!=cat_x||(j+1)!=cat_y)
                                        DestoryRange[4]=new Point(i,j+1);
                                    else
                                        DestoryRange[4]=new Point(-1,-1);
                                    if((i+1)!=cat_x||(j+2)!=cat_y)
                                        DestoryRange[5]=new Point(i+1,j+2);
                                    else
                                        DestoryRange[5]=new Point(-1,-1);
                                    if((i+1)!=cat_x||(j+3)!=cat_y)
                                        DestoryRange[6]=new Point(i+1,j+3);
                                    else
                                        DestoryRange[6]=new Point(-1,-1);
                                    GameObject.Destroy(hit.collider.gameObject);
                                    foreach(var Range in DestoryRange)
                                    {
                                        //Debug.Log(Range.X+","+Range.Y);
                                        DestoryBlocks(Range.X,Range.Y);
                                    }
                                    if(FrozenStep==0)
                                        SetSolver();
                                    SetMoving();
                                    if_break=true;
                                    break;
                                }
                            if(if_break)
                                break;
                        }
                    }
                    else if(hit.collider.tag=="PropBoom4")
                    {
                        //Debug.Log("pa");
                        bool if_break=false;
                        for (int i = 0; i < Length; i++)
                        {
                            for (int j = 0; j < Height; j++)
                                if (plate[i, j] != null && plate[i, j].transform.position.x == hit.collider.transform.position.x
                                && Mathf.Abs(plate[i, j].transform.position.y+0.3f-hit.collider.transform.position.y)<=0.001f)
                                {
                                    Point []DestoryRange=new Point[5];
                                    if((i)!=cat_x||(j)!=cat_y)
                                        DestoryRange[0]=new Point(i,j);
                                    else
                                        DestoryRange[0]=new Point(-1,-1);
                                    if((i-1)!=cat_x||(j)!=cat_y)
                                        DestoryRange[1]=new Point(i-1,j);
                                    else
                                        DestoryRange[1]=new Point(-1,-1);    
                                    if((i-2)!=cat_x||(j)!=cat_y) 
                                        DestoryRange[2]=new Point(i-2,j);
                                    else
                                        DestoryRange[2]=new Point(-1,-1);
                                    if((i+1)!=cat_x||(j+1)!=cat_y)
                                        DestoryRange[3]=new Point(i+1,j+1);
                                    else
                                        DestoryRange[3]=new Point(-1,-1);
                                    if((i+1)!=cat_x||(j+2)!=cat_y)
                                        DestoryRange[4]=new Point(i+1,j+2);
                                    else
                                        DestoryRange[4]=new Point(-1,-1);
                                    GameObject.Destroy(hit.collider.gameObject);
                                    foreach(var Range in DestoryRange)
                                    {
                                        //Debug.Log(Range.X+","+Range.Y);
                                        DestoryBlocks(Range.X,Range.Y);
                                    }
                                    if(FrozenStep==0)
                                        SetSolver();
                                    SetMoving();
                                    if_break=true;
                                    break;
                                }
                            if(if_break)
                                break;
                        }
                    }
                    else if(hit.collider.tag=="PropBoom5")
                    {
                        //Debug.Log("pa");
                        bool if_break=false;
                        for (int i = 0; i < Length; i++)
                        {
                            for (int j = 0; j < Height; j++)
                                if (plate[i, j] != null && plate[i, j].transform.position.x == hit.collider.transform.position.x
                                && Mathf.Abs(plate[i, j].transform.position.y+0.3f-hit.collider.transform.position.y)<=0.001f)
                                {
                                    Point []DestoryRange=new Point[7];
                                    if((i)!=cat_x||(j)!=cat_y)
                                        DestoryRange[0]=new Point(i,j);
                                    else
                                        DestoryRange[0]=new Point(-1,-1);
                                    if((i-1)!=cat_x||(j)!=cat_y)
                                        DestoryRange[1]=new Point(i-1,j);
                                    else
                                        DestoryRange[1]=new Point(-1,-1);    
                                    if((i-2)!=cat_x||(j)!=cat_y) 
                                        DestoryRange[2]=new Point(i-2,j);
                                    else
                                        DestoryRange[2]=new Point(-1,-1);
                                    if((i-3)!=cat_x||(j)!=cat_y) 
                                        DestoryRange[3]=new Point(i-3,j);
                                    else
                                        DestoryRange[3]=new Point(-1,-1);
                                    if((i+1)!=cat_x||(j+1)!=cat_y)
                                        DestoryRange[4]=new Point(i+1,j+1);
                                    else
                                        DestoryRange[4]=new Point(-1,-1);
                                    if((i+1)!=cat_x||(j+2)!=cat_y)
                                        DestoryRange[5]=new Point(i+1,j+2);
                                    else
                                        DestoryRange[5]=new Point(-1,-1);
                                    if((i+2)!=cat_x||(j+3)!=cat_y)
                                        DestoryRange[6]=new Point(i+2,j+3);
                                    else
                                        DestoryRange[6]=new Point(-1,-1);
                                    GameObject.Destroy(hit.collider.gameObject);
                                    foreach(var Range in DestoryRange)
                                    {
                                        //Debug.Log(Range.X+","+Range.Y);
                                        DestoryBlocks(Range.X,Range.Y);
                                    }
                                    if(FrozenStep==0)
                                        SetSolver();
                                    SetMoving();
                                    if_break=true;
                                    break;
                                }
                            if(if_break)
                                break;
                        }
                    }
                    else if(hit.collider.tag=="PropBoom6")
                    {
                        //Debug.Log("pa");
                        bool if_break=false;
                        for (int i = 0; i < Length; i++)
                        {
                            for (int j = 0; j < Height; j++)
                                if (plate[i, j] != null && plate[i, j].transform.position.x == hit.collider.transform.position.x
                                && Mathf.Abs(plate[i, j].transform.position.y+0.3f-hit.collider.transform.position.y)<=0.001f)
                                {
                                    Point []DestoryRange=new Point[5];
                                    if((i)!=cat_x||(j)!=cat_y)
                                        DestoryRange[0]=new Point(i,j);
                                    else
                                        DestoryRange[0]=new Point(-1,-1);
                                    if((i-1)!=cat_x||(j)!=cat_y)
                                        DestoryRange[1]=new Point(i-1,j);
                                    else
                                        DestoryRange[1]=new Point(-1,-1);    
                                    if((i-2)!=cat_x||(j)!=cat_y) 
                                        DestoryRange[2]=new Point(i-2,j);
                                    else
                                        DestoryRange[2]=new Point(-1,-1);
                                    if((i)!=cat_x||(j+1)!=cat_y)
                                        DestoryRange[3]=new Point(i,j+1);
                                    else
                                        DestoryRange[3]=new Point(-1,-1);
                                    if((i+1)!=cat_x||(j+2)!=cat_y)
                                        DestoryRange[4]=new Point(i+1,j+2);
                                    else
                                        DestoryRange[4]=new Point(-1,-1);
                                    GameObject.Destroy(hit.collider.gameObject);
                                    foreach(var Range in DestoryRange)
                                    {
                                        //Debug.Log(Range.X+","+Range.Y);
                                        DestoryBlocks(Range.X,Range.Y);
                                    }
                                    if(FrozenStep==0)
                                        SetSolver();
                                    SetMoving();
                                    if_break=true;
                                    break;
                                }
                            if(if_break)
                                break;
                        }
                    }
                    else if(hit.collider.tag=="PropBoom7")
                    {
                        //Debug.Log("pa");
                        bool if_break=false;
                        for (int i = 0; i < Length; i++)
                        {
                            for (int j = 0; j < Height; j++)
                                if (plate[i, j] != null && plate[i, j].transform.position.x == hit.collider.transform.position.x
                                && Mathf.Abs(plate[i, j].transform.position.y+0.3f-hit.collider.transform.position.y)<=0.001f)
                                {
                                    Point []DestoryRange=new Point[5];
                                    if((i-1)!=cat_x||(j+1)!=cat_y)
                                        DestoryRange[0]=new Point(i-1,j+1);
                                    else
                                        DestoryRange[0]=new Point(-1,-1);
                                    if((i-1)!=cat_x||(j+2)!=cat_y)
                                        DestoryRange[1]=new Point(i-1,j+2);
                                    else
                                        DestoryRange[1]=new Point(-1,-1);    
                                    if((i)!=cat_x||(j)!=cat_y) 
                                        DestoryRange[2]=new Point(i,j);
                                    else
                                        DestoryRange[2]=new Point(-1,-1);
                                    if((i)!=cat_x||(j-1)!=cat_y)
                                        DestoryRange[3]=new Point(i,j-1);
                                    else
                                        DestoryRange[3]=new Point(-1,-1);
                                    if((i+1)!=cat_x||(j-2)!=cat_y)
                                        DestoryRange[4]=new Point(i+1,j-2);
                                    else
                                        DestoryRange[4]=new Point(-1,-1);
                                    GameObject.Destroy(hit.collider.gameObject);
                                    foreach(var Range in DestoryRange)
                                    {
                                        //Debug.Log(Range.X+","+Range.Y);
                                        DestoryBlocks(Range.X,Range.Y);
                                    }
                                    if(FrozenStep==0)
                                        SetSolver();
                                    SetMoving();
                                    if_break=true;
                                    break;
                                }
                            if(if_break)
                                break;
                        }
                    }
                    else if(hit.collider.tag=="PropBoom8")
                    {
                        //Debug.Log("pa");
                        bool if_break=false;
                        for (int i = 0; i < Length; i++)
                        {
                            for (int j = 0; j < Height; j++)
                                if (plate[i, j] != null && plate[i, j].transform.position.x == hit.collider.transform.position.x
                                && Mathf.Abs(plate[i, j].transform.position.y+0.3f-hit.collider.transform.position.y)<=0.001f)
                                {
                                    Point []DestoryRange=new Point[5];
                                    if((i+1)!=cat_x||(j+1)!=cat_y)
                                        DestoryRange[0]=new Point(i+1,j+1);
                                    else
                                        DestoryRange[0]=new Point(-1,-1);
                                    if((i+1)!=cat_x||(j+2)!=cat_y)
                                        DestoryRange[1]=new Point(i+1,j+2);
                                    else
                                        DestoryRange[1]=new Point(-1,-1);    
                                    if((i)!=cat_x||(j)!=cat_y) 
                                        DestoryRange[2]=new Point(i,j);
                                    else
                                        DestoryRange[2]=new Point(-1,-1);
                                    if((i+1)!=cat_x||(j-1)!=cat_y)
                                        DestoryRange[3]=new Point(i+1,j-1);
                                    else
                                        DestoryRange[3]=new Point(-1,-1);
                                    if((i+1)!=cat_x||(j-2)!=cat_y)
                                        DestoryRange[4]=new Point(i+1,j-2);
                                    else
                                        DestoryRange[4]=new Point(-1,-1);
                                    GameObject.Destroy(hit.collider.gameObject);
                                    foreach(var Range in DestoryRange)
                                    {
                                        //Debug.Log(Range.X+","+Range.Y);
                                        DestoryBlocks(Range.X,Range.Y);
                                    }
                                    if(FrozenStep==0)
                                        SetSolver();
                                    SetMoving();
                                    if_break=true;
                                    break;
                                }
                            if(if_break)
                                break;
                        }
                    }
                    else if(hit.collider.tag=="PropBoom9")
                    {
                        //Debug.Log("pa");
                        bool if_break=false;
                        for (int i = 0; i < Length; i++)
                        {
                            for (int j = 0; j < Height; j++)
                                if (plate[i, j] != null && plate[i, j].transform.position.x == hit.collider.transform.position.x
                                && Mathf.Abs(plate[i, j].transform.position.y+0.3f-hit.collider.transform.position.y)<=0.001f)
                                {
                                    Point []DestoryRange=new Point[3];
                                    if((i+1)!=cat_x||(j+1)!=cat_y)
                                        DestoryRange[0]=new Point(i+1,j+1);
                                    else
                                        DestoryRange[0]=new Point(-1,-1);
                                    if((i)!=cat_x||(j)!=cat_y) 
                                        DestoryRange[1]=new Point(i,j);
                                    else
                                        DestoryRange[1]=new Point(-1,-1);
                                    if((i+1)!=cat_x||(j-1)!=cat_y)
                                        DestoryRange[2]=new Point(i+1,j-1);
                                    else
                                        DestoryRange[2]=new Point(-1,-1);
                                    GameObject.Destroy(hit.collider.gameObject);
                                    foreach(var Range in DestoryRange)
                                    {
                                        //Debug.Log(Range.X+","+Range.Y);
                                        DestoryBlocks(Range.X,Range.Y);
                                    }
                                    if(FrozenStep==0)
                                        SetSolver();
                                    SetMoving();
                                    if_break=true;
                                    break;
                                }
                            if(if_break)
                                break;
                        }
                    }
                    else if(hit.collider.tag=="PropBoom10")
                    {
                        //Debug.Log("pa");
                        bool if_break=false;
                        for (int i = 0; i < Length; i++)
                        {
                            for (int j = 0; j < Height; j++)
                                if (plate[i, j] != null && plate[i, j].transform.position.x == hit.collider.transform.position.x
                                && Mathf.Abs(plate[i, j].transform.position.y+0.3f-hit.collider.transform.position.y)<=0.001f)
                                {
                                    Point []DestoryRange=new Point[3];
                                    if((i)!=cat_x||(j+1)!=cat_y)
                                        DestoryRange[0]=new Point(i,j+1);
                                    else
                                        DestoryRange[0]=new Point(-1,-1);
                                    if((i)!=cat_x||(j)!=cat_y) 
                                        DestoryRange[1]=new Point(i,j);
                                    else
                                        DestoryRange[1]=new Point(-1,-1);
                                    if((i)!=cat_x||(j-1)!=cat_y)
                                        DestoryRange[2]=new Point(i,j-1);
                                    else
                                        DestoryRange[2]=new Point(-1,-1);
                                    GameObject.Destroy(hit.collider.gameObject);
                                    foreach(var Range in DestoryRange)
                                    {
                                        //Debug.Log(Range.X+","+Range.Y);
                                        DestoryBlocks(Range.X,Range.Y);
                                    }
                                    if(FrozenStep==0)
                                        SetSolver();
                                    SetMoving();
                                    if_break=true;
                                    break;
                                }
                            if(if_break)
                                break;
                        }
                    }
                    else if(hit.collider.tag=="PropBoom11")
                    {
                        //Debug.Log("pa");
                        bool if_break=false;
                        for (int i = 0; i < Length; i++)
                        {
                            for (int j = 0; j < Height; j++)
                                if (plate[i, j] != null && plate[i, j].transform.position.x == hit.collider.transform.position.x
                                && Mathf.Abs(plate[i, j].transform.position.y+0.3f-hit.collider.transform.position.y)<=0.001f)
                                {
                                    Point []DestoryRange=new Point[3];
                                    if((i+1)!=cat_x||(j)!=cat_y)
                                        DestoryRange[0]=new Point(i+1,j);
                                    else
                                        DestoryRange[0]=new Point(-1,-1);
                                    if((i)!=cat_x||(j)!=cat_y) 
                                        DestoryRange[1]=new Point(i,j);
                                    else
                                        DestoryRange[1]=new Point(-1,-1);
                                    if((i-1)!=cat_x||(j-1)!=cat_y)
                                        DestoryRange[2]=new Point(i-1,j-1);
                                    else
                                        DestoryRange[2]=new Point(-1,-1);
                                    GameObject.Destroy(hit.collider.gameObject);
                                    foreach(var Range in DestoryRange)
                                    {
                                        //Debug.Log(Range.X+","+Range.Y);
                                        DestoryBlocks(Range.X,Range.Y);
                                    }
                                    if(FrozenStep==0)
                                        SetSolver();
                                    SetMoving();
                                    if_break=true;
                                    break;
                                }
                            if(if_break)
                                break;
                        }
                    }
                    else if(hit.collider.tag=="PropPause1")
                    {
                        GameObject.Destroy(hit.collider.gameObject);
                        FrozenStep+=1;
                        StartStep--;
                        Debug.Log(StartStep);
                        Ice2.SetActive(true);
                        Cat.transform.GetChild(0).gameObject.SetActive(true);
                    }
                    else if(hit.collider.tag=="PropDraw1")
                    {
                        bool if_break=false;
                        for (int i = 0; i < Length; i++)
                        {
                            for (int j = 0; j < Height; j++)
                                if (plate[i, j] != null && plate[i, j].transform.position.x == hit.collider.transform.position.x
                                && Mathf.Abs(plate[i, j].transform.position.y+0.3f-hit.collider.transform.position.y)<=0.001f)
                                {
                                    GameObject.Destroy(hit.collider.gameObject);
                                    if(FrozenStep==0)
                                        SetDrawSolver(i,j);
                                    else
                                        SetSolver();
                                    SetMoving();
                                    if_break=true;
                                    break;
                                }
                            if(if_break)
                                break;
                        }
                    }
                }
            }
            if (Moving&&!if_Win)
            {
                Vector3 temp;
                if(!if_turn)
                {
                    if(plate[target_x, target_y].transform.position.x>Cat.transform.position.x)
                    {
                        temp=Cat.transform.localScale;
                        temp.x=-0.2f;
                        Cat.transform.localScale=temp;
                    }
                    else
                    {
                        temp=Cat.transform.localScale;
                        temp.x=0.2f;
                        Cat.transform.localScale=temp;
                    }
                }
                Cat.GetComponent<Animator>().SetBool("Moving",true);
                Cat.transform.localPosition = Vector3.MoveTowards(Cat.transform.localPosition, plate[target_x, target_y].transform.position + new Vector3(0, 0.7f, -0.5f), 3 * Time.deltaTime);
                if (Vector3.Distance(Cat.transform.localPosition, plate[target_x, target_y].transform.position + new Vector3(0, 0.7f, -0.5f)) < 0.01f)
                    Moving = false;
            }
            else
                Cat.GetComponent<Animator>().SetBool("Moving",false);
            if(solver.blocks.getBlock(cat_x,cat_y).distance==int.MaxValue&& !if_Win)
            {
                GameManager.Count();
                Debug.Log("hh");
                Cat.GetComponent<Animator>().SetBool("Moving",false);
                if_Win=true;
                winMenu.SetActive(true);
            }
            if ((cat_x >= 10 || cat_x <= 0.5 || cat_y == 0 || cat_y == 10||StartStep==0) && !Moving&& !winMenu.activeSelf&&!if_Win)
            {
                endMenu.SetActive(true);
                Cat.GetComponent<Animator>().SetBool("Moving",false);
            }

        }
    }
    void Explode(int i,int j)
    {
        plate[i,j].tag="pieces";
    }
    void SetMoving()//问题一：点击冰霜的期间，操作会不会减少步数，若减少，则放在开头，若不减少，放在if里面
    {
        if(FrozenStep==0)
        {
            Moving=true;
            StartStep--;
            Debug.Log(StartStep);
            if(If_ice1True)
                Ice1.SetActive(false);
        }
        else
        {
            FrozenStep--;
            StartStep--;
            Ice2.SetActive(false);
            Ice1.SetActive(true);
            If_ice1True=true;
            Cat.transform.GetChild(0).gameObject.SetActive(false);
        }
            
    }
    void SetDrawSolver(int X,int Y)
    {
        int temp=FindDrawSolver(X,Y);
        //Debug.Log(temp);
        target_x = solver.blocks.getBlock(cat_x, cat_y).neighbours()[temp].i;
        target_y = solver.blocks.getBlock(cat_x, cat_y).neighbours()[temp].j;
        cat_x = target_x;
        cat_y = target_y;
        solver.updateCat(cat_x, cat_y);
    }
    int FindDrawSolver(int X,int Y)
    {
        int result=-1;
        int index=0;
        var Cat=solver.blocks.getBlock(this.cat_x,this.cat_y);
        var neighbours=Cat.neighbours();
        float min=int.MaxValue;
        foreach (var item in neighbours)
        {
            if(plate[item.i,item.j]==null)
            {
                index++;
                continue;
            }
                
            if(Vector2.Distance(new Vector2(plate[X,Y].transform.position.x,plate[X,Y].transform.position.y),
                                new Vector2(plate[item.i,item.j].transform.position.x,plate[item.i,item.j].transform.position.y))<=min)
            {
                result=index;
                min=Vector2.Distance(new Vector2(plate[X,Y].transform.position.x,plate[X,Y].transform.position.y),
                                new Vector2(plate[item.i,item.j].transform.position.x,plate[item.i,item.j].transform.position.y));
            }
            index++;
        }
        return result;
    }
    void SetSolver()
    {
        int temp = solver.nearestAndMoreRoutesSolver();
        //Debug.Log(temp);
        if (temp != -1)
        {
            target_x = solver.blocks.getBlock(cat_x, cat_y).neighbours()[temp].i;
            target_y = solver.blocks.getBlock(cat_x, cat_y).neighbours()[temp].j;
            //Debug.Log("?");
        }
        else if (solver.nearestSolver() != -1)
        {
            temp = solver.nearestSolver();
            target_x = solver.blocks.getBlock(cat_x, cat_y).neighbours()[temp].i;
            target_y = solver.blocks.getBlock(cat_x, cat_y).neighbours()[temp].j;
            //Debug.Log("??");
        }
        else
        {
            temp = solver.defaultSolver();
            target_x = solver.blocks.getBlock(cat_x, cat_y).neighbours()[temp].i;
            target_y = solver.blocks.getBlock(cat_x, cat_y).neighbours()[temp].j;
            //Debug.Log("???");
        }
        cat_x = target_x;
        cat_y = target_y;
        solver.updateCat(cat_x, cat_y);
    }
    void DestoryBlocks(int i,int j)//查看i，j是否可销毁
    {
        if(i<0||i>=Length||j<0||j>=Height)
            return;
        if(plate[i,j]!=null&&!blocksIsWall[i,j])
        {
            blocksIsWall[i, j] = true;
            solver.updateWall(i, j);
            GameObject.Destroy(plate[i,j]);
        }
    }
    void InitialAndRandomWall()
    {
        cat_x=Cat_firstX;
        cat_y=Cat_firstY;
        for(int i=0;i<Length;i++)
            for(int j=0;j<Height;j++)
                blocksIsWall[i,j]=false;
        solver=new Solver(blocksIsWall,cat_x,cat_y);
        for(int k=0;k<8;)
        {
            float temp=Length*Random.Range(0f,1f);
            int i=Mathf.FloorToInt(temp);
            temp=Height*Random.Range(0f,1f);
            int j=Mathf.FloorToInt(temp);
            if(i!=solver.cat_x&&j!=solver.cat_y)
            {
                blocksIsWall[i,j]=true;
                solver.updateWall(i,j);
                k++;
            }
        }
    }
    void InitialAndSpecificWall()
    {
        cat_x=Cat_firstX;
        cat_y=Cat_firstY;
        for(int i=0;i<Length;i++)
            for(int j=0;j<Height;j++)
                blocksIsWall[i,j]=false;
        solver=new Solver(blocksIsWall,cat_x,cat_y);
        for(int k=0;k<Wall_x.Length;++k)
        {           
            blocksIsWall[Wall_x[k],Wall_y[k]]=true;
            solver.updateWall(Wall_x[k],Wall_y[k]);
        }
    }
}
