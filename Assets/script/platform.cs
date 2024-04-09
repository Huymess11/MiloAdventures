using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public GameObject left;
    public GameObject right;
    Vector2 targetPos;

    void Start()
    {
        targetPos = right.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("left"))
        {
            targetPos = right.transform.position;

        }
        if (col.CompareTag("right"))
        {
            targetPos = left.transform.position;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(left.transform.position, right.transform.position);
    }

}
