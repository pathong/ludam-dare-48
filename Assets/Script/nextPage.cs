using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextPage : MonoBehaviour
{
    public GameObject[] t;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < t.Length; i++)
        {
            if(i == count)
            {
                t[i].SetActive(true);
            }
            else
            {
                t[i].SetActive(false);
            }
        }
    }

    public void next()
    {
        if(count < t.Length -1)
        {
            count += 1;
            print(count);
        }
    }
}
