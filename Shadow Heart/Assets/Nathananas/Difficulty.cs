using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public float hp;
    public float dmg;
    public float timeLeft;
    public float factor = 0.2f;
    public float difficultyMeter;
    public float x;
    public float q;
    public string[] difficultyname;
    public int p;
    public Image cooldown;

    // Start is called before the first frame update
    void Start()
    {
        
        p = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            MoreDifficult();
            timeLeft = q;
            if(q > 5)
            {
                q -= 0.5f;
            }
        }
    }

    private void MoreDifficult()
    {
        print("Difficulty Changed");
        hp += (factor * x) + 1;
        dmg += (factor * x) + 1;

        x++;
        if(difficultyMeter < 13)
        {
            difficultyMeter++;
            print(difficultyname[p]);
            p++;
        }
    } //Heaven 0, too easy 1, easy 2, normal 3, hard 4, very hard 5, extreme 6, chaos 7, impossible 8, apocalypse 9, nightmare 10, hell 11, Death 12
}
