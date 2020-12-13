using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scenefader : MonoBehaviour
{
    Animator anim;
    int ID;
    public void Start()
    {
        anim = GetComponent<Animator>();
        ID = Animator.StringToHash("Fade");
        GameManager.Regist(this);
    }
    public void Fadeout()
    {
        anim.SetTrigger(ID);
    }
}
