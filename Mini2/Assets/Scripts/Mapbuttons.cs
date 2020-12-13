using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mapbuttons : MonoBehaviour
{
    public Text text;
    public GameObject button;
    double x1, x2, y1, y2;
    void Update()
    {
        x1 = button.transform.position.x + button.GetComponent<RectTransform>().rect.width / 2 - 13;
        x2 = button.transform.position.x - button.GetComponent<RectTransform>().rect.width / 2 + 13;
        y1 = button.transform.position.y + button.GetComponent<RectTransform>().rect.height / 2 - 13;
        y2 = button.transform.position.y - button.GetComponent<RectTransform>().rect.height / 2 + 13;
        if (Input.mousePosition.x >= x2 && Input.mousePosition.x <= x1 && Input.mousePosition.y <= y1 && Input.mousePosition.y >= y2)
        {
            text.color = new Color(1f, 0.949f, 0f, 1f);
            //text.enabled = true;
        }
        else
        {
            text.color = new Color(0.404f, 0.306f, 0.212f, 1f);
            // text.enabled = false;
        }
    }
}
