using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    public GameObject player;
    public GameObject hpbar;
    public GameObject[] enemies;

    public Vector2 hpbarScale;
    public Vector2 hpbarPosition;

    public bool rightSide;
    public bool onBottem;

    public float distanceToClosest;

    public Text distanceIndicator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //hpbar
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

        //distance to closest enemy indicator
        distanceToClosest = 1234567890;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemie in enemies)
        {
            float distance = Vector3.Distance(enemie.GetComponent<Transform>().position, player.GetComponent<Transform>().position);
            if(distance <= distanceToClosest)
            {
                distanceToClosest = distance;
            }
        }
        distanceIndicator.text = "Distance to closest enemie: " + Mathf.Round(distanceToClosest) + "m";
    }
}
