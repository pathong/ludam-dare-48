using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cobwebeffect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if (playerMove != null)
            {
                playerMove.speedMove /= 10;

            }


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if (playerMove != null)
            {
                print("hit");
                playerMove.speedMove *= 10;

            }


        }
    }
}
