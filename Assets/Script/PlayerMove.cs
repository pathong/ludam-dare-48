using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public int speed_pickaxe;



    public Text textShow;
    private bool facingRight;
    private SpringJoint2D dist_join;
    [HideInInspector]
    public bool isWall;
    private bool isHold;
    private float x_speed = 1f;
    private float y_speed = .2f;
    Rigidbody2D rb;

    bool isTouchingFront;
    public Transform frontCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    void Start()
    {
        speed_pickaxe = 1;
        facingRight = false;
        isHold = false;
        isWall = false;
        rb = GetComponent<Rigidbody2D>();
        dist_join = gameObject.GetComponent<SpringJoint2D>();
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "leftwall" || collision.gameObject.tag == "rightwall")
        {
            isWall = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "leftwall" || collision.gameObject.tag == "rightwall")
        {
            isWall = false;
        }
    }
    void FixedUpdate()
    {
        textShow.text = dist_join.distance.ToString("F2") + " m";

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (isWall)
        {
            rb.gravityScale = 0;
        }
        if (!isWall)
        {
            dist_join.distance += this.gameObject.GetComponent<Player>().speedMove * Time.deltaTime;
            rb.gravityScale = 1;
        }

        if (x > 0 || x < 0)
        {
            rb.velocity = new Vector3(x * x_speed, rb.velocity.y, 0);
        }
        if (y > 0)
        {

            rb.velocity = new Vector3(rb.velocity.x, y * y_speed, 0);
            dist_join.distance -= (this.gameObject.GetComponent<Player>().speedMove +.5f) * Time.deltaTime;
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            
        }


        if (x < 0 && !facingRight)
        {
            Flip();
        }
        else if (x > 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }
    //print(isWall);
    //if(isWall && Input.GetKeyDown(KeyCode.Space))
    //{
    //    isHold = !isHold;
    //}
    //if (isHold)
    //{
    //    rb.gravityScale = 0;
    //}
    //if (!isHold)
    //{
    //    rb.gravityScale = 1;
    //    RopeMove();
    //}




}

