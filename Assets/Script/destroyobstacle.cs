using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyobstacle : MonoBehaviour
{
    public bool destroyselves = false;
    public float destroyrange = 10f;
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().dmg_time == 0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().ShakeIt();
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().TakeDamage();
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Appear();

                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().dmg_time = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().default_dmg_time;
            }

            if (destroyselves)
            {
                Destroy(gameObject);
            }
        }
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) >= destroyrange)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage()
    {
        if(gameObject.tag == "bat")
        {
            FindObjectOfType<SoundManager>().Play("Batdeath");
        }
        else if (gameObject.tag == "slime")
        {
            FindObjectOfType<SoundManager>().Play("Slimedeath");
        }
        else if (gameObject.tag == "spider")
        {
            FindObjectOfType<SoundManager>().Play("Spiderdeath");
        }
        Destroy(gameObject);
        

    }
}
