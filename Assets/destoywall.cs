using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoywall : MonoBehaviour
{
    private Transform target;
    public float destroyrange = 1f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y-target.position.y >= destroyrange)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
