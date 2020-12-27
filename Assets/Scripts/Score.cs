using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour // GUIに付ける
{
    private Text ScoreTxt;
    private ScoreAdd scoreAdd;
    private string ScoreString;
    private string scoreObj = "ScoreAdd";// スコアを加算するオブジェクトの名前
    private void　Awake()
    {
        ScoreTxt = this.GetComponent<Text>();
        scoreAdd = GameObject.Find(scoreObj).GetComponent<ScoreAdd>();
    }
    //TOST
    private void Update()
    {
        ScoreString =scoreAdd.Score().ToString();
        ScoreTxt.text = ScoreString;
    }
}
