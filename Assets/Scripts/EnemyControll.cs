using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    private int enemyHP = 0;
    private int enemyBossHP = 0;
    private float speed = 0.01f;

    private void Start()
    {
        enemyHP = 1;
        enemyBossHP = 10;
    }

    private void FixedUpdate()
    {
        transform.Translate(-speed, 0f, 0f);
        if (enemyBossHP <= 0)
        {
            StartCoroutine(EnemyBossBuster());
        }
        if (enemyHP <= 0)
        {
            EnemyBuster();
        }
    }

    private IEnumerator EnemyBossBuster()
    {
        //ボス撃破アニメーション待機時間
        yield return new WaitForSeconds(5f);
        this.gameObject.SetActive(false);
        yield break;
    }

    private void EnemyBuster()
    {
        this.gameObject.SetActive(false);
    }

    public void EnemyHPMinus()
    {
        enemyHP -= 1;
    }

    public void EnemyBossHPMinus()
    {
        enemyBossHP -= 1;
    }

    public int EnemyHPReturn()
    {
        return enemyHP;
    }

    public int EnemyBossHPReturn()
    {
        return enemyBossHP;
    }
}
