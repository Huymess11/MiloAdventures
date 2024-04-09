using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    private int score;
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private bool isGround;
    private Animator ani;
    public UI ui;
    private bool isGameOver;
    private Vector2 spawnPos;
    public int MaxJump;
    public int jumpleft;
    public Heart heart;
    public bool right;
    public bool left;
    private bool canDash = true;
    private bool isDashing;
    float dashPower = 25f;
    float dashTime = 0.2f;
    float dashCoolDown = 1f;
    public TrailRenderer tr;
    AudioManager audio;
    public GameObject dust;
    private bool canMove;
    private GameManager gm;

    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        audio = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        ui = FindObjectOfType<UI>();
        heart = FindObjectOfType<Heart>();
        tr = GetComponent<TrailRenderer>();
        audio = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        if (canMove== true)
        {
            if (isDashing)
            {
                return;
            }
            Move();
            Jump();
            MoveMoble();
            if (Input.GetKeyDown(KeyCode.X) && canDash)
            {
                audio.PlaySFX(audio.dash);
                StartCoroutine(Dash());
            }
        }
        
    }
    private void Move()
    {
        float move = Input.GetAxisRaw("Horizontal");
 
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        
       

        int direction = 0;
        if (move > 0)
        {
            direction = 1;
        }
        else if (move < 0)
        {
            direction = -1;
        }

        if (move != 0)
        {
            if (isGround) { CreateDust(); }
            
            transform.localScale = new Vector3(direction, 1, 1);
        }
        else if( move  == 0 || !isGround)
        {
            StopDust();
        }
        ani.SetBool("run", move != 0);

    }
    private void Jump()
    {
        if(isGround )
        {
            jumpleft = MaxJump;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpleft > 0)
        {
            audio.PlaySFX(audio.Jump);
            jumpleft--;
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            ani.SetTrigger("jump");
            isGround = false;
        }
        

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.CompareTag("ground"))
        //{
        //    isGround = true;
        //}
        if(col.gameObject.CompareTag("spike") || col.gameObject.CompareTag("Enemy")||col.gameObject.CompareTag("deadzone"))
        {
            audio.PlaySFX(audio.dead);
            transform.position = spawnPos;
            heart.TakdDame(1);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ground"))
        {
            isGround = true;
        }

        if (col.CompareTag("coin"))
        {
            audio.PlaySFX(audio.coin);
            Destroy(col.gameObject);
            UpScore();
        }
        if (col.CompareTag("checkpoint"))
        {
            audio.PlaySFX(audio.Checkpoint);
            spawnPos = col.gameObject.transform.position;
        }
        if(col.CompareTag("platform")){
            isGround = true;
            gameObject.transform.SetParent(col.transform);
        }
        if(col.CompareTag("saw")){
            audio.PlaySFX(audio.dead);
            transform.position = spawnPos;
            heart.TakdDame(1);
        }
        if (col.CompareTag("Finish"))
        {
            audio.PlaySFX(audio.Victory);
            Time.timeScale = 0f;
            ui.ShowNextLevel(true);
            PlayerPrefs.SetInt("totalCoin",PlayerPrefs.GetInt("totalCoin",0)+score);
            PlayerPrefs.SetInt("levelAt", SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("platform"))
        {
            gameObject.transform.SetParent(null);
        }
    }
    public void UpScore()
    {
        score++;
    }
    public int CurScore()
    {
        return score;
    }
    public bool CurState()
    {
        return isGameOver;
    }
    public void SetCurState(bool value)
    {
        isGameOver = value;
    }
    /*
    public void DownRight()
    {
        right = true;
    }
    public void UpRight()
    {
        right = false;
    }
    public void DownLeft()
    {
        left = true;
    }
    public void UpLeft()
    {
        left = false;
    }
    */
    public void CreateDust()
    {
        dust.SetActive(true);
    }
    public void StopDust()
    {
        dust.SetActive(false);
    }
    public void MoveMoble()
    {
        if (right)
        {
            rb.velocity = new Vector2(speed,rb.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (left)
        {
            rb.velocity = new Vector2( (-speed), rb.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void JumpButton()
    {
        if (isGround)
        {
            rb.velocity = new Vector2(0, 1) * jumpForce;
            ani.SetTrigger("jump");
            isGround = false;
        }
    }
   
    public void stopPlayer()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float gravity = rb.gravityScale;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(transform.localScale.x * dashPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        rb.velocity = new Vector2(0f, 0f);
        rb.gravityScale = gravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }
    public void CanMove()
    {
        canMove = true;
    }
    public void CanNotMove()
    {
        canMove = false;
    }
}
