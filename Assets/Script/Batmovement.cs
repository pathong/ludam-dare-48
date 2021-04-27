using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batmovement : MonoBehaviour
{
    public float speed;
    public float time = 1.5f;

    private Transform target;
    private int direction = 1;

    //public float range = 1f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
    }

    // Update is called once per frame
   void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime*direction);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            StartCoroutine(Wait());
            
        }
    }

    private IEnumerator Wait()
    {
        direction = -1;
        speed = speed * 1.5f;
        yield return new WaitForSeconds(time);
        direction = 1;
        speed = speed / 1.5f;
    }
}