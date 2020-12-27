using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("Des");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0.1f, 0f, 0f);
    }

    IEnumerator Des()
    {
        yield return new WaitForSeconds(20.0f);
        Destroy(this.gameObject);
    }
}
