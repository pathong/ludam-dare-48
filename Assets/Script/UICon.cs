using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICon : MonoBehaviour
{

    public GameObject Option;
    public bool isStarted;
    public GameObject all;

    // Start is called before the first frame update
    void Start()
    {
        isStarted = false;
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPanel()
    {
        Animator animator = all.GetComponent<Animator>();
        if(animator != null)
        {
            isStarted = true;
            animator.SetTrigger("open");
            StartCoroutine(wait());
            Time.timeScale = 1;
        }
    }

    public void OpenOption()
    {
        Option.SetActive(true);


    }
    public void CloseOption()
    {
        Option.SetActive(false);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);

    }


}
