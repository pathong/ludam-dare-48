using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spidermovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private Transform target;
    public bool done = true;
    public int direction=1;
    public float range=0.5f;
    public float time=1;
    //public bool forcebreak = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Sounds());
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, target.position.y), speed * Time.deltaTime*direction);
        transform.position = new Vector2(target.position.x, transform.position.y);
        //RotateTowards(target.position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )//&& done
        {
            StartCoroutine(Wait());
            //done = false;
            //transform.position = new Vector2(transform.position.x, transform.position.y+range);
            //FindObjectOfType<SoundManager>().Play("Spiderjumpingoff");

        }
    }
    IEnumerator Sounds()
    {
        while (true)
        {
            if (done)
            {
                FindObjectOfType<SoundManager>().Play("Spiderclawing");
            }
            yield return new WaitForSeconds(0.5f);
            yield return null;
        }
    }
    private IEnumerator Wait()
    {
        direction = -1;
        speed = speed * 1.5f;
        yield return new WaitForSeconds(time);
        direction = 1;
        speed = speed / 1.5f;
        yield return null;
    }
    /*private void RotateTowards(Vector2 target)
    {
        float offset = 90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }*/
}