using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSporn : MonoBehaviour
{
    public GameObject[] fish;
    private float y;
    private int number;

    void Start()
    {
        StartCoroutine("Sporn");
    }


    void Update()
    {

    }

    private IEnumerator Sporn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(8.0f, 10.5f));
            y = Random.Range(-7.0f, 8.0f);
            number = Random.Range(0, fish.Length);
            Instantiate(fish[number], new Vector3(transform.position.x, y, 0), transform.rotation);
        }
    }
}
