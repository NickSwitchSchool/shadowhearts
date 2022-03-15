using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float x;
    public float v;

    public float xCamera;
    public float vCamera;
    public float cameraSens;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(x, 0f, v);

        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
