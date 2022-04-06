using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHPscript : MonoBehaviour
{
    public float fireTick;
    public float enemyHP;
    public bool onFire;
    public float timeOnFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onFire == true)
        {
            fireTick += Time.deltaTime;
            timeOnFire += Time.deltaTime;

            if (fireTick >= 1)
            {
                fireTick = 0;
                enemyHP -= 1;
            }
            if (timeOnFire >= 7)
            {
                onFire = false;
                timeOnFire = 0;
                fireTick = 0;
            }
        }
    }
}
