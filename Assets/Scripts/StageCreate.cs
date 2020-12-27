using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreate : MonoBehaviour
{
    public GameObject[] stage;
    private float x;
    private float y;
    private float z;
    private float move;
    private int number;
    Vector3 look;
    private bool stageCollision = false;
    private Transform stageCreateTransform;
    private bool stageInstantiateIs=false; //ステージ生成されたかどうか
    void Start()
    {
        x = 26.67f;
        y = -1.051671f;
        z = -0.9605446f;
        stageCreateTransform = this.transform;
    }

  
    void Update()
    {
        if (stageCollision==true)
        {
            number = Random.Range(0, stage.Length);
            Instantiate(stage[number], new Vector3(x, y, z), Quaternion.identity);
            x += 26.67f;
            stageInstantiateIs = true;
            stageCollision = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 pos = stageCreateTransform.position;
            pos.x += 26.67f;
            stageCreateTransform.position = pos;
            StageSporn();
            stageCollision = true;
            if (stageInstantiateIs == true)
            {
                stageInstantiateIs = false;
            }
        }
    }

    //ステージ生成する時の判定　　※２個生成しちゃう可能性大　ロジックわからんかったスマンコ
    private void StageSporn()
    {

    }

}
