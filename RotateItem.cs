using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    public float speed = 100f;
    public int rotate; //1=x, 2=y, 3=z
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rotate == 1)transform.Rotate(speed * Time.deltaTime, 0f, 0f);
        if(rotate == 2) transform.Rotate(0f, speed * Time.deltaTime, 0f);
        if(rotate == 3) transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}
