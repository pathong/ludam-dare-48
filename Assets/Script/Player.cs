using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool canAttack;

    private AudioSource _audio;

    public AudioClip dig_sound;
    public AudioClip attack_sound;

    public float speedMove;

    public float dmg_time;
    public float default_dmg_time = 2;

    Vector3 cameraInitialPosition;
    public float shakeMagnetude = 0.01f, shakeTime = 0.01f;
    public Camera mainCamera;

    public Sprite normal;
    public Sprite dig;

    
    public float defalt_time_dig = .04f;
    public float time_dig;

    public int health = 3;
    public Image[] hearth; 

    public float distance = 2;

    [HideInInspector]
    public int level_distance = 1;
    [HideInInspector]
    public int level_light = 1;
    [HideInInspector]
    public int level_speed_pickaxe = 1;

    public bool playsound = true;

    public UnityEngine.Experimental.Rendering.Universal.Light2D light;
    public Text text_show;
    
    public int coin;
    // Start is called before the first frame update
    void Start()
    {
        _audio = this.GetComponent<AudioSource>();

        speedMove = 2;

        default_dmg_time = 2;
        dmg_time = default_dmg_time;
        shakeMagnetude = 0.03f;
        shakeTime = 0.1f;
        defalt_time_dig = .6f;
        time_dig = defalt_time_dig;
    }

    // Update is called once per frame
    void Update()
    {


        bool isHold = this.GetComponent<PlayerMove>().isWall;

        if (isHold) { canAttack = false; }
        if (!isHold) { canAttack = true; }


        if (dmg_time > 0)
        {
            dmg_time -= Time.deltaTime;
        }
        if(dmg_time <= 0)
        {
            dmg_time = 0;
        }

        if(health == 0)
        {
            if (playsound)
            {
                FindObjectOfType<SoundManager>().Play("Playerdeath");
                playsound = false;
            }
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        for (int i = 0; i < hearth.Length; i++)
        {
            if(i +1 > health)
            {
                hearth[i].color = Color.gray;
            }
            else
            {
                hearth[i].color = Color.red;
            }
        }


        if (Input.GetKey(KeyCode.Space) && time_dig == 0 && canAttack)
        {
            i_suffle();
        }
        {

        }

        if (Input.GetMouseButtonDown(0) )
        {
            if(time_dig == 0)
            {
                StartCoroutine(ChangeSprite());
            }

        }
        text_show.text = "0 : " + coin.ToString();
        if(time_dig > 0)
        {
            time_dig -= Time.deltaTime;
        }
        if(time_dig <= 0)
        {
            time_dig = 0;
        }
    }

    public IEnumerator ChangeSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = dig;
        yield return new WaitForSecondsRealtime(defalt_time_dig);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = normal;
    }
    public void increse_coin(int c)
    {
        coin += c;
    }
    public void decrese_coin(int c)
    {
        coin -= c;
    }
    public void TakeDamage()
    {
        health -= 1;
        FindObjectOfType<SoundManager>().Play("Playerhit");
    }


    public void ShakeIt()
    {
        cameraInitialPosition = Camera.main.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shakeTime);
    }

    void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * shakeMagnetude * 2 - shakeMagnetude;
        float cameraShakingOffsetY = Random.value * shakeMagnetude * 2 - shakeMagnetude;
        Vector3 cameraIntermadiatePosition = Camera.main.transform.position;
        cameraIntermadiatePosition.x += cameraShakingOffsetX;
        cameraIntermadiatePosition.y += cameraShakingOffsetY;
        Camera.main.transform.position = cameraIntermadiatePosition;
    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        Camera.main.transform.position = cameraInitialPosition;
    }


     public void Appear()
    {
        int round = 4;
        for (int i = 0; i < round; i++)
        {
            StartCoroutine(Suffle());
        }
    }

    public IEnumerator Suffle()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSecondsRealtime(.3f);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public IEnumerator in_light()
    {
        light.pointLightOuterRadius += 10;
        yield return new WaitForSeconds(1.5f);
        light.pointLightOuterRadius -= 10;
    }
    public void test_light()
    {
        StartCoroutine(in_light());
    }

    public void i_suffle()
    {
        StartCoroutine(ChangeSprite());
    }

}
