using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject par;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private bool hold = false;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space"))
            {
                hold = false;
            }
        if (this.GetComponent<Player>().time_dig == 0 && Input.GetKey(KeyCode.Space) && this.GetComponent<Player>().canAttack && !hold)
        {
            hold = true;
            
                Collider2D[] enemiesToDmg = Physics2D.OverlapCircleAll(attackPos.position, this.GetComponent<Player>().distance-1, whatIsEnemies);
            if(enemiesToDmg.Length != 0)
            {
                FindObjectOfType<SoundManager>().Play("PlayerAttack");
                this.GetComponent<Player>().ShakeIt();
            }

            enemiesToDmg[0].GetComponent<destroyobstacle>().TakeDamage();
            Instantiate(par, enemiesToDmg[0].transform.position, Quaternion.identity);

            this.GetComponent<Player>().time_dig = this.GetComponent<Player>().defalt_time_dig;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, this.GetComponent<Player>().distance-1);
    }
}
