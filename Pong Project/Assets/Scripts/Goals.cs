using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goals : MonoBehaviour
{
    public bool isPlayer1Goal;
    private GameObject gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPlayer1Goal)
        {
            Debug.Log("Player 1 Menang");
            gameManager.GetComponent<GameManagerScripts>().player1Menang();
        }
        else
        {
            Debug.Log("Player 2 Menang");
            gameManager.GetComponent<GameManagerScripts>().player2Menang();
        }
    }
}
