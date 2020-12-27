using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCreate : MonoBehaviour
{
    public GameObject[] Cloud;
    private int number;
    private float x;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(11.5f, 11.5f);
        y = Random.Range(-5.0f, 5.0f);
        number = Random.Range(0, Cloud.Length);
        Instantiate(Cloud[number], new Vector3(x, y, 0), transform.rotation);
        StartCoroutine(Create());
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Create()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5.0f,10.0f));
            x = Random.Range(12.0f, 20.0f);
            y = Random.Range(-5.0f, 5.0f);
            number = Random.Range(0, Cloud.Length);
            Instantiate(Cloud[number], new Vector3(x, y, 0), transform.rotation);
        }
    }
}
