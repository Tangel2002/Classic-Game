using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    public GameObject Scoreboard;
    public GameObject Player1Score;
    public GameObject Player2Score;
    int P1Score = 0;
    int P2Score = 0;

    public void Player1Scored()
    {
        P1Score = P1Score + 1;
        Debug.Log(P1Score);
        if (P1Score > 9)
        {
            SceneManager.LoadScene("Player1Wins");
        }
        //Player1Score.GetComponent<TextEditor>().text = P1Score.ToString();
    }
    public void Player2Scored()
    {
        P2Score = P2Score + 1;
        Debug.Log(P2Score);
        if (P2Score > 9)
        {
            SceneManager.LoadScene("GameOver");
        }
        //Player2Score.GetComponent<TextEditor>().text = P2Score.ToString();
    }
}
