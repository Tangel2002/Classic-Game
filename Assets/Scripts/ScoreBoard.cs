using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public GameObject Player1Score;
    public GameObject Player2Score;
    int P1Score = 0;
    int P2Score = 0;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "P2Goal")
        {
            Player1Scored();
        }
        else if (other.tag == "P1Goal")
        {
            Player2Scored();
        }
        else
        {

        }
    }
    public void Player1Scored()
    {
        //P1Score++;
        //Player1Score.GetComponent<TextEditor>().text = P1Score.ToString();
    }
    public void Player2Scored()
    {
        //P2Score++;
        //Player2Score.GetComponent<TextEditor>().text = P2Score.ToString();
    }
}
