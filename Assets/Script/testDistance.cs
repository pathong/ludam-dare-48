using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDistance : MonoBehaviour
{
    private DistanceJoint2D dist_join;
    private float dist;
    // Start is called before the first frame update
    void Start()
    {
        dist_join = gameObject.GetComponent<DistanceJoint2D>();
        dist = dist_join.distance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
