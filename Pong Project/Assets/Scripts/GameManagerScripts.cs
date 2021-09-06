using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScripts : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Player 1")]
    public GameObject player1Paddle;
    public GameObject player1Goal;

    [Header("Player 2")]
    public GameObject player2Paddle;
    public GameObject player2Goal;

    [Header("Score UI")]
    public TextMeshProUGUI Player1Text;
    public TextMeshProUGUI Player2Text;

    public TextMeshProUGUI WinnerText;

    [Header("Debug")]
    public Trajectory trajectory;
    public GameObject ballAtCollision;


    public int maxScore; 

    private int player1score = 0;
    private int player2score = 0;
    public void player1Menang()
    {
        player1score++;
        Debug.Log(player1score);
        Player1Text.text = player1score.ToString();

        if(player1score >= maxScore)
        {
            WinnerText.text = "PLAYER 1 WIN !";
            Invoke("resetGame", 3);
        }
        else
        {
            Invoke("resetPosition", 1);
        }
    }

    public void player2Menang()
    {
        player2score++;
        
        Debug.Log(player2score);
        Player2Text.text = player2score.ToString();
        if (player2score >= maxScore)
        {
            WinnerText.text = "PLAYER 2 WIN !";
            Invoke("resetGame", 3);
        }
        else
        {
            Invoke("resetPosition", 1);
        }
    }

    private void resetPosition()
    {
        ball.GetComponent<Balls>().Reset();
        player1Paddle.GetComponent<PlayerControll>().Reset();
        player2Paddle.GetComponent<PlayerControll>().Reset();

    }

    public void resetGame()
    {

        WinnerText.text = "";

        player2score = 0;
        player1score = 0;

        Player2Text.text = player2score.ToString();
        Player1Text.text = player1score.ToString();
        resetPosition();
    }

    public void toogleTrajectory()
    {
        trajectory.enabled = !trajectory.enabled;
        if(ballAtCollision.activeSelf == true)
        {
            ballAtCollision.SetActive(false);
        }
    }
}
