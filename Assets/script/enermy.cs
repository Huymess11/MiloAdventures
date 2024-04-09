using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enermy : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public GameObject left;
    public GameObject right;
    Vector2 targetpos;
    void Start()
    {
        targetpos = right.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetpos, speed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("left"))
        {
            targetpos = right.transform.position;
            gameObject.transform.localScale = new Vector3(1,1,1);
        }
        if (col.CompareTag("right"))
        {
         targetpos = left.transform.position;
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(left.transform.position,right.transform.position);
    }
}
