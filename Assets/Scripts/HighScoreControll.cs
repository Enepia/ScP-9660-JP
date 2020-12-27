using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class HighScoreControll : MonoBehaviour
{
    private NCMBObject scoreRank;
    private NCMBQuery<NCMBObject> query;
    private string nameless = "NameLess";
    private string name = "Name";
    private string score = "Score";
    private string scoreRanking = "ScoreRanking";
    private string myScore = "MyScore";
    private int limit = 5;
    private Text text;
    private Text myText;
    private string id;
    // Start is called before the first frame update
    private void Start()
    {
        text = this.gameObject.GetComponent<Text>();
        myText = GameObject.Find(myScore).GetComponent<Text>();
        scoreRank = new NCMBObject(scoreRanking);
        query = new NCMBQuery<NCMBObject>(scoreRanking);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreSet(string name, int score)
    {
        scoreRank[this.name] = name;
        scoreRank[this.score] = score;
        scoreRank.SaveAsync((NCMBException e) =>
        {
            if (e == null)
            {
                id = scoreRank.ObjectId;
            }
        }
        );
        ScoreRankingGet();
    }

    private void ScoreRankingGet()
    {
            query.Limit = limit;
            query.OrderByDescending(score);
        query.FindAsync((List<NCMBObject> scoreList, NCMBException e) =>
        {
            if (e == null)
            {
                for (int i = 0; i < query.Limit; i++)
                {
                    if (i == 0)
                    {
                        text.text += i + 1 + "st  " + scoreList[i][name] + "  " + scoreList[i][score] + "\n" + "\n";
                    }
                    else if (i == 1)
                    {
                        text.text += i + 1 + "nd  " + scoreList[i][name] + "  " + scoreList[i][score] + "\n" + "\n";
                    }
                    else if (i == 2)
                    {
                        text.text += i + 1 + "rd  " + scoreList[i][name] + "  " + scoreList[i][score] + "\n" + "\n";
                    }
                    else
                    {
                        if (i == 4)
                        {
                            text.text += i + 1 + "th  " + scoreList[i][name] + "  " + scoreList[i][score];
                        }
                        else
                        {
                            text.text += i + 1 + "th  " + scoreList[i][name] + "  " + scoreList[i][score] + "\n" + "\n";
                        }
                    }
                }
            }
        });
        query.FindAsync((List<NCMBObject> scoreList, NCMBException e) =>
        {
            if (e == null)
            {
                int myPosition = 0;
                for (int i = 0; i < scoreList.Count; i++)
                {
                    if (scoreList[i].ObjectId == id)
                    {
                        myPosition = i;
                        break;
                    }
                }
                if (myPosition < 3)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (i == 0)
                        {
                            myText.text += i + 1 + "st" + scoreList[i][name] + "  " + scoreList[i][score] + "\n" + "\n";
                        }
                        else if (i == 1)
                        {
                            myText.text += i + 1 + "nd" + scoreList[i][name] + "  " + scoreList[i][score] + "\n" + "\n";
                        }
                        else if (i == 2)
                        {
                            myText.text += i + 1 + "rd" + scoreList[i][name] + "  " + scoreList[i][score] + "\n" + "\n";
                        }
                        else
                        {
                            if (i == 4)
                            {
                                myText.text += i + 1 + "th" + scoreList[i][name] + "  " + scoreList[i][score];
                            }
                            else
                            {
                                myText.text += i + 1 + "th" + scoreList[i][name] + "  " + scoreList[i][score] + "\n" + "\n";
                            }
                        }
                        if (i == 4)
                        {
                            myText.text += scoreList[i][name] + "  " + scoreList[i][score];
                        }
                        else
                        {
                            myText.text += scoreList[i][name] + "  " + scoreList[i][score] + "\n" + "\n";
                        }
                    }
                }
                else
                {
                    for (int i = myPosition - 2; i < myPosition + 3; i++)
                    {
                        if (i == 1)
                        {
                            myText.text += i + 1 + "nd" + scoreList[i][name] + "  " + scoreList[i][score] + "\n" + "\n";
                        }
                        else if (i == 2)
                        {
                            myText.text += i + 1 + "rd" + scoreList[i][name] + "  " + scoreList[i][score] + "\n" + "\n";
                        }
                        else
                        {
                            if (i == myPosition + 2)
                            {
                                myText.text += i + 1 + "th" + scoreList[i][name] + "  " + scoreList[i][score];
                            }
                            else
                            {
                                myText.text += i + 1 + "th" + scoreList[i][name] + "  " + scoreList[i][score] + "\n" + "\n";
                            }
                        }
                        if (i == myPosition + 2)
                        {
                            myText.text += scoreList[i][name] + "  " + scoreList[i][score];
                        }
                        else
                        {
                            myText.text += scoreList[i][name] + "  " + scoreList[i][score] + "\n" + "\n";
                        }
                    }
                }
            }
        });
    }
}
