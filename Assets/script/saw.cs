using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class saw : MonoBehaviour
{
    public GameObject[] pos;
    public float speed;
    Vector2 targetpos;
    int index=0;
    int max = 3;
    // Start is called before the first frame update
    void Start()
    {
       targetpos = pos[index].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (max == 0)
        {
            max = 3;
            index = 0;
        }
        targetpos = pos[index].transform.position;
        transform.position = Vector2.MoveTowards(transform.position, targetpos, speed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("pos")){
            index += 1;
            max -= 1;

        }
    }
}
