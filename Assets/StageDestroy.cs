using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDestroy : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(OtherStageDestroy());
    }

    private IEnumerator OtherStageDestroy()
    {
        yield return new WaitForSeconds(15);
        Destroy(this.gameObject);
        yield break;
    }
}
