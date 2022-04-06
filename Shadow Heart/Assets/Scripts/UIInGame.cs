using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    public GameObject player;
    public GameObject hpbar;

    public Vector2 hpbarScale;
    public Vector2 hpbarPosition;

    public bool rightSide;
    public bool onBottem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpbarScale.y = 100;
        hpbarScale.x = player.GetComponent<HealtPoints>().hp * 8;
        hpbar.GetComponent<RectTransform>().sizeDelta = hpbarScale;
        if (rightSide == false)
        {
            hpbarPosition.x = 67 + player.GetComponent<HealtPoints>().hp * 1.585f;
            if (onBottem == false)
            {

            }
            else
            {
                hpbarPosition.y = 40;
            }
        }
        else
        {
            if (onBottem == false)
            {

            }
            else
            {
                hpbarPosition.y = 40;
            }
        }
        hpbar.GetComponent<RectTransform>().anchoredPosition = hpbarPosition;
    }
}
