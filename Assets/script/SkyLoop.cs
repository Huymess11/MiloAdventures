using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyLoop : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed*Time.deltaTime, transform.position.y);
        if(transform.position.x < -27.43f )
        {
            transform.position = new Vector2(24f, transform.position.y);
        }
    }
}
