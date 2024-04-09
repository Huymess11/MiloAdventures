using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw1 : MonoBehaviour
{
    public GameObject pos1;
    public GameObject pos2;
    public float speed;
    Vector2 targetpos;
    // Start is called before the first frame update
    void Start()
    {
        targetpos = pos1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("pos1"))
        {
            targetpos = pos2.transform.position;
        }
        else if(col.CompareTag("pos2"))
        {
            targetpos = pos1.transform.position;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pos1.transform.position,pos2.transform.position);
    }
}
