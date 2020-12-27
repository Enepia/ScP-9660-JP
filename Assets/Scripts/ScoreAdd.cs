using System.Collections;
using UnityEngine;

public class ScoreAdd : MonoBehaviour
{
    private int ScoreNum = 0;
    private int addScore = 0;// スコアに一度に加算する量
    private string addTag = "Add"; // 触れるとスコアを加算するオブジェクトのタグ名

    void Awake()
    {
        ScoreNum = 0;
        addScore = 1;
        StartCoroutine(RunAddScore());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameObject.FindWithTag(addTag))
        {
            AddScore(addScore * 100);
        }
    }

    private void AddScore(int add)// スコア加算
    {
        ScoreNum = ScoreNum + add;
    }

    private IEnumerator RunAddScore()// 走った距離によるスコア加算
    {
        while (true)
        {
            AddScore(addScore);
            yield return new WaitForSeconds(0.5f);// 0.5秒に1回スコア加算
        }
    }

    public void StopRunAddScore()// 走った距離によるスコア加算のコルーチン停止
    {
        StopCoroutine(RunAddScore());
    }

    public int Score()
    {
        return ScoreNum;
    }
}
