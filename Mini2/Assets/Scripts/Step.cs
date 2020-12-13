using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Step : MonoBehaviour
{
    public GameObject CreatScene;
    public Text text;

    private void Update()
    {
        CreatSceneProp Script1=CreatScene.GetComponent<CreatSceneProp>();
        int Step=Script1.StartStep;
        text.text = Step.ToString();
    }
}
