using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public GameObject Scoreboard;
    public TextMeshProUGUI Player1Score;
    public TextMeshProUGUI Player2Score;
    int P1Score = 0;
    int P2Score = 0;

    public void Player1Scored()
    {
        P1Score = P1Score + 1;
        Player1Score.text = P1Score.ToString();

        if (P1Score > 9)
        {
            SceneManager.LoadScene("Player1Wins");
        }
        //Player1Score.GetComponent<TextEditor>().text = P1Score.ToString();
    }
    public void Player2Scored()
    {
        P2Score = P2Score + 1;
        Player2Score.text = P2Score.ToString();
        if (P2Score > 9)
        {
            SceneManager.LoadScene("GameOver");
        }
        //Player2Score.GetComponent<TextEditor>().text = P2Score.ToString();
    }
}
