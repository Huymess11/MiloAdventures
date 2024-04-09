using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class spikehead : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody2D rb;
    public GameObject left;
    public GameObject right;
    Vector2 targetPos;
    bool isground;
    Animator ani;
    void Start()
    {
        targetPos = right.transform.position;
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(move());
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("left"))
        {
            targetPos = right.transform.position;
            isground = false;

        }
        if (col.CompareTag("right"))
        {
            targetPos = left.transform.position;
            isground = true;

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(left.transform.position, right.transform.position);
    }
    IEnumerator move()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (isground==true)
        {
            speed = 0;
            ani.SetTrigger("ground");
            yield return new WaitForSeconds(1f);
            isground = false;
            speed = 2;
            
        }
        
    }

}
