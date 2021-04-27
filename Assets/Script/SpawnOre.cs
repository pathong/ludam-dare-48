using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOre : MonoBehaviour
{
    private int direction;
    private float random_y;
    private int number;

    public GameObject player;
    public SpringJoint2D rope;


    public GameObject Ore1;
    private float minOre1;
    private float maxOre1;
    public GameObject Ore2;
    private float minOre2;
    private float maxOre2;
    public GameObject Ore3;
    private float minOre3;
    private float maxOre3;
    public GameObject Ore4;
    private float minOre4;
    private float maxOre4;
    public GameObject Ore5;
    private float minOre5;
    private float maxOre5;
    // Start is called before the first frame update
    void Start()
    {
        rope = gameObject.GetComponent<SpringJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        number = Random.Range(0, 5);
        direction = Random.Range(0, 1);
        random_y = Random.Range(player.transform.position.x + 200, player.transform.position.x + 400);
    }
}
