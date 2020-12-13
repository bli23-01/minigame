using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class buttons1 : MonoBehaviour
{
   public Text text;
    public GameObject button;
    public GameObject select, setting;
    double x1, x2, y1, y2;
    public Outline outline;
    void Update()
    {
        if (button.name == "Quit")
        {
            x1 = button.transform.position.x + button.GetComponent<RectTransform>().rect.width / 2+35;
            x2 = button.transform.position.x - button.GetComponent<RectTransform>().rect.width / 2-35;
            y1 = button.transform.position.y + button.GetComponent<RectTransform>().rect.height / 2+35;
            y2 = button.transform.position.y - button.GetComponent<RectTransform>().rect.height / 2-35;
        }
        else
        {
            x1 = button.transform.position.x + button.GetComponent<RectTransform>().rect.width / 2 + 32;
            x2 = button.transform.position.x - button.GetComponent<RectTransform>().rect.width / 2 - 32;
            y1 = button.transform.position.y + button.GetComponent<RectTransform>().rect.height / 2 + 32;
            y2 = button.transform.position.y - button.GetComponent<RectTransform>().rect.height / 2 - 32;
        }
        if (Input.mousePosition.x >= x2 && Input.mousePosition.x <= x1 && Input.mousePosition.y <= y1 && Input.mousePosition.y >= y2)
        {
            text.color = new Color(1f, 0.949f, 0f, 1f);
            //text.enabled = true;
            outline.enabled = true;
        }
        else
        {
            if (button.name == "Prop")
                Setcolor(0.179f, 0.129f, 0.04f, 1f);
            if (button.name == "Classic")
                Setcolor(0.208f, 0.118f, 0.036f, 1);
           // text.enabled = false;
            outline.enabled = false;
        }
        Debug.Log(text.color);
    }
    void Setcolor(float r, float g, float b, float a)
    {
        text.color = new Color(r, g, b, a);
    }
}
