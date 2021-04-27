using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private float rateMonster;
    public float timeSpawnMons;
    public float defaultTimeSpawnMons;
    //float amount_mounster;
    //float max_amount_monster;

    



    public float[] rateDrop;
    public GameObject[] Ore;
    private int direction;
    private float random_y;
    private int number;
    private float rate;

    private SpringJoint2D rope;


    public GameObject spike;
    public GameObject slime;
    public GameObject spider;
    public GameObject bat;
    public GameObject[] rock;
    public GameObject cockWeb;



    private const float Player_dis_spawn_level_part = 200f;
    public Transform wall_start;
    public Transform next_wall;
    public GameObject player;

    private Vector3 lastEndPosition;

    private void Awake()
    {

        
        lastEndPosition = wall_start.Find("endPoint").position ;
        //int startingSpawnPart = 5;
        SpawnOre();
        SpawnPart();


    }
    // Start is called before the first frame update 
    void Start()                
    {
        defaultTimeSpawnMons = Random.Range(10, 30);
        timeSpawnMons = defaultTimeSpawnMons;
        rateMonster = 40;       
        rateDrop = new float[5];

        rope = player.GetComponent<SpringJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(timeSpawnMons > 0) 
        {
            timeSpawnMons -= 1 * Time.deltaTime;
        }
        if(timeSpawnMons <= 0)
        {
            SpawnMonster();
            timeSpawnMons = Random.Range(3, defaultTimeSpawnMons);
        }


        if (player.GetComponent<SpringJoint2D>().distance % 100 >= 0 && player.GetComponent<SpringJoint2D>().distance % 100 <= 0.04f && player.GetComponent<SpringJoint2D>().distance >= 80)
        {
            if(defaultTimeSpawnMons < 4)
            {
                defaultTimeSpawnMons -= 1;
            }
            rateMonster += 1f;
        }
        

        rateDrop[0] = 85 - rope.distance/20;
        rateDrop[1] = 13 - rope.distance / 50;
        rateDrop[2] = 3;
        rateDrop[3] = 1 + rope.distance / 20;
        rateDrop[4] = .5f + rope.distance / 50;
        if (player.transform.position.y - lastEndPosition.y < Player_dis_spawn_level_part)
        {
            SpawnPart();
            SpawnOre();
            if(player.GetComponent<SpringJoint2D>().distance >= 14)
            {
                SpawnMonster();

            }
        }
    }
    private void SpawnPart()
    {
        Transform lastWallPartTransform = SpawnPart(lastEndPosition);
        lastEndPosition = lastWallPartTransform.Find("endPoint").position;
        SpawnOre();
    }
    private Transform SpawnPart(Vector3 spawnPos)
    {
        Transform wallTransform = Instantiate(next_wall, spawnPos, Quaternion.identity);
        return wallTransform;
    }

    void SpawnMonster()
    {
        float randomNum = Random.Range(0, 100);
        if (randomNum <= rateMonster)
        {
            int index_monster = Random.Range(0, 6);
            print(index_monster);
            if (index_monster == 0)//spike
            {
                print("spawn spike");
                int option = Random.Range(0, 2);
                if(option == 0)
                {
                    float random_y = Random.Range(player.transform.position.y - 5, player.transform.position.y - 15);
                    Instantiate(spike, new Vector3(-1.2f, random_y, -3), Quaternion.Euler(0, 0, 0));
                }
                if (option == 1)
                {
                    float random_y = Random.Range(player.transform.position.y - 5, player.transform.position.y - 15);
                    Instantiate(spike, new Vector3(1.2f, random_y, -3), Quaternion.Euler(0, -180, 0));
                }
            }
            if (index_monster == 1)//slime
            {
                print("spawn slime");

                direction = Random.Range(0, 2);
                random_y = Random.Range(player.transform.position.y - 5, player.transform.position.y - 10);
                if (direction == 0)
                {
                    Instantiate(slime, new Vector3(-1.4f, random_y, -3), Quaternion.Euler(0, 0, -90));
                    return;
                }
                if (direction == 1)
                {
                    Instantiate(slime, new Vector3(1.4f, random_y, -3), Quaternion.Euler(0, 0, 90));
                }
            }
            if (index_monster == 2)//spider
            {
                print("spawn spider");

                float random_y = Random.Range(player.transform.position.y + 5, player.transform.position.y + 10);
                float random_x = Random.Range(-1.3f, 1.3f);

                Instantiate(spider, new Vector2(random_x, random_y), Quaternion.identity);
            }
            if (index_monster == 3)//bat
            {
                print("spawn bat");

                direction = Random.Range(0, 2);

                if (direction == 0)
                {
                    float random_y = Random.Range(player.transform.position.y + 5, player.transform.position.y + 10);
                    float random_x = Random.Range( -10, 10);
                    Instantiate(bat, new Vector3(random_x, random_y, -4), Quaternion.identity);
                }
                if (direction == 1)
                {
                    float random_y = Random.Range(player.transform.position.y - 5, player.transform.position.y - 10);
                    float random_x = Random.Range(player.transform.position.x - 10, player.transform.position.x + 10);
                    Instantiate(bat, new Vector3(random_x, random_y, -4), Quaternion.identity);
                }

                
            }
            if (index_monster == 4)//rock1
            {
                print("spawn rock");
                int index_rock = Random.Range(0, 3);
                float random_x = Random.Range(-1.3f, 1.3f);
                Instantiate(rock[index_rock], new Vector2(random_x, player.transform.position.y + 10), Quaternion.identity);
            }
            //}
            if (index_monster == 5)//cock web
            {
                print("spawn cock web");

                float random_x = Random.Range(-1.3f, 1.3f);
                Instantiate(cockWeb, new Vector2(random_x, player.transform.position.y - 10), Quaternion.identity);


            }

        }
    }
    void SpawnOre()
    {
        number = Random.Range(0, 2);
        

        for(int i = 0; i< 1; i++)
        {
            int total = 0;
            foreach (int weight in rateDrop)
            {
                total += weight;
            }
            float ranDomNum = Random.Range(0, total);
           
            for (int j = 0; j< rateDrop.Length;j++)
            {
                if (ranDomNum <= rateDrop[j])
                {
                    direction = Random.Range(0, 2);
                    random_y = Random.Range(player.transform.position.y - 10, player.transform.position.y - 300);
                    if (direction == 0)
                    {
                        Instantiate(Ore[j], new Vector3(-1.4f, random_y, -3), Quaternion.Euler(0, 0, -90));
                        return;
                    }
                    if (direction == 1)
                    {
                        Instantiate(Ore[j], new Vector3(1.4f, random_y, -3), Quaternion.Euler(0, 0, 90));
                    }
                }
                if(ranDomNum > rateDrop[j])
                {
                    ranDomNum -= rateDrop[j];
                }
            }


        
        }
    }



}
