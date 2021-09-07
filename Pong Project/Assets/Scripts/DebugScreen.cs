using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;

public class DebugScreen : MonoBehaviour
{
    public PlayerControll player1;
    public PlayerControll player2;
    public Rigidbody2D ballRigidbody;
    public Collider2D ballCollider;
    public TextMeshProUGUI debugBottomScreen;

    private bool visibleDebug;
 

    // Update is called once per frame
    void Update()
    {

        // Simpan variabel-variabel fisika yang akan ditampilkan. 
        float ballMass = ballRigidbody.mass;
        Vector2 ballVelocity = ballRigidbody.velocity;
        float ballSpeed = ballRigidbody.velocity.magnitude;
        Vector2 ballMomentum = ballMass * ballVelocity;
        float ballFriction = ballCollider.friction;

        float impulsePlayer1X = player1.LastContactPoint.normalImpulse;
        float impulsePlayer1Y = player1.LastContactPoint.tangentImpulse;
        float impulsePlayer2X = player2.LastContactPoint.normalImpulse;
        float impulsePlayer2Y = player2.LastContactPoint.tangentImpulse;

        // Tentukan debug text-nya
        string debugText =
            "Ball mass = " + ballMass + "\n" +
            "Ball velocity = " + ballVelocity + "\n" +
            "Ball speed = " + ballSpeed + "\n" +
            "Ball momentum = " + ballMomentum + "\n" +
            "Ball friction = " + ballFriction + "\n" +
            "Last impulse from player 1 = (" + impulsePlayer1X + ", " + impulsePlayer1Y + ")\n" +
            "Last impulse from player 2 = (" + impulsePlayer2X + ", " + impulsePlayer2Y + ")\n";
        if (visibleDebug)
        {
            debugBottomScreen.text = debugText;
        } else
        {
            debugBottomScreen.text = "";
        }

    }

    public void toogleDebugScreen()
    {
        visibleDebug = !visibleDebug;

    }
}
