using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solver
{
    public Blocks blocks;
    public int cat_x,cat_y;
    public Solver (bool [,]blocksIsWall,int cat_x,int cat_y)
    {
        this.blocks=new Blocks(blocksIsWall);
        this.cat_x=cat_x;
        this.cat_y=cat_y;
    }
    public void updateWall(int i,int j)
    {
        this.blocks.updateBlocks(i,j);
    }
    public void updatePropTotrue(int i,int j)
    {
        this.blocks.updatePropTotrue(i,j);
    }
    public void updatePropTofalse(int i,int j)
    {
        this.blocks.updatePropTofalse(i,j);
    }
    public void updateCat(int i,int j)
    {
        this.cat_x=i;
        this.cat_y=j;
    }
    public int nearestSolver()
    {
        blocks.calcAllDistances();
        var Cat=blocks.getBlock(this.cat_x,this.cat_y);
        var directions=Cat.directions();
        if(directions.Count>0)
            return directions[0];
        else
            return -1;
    }
    public int nearestAndMoreRoutesSolver()
    {
        blocks.calcAllDistances();
        foreach (var item in blocks.blocks)
            item._routesCount=-1;
        foreach (var item in blocks.blocks)
            item.routesCount();
        var Cat=blocks.getBlock(this.cat_x,this.cat_y);
        return Cat.direction();
    }
    public int defaultSolver()
    {
        int result=-1;
        int index=0;
        var Cat=this.blocks.getBlock(this.cat_x,this.cat_y);
        var neighbours=Cat.neighbours();
        foreach (var item in neighbours)
        {
            if(result==-1)
            {
                if(!item.isWall)
                {
                    result=index;
                    break;
                }
            }
            index++;
        }
        return index;
    }
    public int DrawSolver(int X,int Y)
    {
        int result=-1;
        int index=0;
        var Cat=this.blocks.getBlock(this.cat_x,this.cat_y);
        var neighbours=Cat.neighbours();
        int min=int.MaxValue;
        foreach (var item in neighbours)
        {
            if(Mathf.Abs(X-item.i)+Mathf.Abs(Y-item.j)<=min)
            {
                result=index;
                min=Mathf.Abs(X-item.i)+Mathf.Abs(Y-item.j);
            }
            index++;
        }
        return result;
    }
}
