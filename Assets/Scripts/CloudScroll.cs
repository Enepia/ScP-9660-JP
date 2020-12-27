using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScroll : MonoBehaviour
{
    Vector3 cloud;
    // Start is called before the first frame update
    void Start()
    {
        cloud = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.015f, 0f, 0f);
        cloud = this.transform.position;
        if (cloud.x < -15)
        {
            Destroy(this.gameObject);
        }
    }
}
