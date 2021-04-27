using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreScript : MonoBehaviour
{
    public int OreCoin;
    public GameObject Par;
    public float max_dist = 2;
    private PlayerMove playerMove;
    private Player playerProfile;
    private float count;
    public int max_count;
    // Start is called before the first frame update
    void Start()
    {
        
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        playerProfile = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count -= .2f * Time.deltaTime;
        if(count >= max_count)
        {
            playerProfile.increse_coin(OreCoin);
            if(this.gameObject.name == "red" || this.gameObject.name == "red(Clone)")
            {
                if(playerProfile.health < 3)
                {
                    playerProfile.health += 1;

                }
            }
            if(this.gameObject.name == "yellow" || this.gameObject.name == "yellow(CLone)")
            {
                playerProfile.coin += 10;
            }
            if(this.gameObject.name == "purple" || this.gameObject.name == "purple(Clone)")
            {
                playerProfile.test_light();
         

            }
            Destroy(gameObject);
        }
        if(count <= 0)
        {
            count = 0;
        }
    }

    public void OnMouseDown()
    {
        if ( playerProfile.time_dig <= 0 && playerMove.isWall && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, gameObject.transform.position) < GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().distance)
        {
            FindObjectOfType<SoundManager>().Play("PlayerDig");
            count += 1;
            Instantiate(Par, transform.position, Quaternion.identity);
            playerProfile.time_dig = playerProfile.defalt_time_dig;
            playerProfile.ShakeIt();
            playerProfile.i_suffle();
        }

    }




}
