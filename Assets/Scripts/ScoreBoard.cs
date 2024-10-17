using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private TextMeshProUGUI[] scoreBoard;
    [SerializeField] private List<float> scores = new List<float>();


    private string scorestring;
    private string currentPlayer;

    public static ScoreBoard instance;

    [SerializeField] private TextMeshProUGUI lastScoreText;
    [SerializeField] private TextMeshProUGUI lastRunRank;


    private float lastScoreNr;
    private float lastRunRankNr;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    public void SetScore(float score)
    {
        scores.Add(score);
        lastScoreNr = score;
        lastScoreText.text = score.ToString();
        scores = scores.OrderByDescending(x => x).ToList();
        lastRunRankNr = 1 + scores.IndexOf(score);
        lastRunRank.text = "#" + lastRunRankNr;
        if (scores.Count < 11)
        {
            for (int i = 0; i < scores.Count; i++)
            {
                scorestring = scores[i].ToString();
                scoreBoard[i].text = scorestring;
            }
        }
    }
}
