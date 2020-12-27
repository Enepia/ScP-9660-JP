using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCollider : MonoBehaviour
{
    public bool stageCollision = false;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StageCreate());
        }
    }

    private IEnumerator StageCreate()
    {
        stageCollision = true;
        yield return new WaitForSeconds(0.005f);
        stageCollision = false;
        yield break;
    }
}
