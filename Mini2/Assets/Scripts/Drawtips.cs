using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawtips : MonoBehaviour
{
    private LineRenderer _lineRender;
    private Vector3 [] Position;
    private GameObject Cat;
    // Start is called before the first frame update
    void Start()
    {
        _lineRender=gameObject.transform.GetChild(0).GetComponent<LineRenderer>();
        Position=new Vector3[2];
        _lineRender.SetPositions(Position);
        Cat=GameObject.FindGameObjectWithTag("Cat");
    }

    // Update is called once per frame
    void Update()
    {
        Position[0]=gameObject.transform.position+new Vector3(0,0,0.4f);
        Position[1]=Cat.transform.position+new Vector3(0,0,0.1f);
        _lineRender.SetPositions(Position);
    }
    private void OnMouseEnter() 
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    private void OnMouseExit() 
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
