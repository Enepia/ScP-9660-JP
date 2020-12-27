using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private float speed = 0.03f;// プレイヤーの移動速度
    private float jumpHeight = 1.0f;// ジャンプの高さ
    private float rayLength = 0f;// レイの長さ
    private float nearLength = 1.0f;// 近距離攻撃時のレイの長さ
    private float farLength = 10.0f;// 遠距離攻撃時のレイの長さ
    private RaycastHit2D hit;// レイに当たったオブジェクト
    private string enemyTagName = "Enemy";// エネミーのタグの名前
    private string bossTagName = "Boss";// ボスエネミーのタグの名前
    private string groundTagName = "Floor";// 地面のタグの名前
    private string scoreObj = "ScoreAdd";// スコアを加算するオブジェクトの名前
    private string rankingText = "RankingText";
    private string input = "InputField";
    private string jumpAnimFlag = "JumpFlag";
    private string attackAnimFlag = "AttackFlag";
    private string jumpAttackAnimFlag = "JumpAttackFlag";
    private bool jumpFlag = false;// ジャンプ中かどうか
    private new Rigidbody2D rigidbody2D;
    private ScoreAdd scoreAdd;
    private HighScoreControll highScoreControll;
    private NameInput nameInput;
    private Animator animator;

    private void Start()
    {
        rayLength = nearLength;
        jumpFlag = false;
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        scoreAdd = GameObject.Find(scoreObj).GetComponent<ScoreAdd>();
        highScoreControll = GameObject.Find(rankingText).GetComponent<HighScoreControll>();
        nameInput = GameObject.Find(input).GetComponent<NameInput>();
        animator = this.gameObject.GetComponent<Animator>();
        StartCoroutine(Run(speed));
    }

    private void Update()
    {
        RayHitJudge();
        Jump();
    }

    private IEnumerator Run(float runSpeed)// 走る
    {
        while (true)
        {
            transform.Translate(runSpeed, 0f, 0f);
        }
    }

    private void Jump()// ジャンプ
    {
        if (Application.isEditor)// エディタで実行中
        {
            if (Input.GetMouseButtonDown(0) && !jumpFlag)// クリックした瞬間
            {
                rigidbody2D.AddForce(Vector2.up * jumpHeight);
                jumpFlag = true;
                animator.SetBool(jumpAnimFlag, true);
            }
        }
        else// 実機で実行中
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);// タッチ情報の取得
                if (touch.phase == TouchPhase.Began && !jumpFlag)// タッチした瞬間
                {
                    rigidbody2D.AddForce(Vector2.up * jumpHeight);
                    jumpFlag = true;
                    animator.SetBool(jumpAnimFlag, true);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)// プレイヤーが何かに当たったか判定
    {
        if (other.gameObject.CompareTag(groundTagName))// 地面に当たったら
        {
            if (jumpFlag)
            {
                animator.SetBool(jumpAnimFlag, false);
            }
            else
            {
                jumpFlag = false;
            }
        }
        else if (other.gameObject.CompareTag(enemyTagName) || other.gameObject.CompareTag(bossTagName))// エネミーに当たったら
        {
            GameOver();// ゲームオーバー
        }
    }

    private void RayHitJudge()// レイが何かに当たったか判定
    {
        hit = Physics2D.Raycast(this.transform.position, Vector2.right, rayLength);
        if (hit.collider.gameObject.tag == enemyTagName || hit.collider.gameObject.tag == bossTagName)// レイがエネミーに当たったら
        {
            if (rayLength == nearLength)
            {
                NearAttack(hit);
            }
            else if (rayLength == farLength)
            {
                FarAttack(hit);
            }
        }
    }

    private bool FarRayHitJudge()// 遠距離攻撃のレイが敵に当たっているか判定
    {
        hit = Physics2D.Raycast(this.transform.position, Vector2.right, farLength);
        if (hit.collider.gameObject.tag == enemyTagName || hit.collider.gameObject.tag == bossTagName)// レイがエネミーに当たったら
        {
            return true;
        }
        return false;
    }

    private void NearAttack(RaycastHit2D enemy)// 近距離攻撃
    {
        if (jumpFlag)
        {
            animator.SetBool(jumpAttackAnimFlag, true);
            animator.SetBool(jumpAttackAnimFlag, false);
        }
        else
        {
            animator.SetBool(attackAnimFlag, true);// 攻撃アニメーション再生
            animator.SetBool(attackAnimFlag, false);
        }
        EnemyControll enemyControll = enemy.collider.gameObject.GetComponent<EnemyControll>();
        if (enemy.collider.gameObject.tag == enemyTagName)// 雑魚エネミーなら
        {
            enemyControll.EnemyHPMinus();
        }
        else if (enemy.collider.gameObject.tag == bossTagName)// ボスエネミーなら
        {
            enemyControll.EnemyBossHPMinus();
        }
    }

    private IEnumerator FarAttack(RaycastHit2D enemy)// 遠距離攻撃
    {
        EnemyControll enemyControll = enemy.collider.gameObject.GetComponent<EnemyControll>();
        while (FarRayHitJudge())
        {
            if (enemy.collider.gameObject.tag == enemyTagName)// 雑魚エネミーなら
            {
                enemyControll.EnemyHPMinus();
                if (enemyControll.EnemyHPReturn() <= 0)// 雑魚エネミーのHPが0になったら
                {
                    break;
                }
            }
            else if (enemy.collider.gameObject.tag == bossTagName)// ボスエネミーなら
            {
                enemyControll.EnemyBossHPMinus();
                if (enemyControll.EnemyBossHPReturn() <= 0)// ボスエネミーのHPが0になったら
                {
                    break;
                }
            }
        }
        yield break;
    }

    private void GameOver()
    {
        scoreAdd.StopRunAddScore();// 走った距離によるスコア加算を停止
    }

    private void Next()
    {
        highScoreControll.ScoreSet(nameInput.InputTextReturn(), scoreAdd.Score());
    }
}
