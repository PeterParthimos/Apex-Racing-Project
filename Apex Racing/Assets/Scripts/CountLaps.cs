using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CountLaps : MonoBehaviour
{
    private int p1Laps;
    private int p2Laps;

    public Canvas hud;
    public TMP_Text p1Score;
    public TMP_Text p2Score;

    public Canvas endScreen;
    public TMP_Text winner;

    // Start is called before the first frame update
    void Start()
    {
        p1Laps = 0;
        p2Laps = 0;

        //Hides endscreen and shows the score HUD
        endScreen.enabled = false;
        hud.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Checks collision and determines if its with player 1 or 2
    //Increases lap count accordingly
    //If laps are greater than 5, it ends the game
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Player1") {
            p1Laps++;
            if (p1Laps > 5)
                EndGame(1);
            else
                SetScore(1);
        } else if (collision.collider.tag == "Player2") {
            p2Laps++;
            if (p2Laps > 5)
                EndGame(2);
            else
                SetScore(2);
        }
    }

    //Sets the text in the HUD when a player starts a new lap
    void SetScore(int player) {
        if (player == 1) {
            p1Score.SetText("Lap " + p1Laps + "/5");
        } else if (player == 2) {
            p2Score.SetText("Lap " + p2Laps + "/5");
        }
    }

    //Shows the end game screen
    private void EndGame(int player) {
        winner.SetText("Player " + player + " Wins!");
        hud.enabled = false;
        endScreen.enabled = true;
    }
}
