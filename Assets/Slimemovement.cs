using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimemovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    private AudioSource audiosr;

    public float range;
    public float thrust;
    private Transform target;
    private bool allowjump=true;
    public int dividerforce = 2;
    int way;
    int direction = 1;

    void Start()
    {
        //audiosr = this.gameObject.GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "leftwall")
        {
            
            way = -1;
            StartCoroutine(Slimejump());
            allowjump = false;
        }
        else if(collision.gameObject.tag == "rightwall")
        {
            way = 1;
            StartCoroutine(Slimejump());
            allowjump = false;
        }
        if (allowjump == false)
        {
            if (collision.gameObject.tag == "rightwall" || collision.gameObject.tag == "leftwall")
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                rb.gravityScale = 0;
                FindObjectOfType<SoundManager>().Play("Slimehit");
                animator.SetBool("IsJump", false);
                allowjump = true;
                transform.rotation = Quaternion.Euler(0,0,90*way);
                
            }
        }
    }
    IEnumerator Slimejump()
    {
         while (true){
            if (Vector2.Distance(transform.position, target.position) <= range)
            {
                animator.SetBool("IsJump", true); 
                yield return new WaitForSeconds(0.5f);
                //audiosr.Play();
                FindObjectOfType<SoundManager>().Play("Slimejump2");
                rb.constraints = RigidbodyConstraints2D.None;
                rb.AddForce(transform.forward * thrust, ForceMode2D.Impulse);
                rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
                if(target.position.y-transform.position.y > 0f)
                {
                    direction = 1;
                }
                else
                {
                    direction = -1;
                }
                rb.AddForce(way*direction*transform.right * thrust/ dividerforce, ForceMode2D.Impulse);
                rb.gravityScale = 1;

                yield return null;
                break;
            }
            yield return null;
        }        
    }
}