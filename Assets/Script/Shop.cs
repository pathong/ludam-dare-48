using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private Player player;


    public Text price_distance;
    public Text price_light;
    public Text price_speed;

    public Text lv_distance_text;
    public Text lv_speed_text;
    public Text lv_light_text;




    private int coin_distance = 10;
    
    private int coin_speed_pickage = 20;


    private int coin_potion = 20;

    private int coin_light = 5;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        lv_distance_text.text = "lv " + player.level_distance;
        lv_light_text.text = "lv " + player.level_light;
        lv_speed_text.text = "lv " + player.level_speed_pickaxe;


        if(player.level_distance == 5)
        {
            price_distance.text = "max";
        }
        else
        {
            price_distance.text = coin_distance.ToString();
        }

        if (player.level_light == 5)
        {
            price_light.text = "max";
        }
        else
        {
            price_light.text = coin_light.ToString();

        }

        if (player.level_speed_pickaxe == 5)
        {
            price_speed.text = "max";
        }
        else
        {
            price_speed.text = coin_speed_pickage.ToString();

        }

    }

    public void SpeedPickage()
    {
        if(player.coin >= coin_speed_pickage && player.level_speed_pickaxe < 5 )
        {
            player.level_speed_pickaxe += 1;
            player.decrese_coin(coin_speed_pickage);
            player.defalt_time_dig -= 0.2f;
            coin_speed_pickage *= 2;
        }
    }

    public void Light()
    {
        if(player.coin >= coin_light && player.level_light < 5 )
        {
            player.level_light += 1;
            player.light.pointLightOuterRadius += 2;
            player.decrese_coin(coin_light);
            coin_light *= 2;

        }
    }

    public void Heal()
    {
        if(player.coin >= coin_potion && player.health < 3)
        {
            player.health += 1;
            player.decrese_coin(coin_potion);
        }
    }

    public void distance()
    {
        if(player.coin >= coin_distance && player.level_distance < 5)
        {
            player.level_distance += 1;
            player.distance += .3f;
            player.decrese_coin(coin_distance);
            coin_distance *= 2;
        }
    }
}
