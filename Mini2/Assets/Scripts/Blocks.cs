using System.Security.AccessControl;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    public int X;
    public int Y;
    public Point(int X,int Y)
    {
        this.X=X;
        this.Y=Y;
    }
    public Point()
    {
        this.X=0;
        this.Y=0;
    }
}
public class Block
{
    public int i;//横坐标
    public int j;//纵坐标
    public bool isWall;
    public bool isEdge;
    public bool isProp;
    public int distance;
    private Blocks parent;
    public int _routesCount;
    public Block(Blocks parent,int i,int j,bool isWall)
    {
        this.parent=parent;
        this.i=i;
        this.j=j;
        this.isWall=isWall;
        this.isEdge=this.i<=0||this.i>=this.parent.w-1||this.j<=0||this.j>=this.parent.h-1;
        this._routesCount=-1;
        this.distance=int.MaxValue;
        this.isProp=false;
    }
    public int routesCount()
    {
        if(this._routesCount==-1)
        {
            if(this.isEdge)
                this._routesCount=1;
            else
            {
                int tempCount=0;
                foreach (var item in this.neighbours())
                {
                    if(item!=null&&!item.isWall)
                        if(item.distance<this.distance)
                            tempCount+=item.routesCount();
                }
                this._routesCount=tempCount;
            }
        }
        return this._routesCount;
    }
    public List<Block> _neighbours=new List<Block>();
    public List<Block> neighbours()
    {
        if(this._neighbours.Count==0)
        {
            var tempneightbours=this.getNeighbours();
            foreach (var neightbour in tempneightbours)
            {
                this._neighbours.Add(this.parent.getBlock(neightbour.X,neightbour.Y));
            }
        }
        return this._neighbours;
    }
    public Point [] getNeighbours()
    {
        Point left=new Point(this.i-1,this.j);
        Point right=new Point(this.i+1,this.j);
        Point top_left;
        Point top_right;
        Point bottom_left;
        Point bottom_right;
        if((this.j%2==0))
        {
            top_left=new Point(this.i-1,this.j-1);
            top_right=new Point(this.i,this.j-1);
            bottom_left=new Point(this.i-1,this.j+1);
            bottom_right=new Point(this.i,this.j+1);
        }
        else
        {
            top_left=new Point(this.i,this.j-1);
            top_right=new Point(this.i+1,this.j-1);
            bottom_left=new Point(this.i,this.j+1);
            bottom_right=new Point(this.i+1,this.j+1);
        }
        Point []temp=new Point[6];
        temp[0] = left;
        temp[1] = top_left;
        temp[2] = top_right;
        temp[3] = right;
        temp[4] = bottom_right;
        temp[5] = bottom_left;
        return temp;
    }
    public List<int> directions()
    {
        List<int> tempDirections=new List<int>();
        int index=0;
        foreach(var item in this.neighbours())
        {
            if(item!=null&&!item.isWall)
            {
                if(item.distance<this.distance)
                    tempDirections.Add(index);
                //Debug.Log(index);
            }
            index++;
        }
        return tempDirections;
    }
    public int direction()
    {
        int maxRoutesCount=0;
        int result=-1;
        foreach(var item in this.directions())
        {
            var neighbour =this.neighbours()[item];
            //Debug.Log(neighbour.routesCount());
            if(neighbour.routesCount()>maxRoutesCount)
            {
                maxRoutesCount=neighbour.routesCount();
                result=item;
            }
        }
        return result;
    }
}
public class Blocks
{
    public int w;
    public int h;
    public Block[,] blocks;
    public Blocks(bool [,]blocksIsWall)
    {
        this.w=blocksIsWall.GetLength(0);
        if(this.w<=0)
            Debug.LogError("blocksIsWall.w Error!");
        this.h=blocksIsWall.GetLength(1);
        blocks=new Block[this.w,this.h];
        for(int i=0;i<this.w;i++)
        {
            for(int j=0;j<this.h;j++)
            {
                this.blocks[i,j]=new Block(this,i,j,blocksIsWall[i,j]);
            }
        }
        this.calcAllDistances();
        foreach (var item in this.blocks)
        {
            item.routesCount();
        }
    }
    public void updateBlocks(int i,int j)
    {
        this.blocks[i,j].isWall=true;
    }
    public void updatePropTotrue(int i,int j)
    {
        this.blocks[i,j].isProp=true;
    }
    public void updatePropTofalse(int i,int j)
    {
        this.blocks[i,j].isProp=false;
    }
    public Block getBlock(int i,int j)
    {
        if ((i<=-1)||(i>=this.w)||(j<=-1)||(j>=this.h)) 
        {
            return null;
        }
        return this.blocks[i,j];
    }
    /*calculate all distances
     * 滴水法 BFS 求每一块到边缘距离
     *
     * 1. 初始化一个队列，添加所有边界块，距离设为 0
     * 2. 遍历队列中每一个元素，对于他周围的 6 个相邻块
     *     * 如果没有遍历过，则设置为当前距离 + 1
     *     * 如果遍历过，则设置为它的距离与当前距离 + 1 中间的较小值
     */
    public void calcAllDistances()
    {
        foreach(var item in this.blocks)
        {
            item.distance=int.MaxValue;
        }
        Queue<Block> queue=new Queue<Block>();
        foreach(var item in this.blocks)
        {
            if(item.isEdge&&!item.isWall)
            {
                item.distance=0;
                queue.Enqueue(item);
            }
        }
        while(queue.Count>0)
        {
            var block=queue.Dequeue();
            foreach(var item in block.neighbours())
            {
                if(item!=null&&!item.isEdge&&!item.isWall)
                {
                    if(item.distance>block.distance+1&&block.distance!=int.MaxValue)
                    {
                        item.distance=block.distance+1;
                        if(!queue.Contains(item))
                            queue.Enqueue(item);
                    }
                }
            }
        }
    }
}
