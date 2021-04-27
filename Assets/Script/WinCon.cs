using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCon : MonoBehaviour
{
    private float lowestPoint = 0;

    public Text LowestPointText;
    public GameObject looseUI;
    public GameObject PauseUI;

    private bool isPause;

    public Animator transitionAnim;

    IEnumerator LoadScene_i(int s)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene(s);
    }
    


    IEnumerator i_Exit()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSecondsRealtime(1.5f);
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Time.timeScale = 1f;
    }


    // Update is called once per frame
    void Update()
    {
        if(lowestPoint <= GameObject.FindGameObjectWithTag("Player").GetComponent<SpringJoint2D>().distance)
        {
            lowestPoint = GameObject.FindGameObjectWithTag("Player").GetComponent<SpringJoint2D>().distance;
        }


        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health == 0 && Time.timeScale == 1)
        {
            LowestPointText.text = lowestPoint.ToString("F2");
            Time.timeScale = 0f;
            print(Time.timeScale);
            looseUI.SetActive(true);
            AudioListener.pause = true;
            AudioListener.pause = false;

        }
    
        if (Input.GetKeyDown(KeyCode.Escape) && this.GetComponent<UICon>().isStarted)
        {
            isPause = !isPause;
            if (isPause)
            {
                PauseUI.SetActive(true);
                Time.timeScale = 0f;
                print(Time.timeScale);
                AudioListener.pause = true;
            }
            if (!isPause)
            {
                PauseUI.SetActive(false);
                Time.timeScale = 1.0f;
                print(Time.timeScale);
                AudioListener.pause = false;
            }
        }
    }

    public void ReStart()
    {
        StartCoroutine(LoadScene_i(SceneManager.GetActiveScene().buildIndex));
    }


    public void Exit()
    {
        StartCoroutine(i_Exit());
    }

}
