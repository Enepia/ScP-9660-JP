using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySporn : MonoBehaviour
{
    public GameObject[] enemys;
    private float y = 0f;
    private int number = 0;
    private float spornTimeMin = 8.0f;
    private float spornTimeMax = 10.5f;
    private float heightMin = -7.0f;
    private float heightMax = 8.0f;

    void Start()
    {
        StartCoroutine("Sporn");
    }

    private IEnumerator Sporn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spornTimeMin, spornTimeMax));
            y = Random.Range(heightMin, heightMax);
            number = Random.Range(0, enemys.Length);
            Instantiate(enemys[number], new Vector3(transform.position.x, y, 0), transform.rotation);
            yield break;
        }
    }
}
