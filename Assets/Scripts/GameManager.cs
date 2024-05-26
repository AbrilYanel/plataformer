using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverUI;
    public Text gameOverText;


    public static bool gameOver = false;

    public static bool winCondition = false;

    public static int actualPlayer = 0;

    public List<Controller_Target> targets;

    public List<Controller_Player> players;

    void Start()
    {
        Physics.gravity = new Vector3(0, -30, 0);
        gameOver = false;
        winCondition = false;
        SetConstraits();

        gameOverUI.SetActive(false);
    }

    void Update()
    {
        GetInput();
        CheckWin();

    }

    private void CheckWin()
    {
        int i = 0;
        foreach(Controller_Target t in targets)
        {
            if (t.playerOnTarget)
            {
                i++;
                //Debug.Log(i.ToString());
            }
        }
        if (i >= 7)
        {
            winCondition = true;
            SceneManager.LoadScene(1);
        }
    }

   


    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangePlayer(actualPlayer - 1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangePlayer(actualPlayer + 1);
        }
    }

    private void ChangePlayer(int newPlayerIndex)
    {
        // Reset gravity if the current player is the gravity-inverting player
        if (players[actualPlayer] is Controller_Player_GravityInverted)
        {
            Physics.gravity = new Vector3(0, -30, 0);
        }

        if (newPlayerIndex < 0)
        {
            actualPlayer = players.Count - 1;
        }
        else if (newPlayerIndex >= players.Count)
        {
            actualPlayer = 0;
        }
        else
        {
            actualPlayer = newPlayerIndex;
        }

        SetConstraits();
    }

    private void SetConstraits()
    {
        foreach (Controller_Player p in players)
        {
            if (p == players[actualPlayer])
            {
                p.rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
            else
            {
                p.rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
        }
    }

    public void LoseGame(string reason)
    {
        gameOverUI.SetActive(true);
        gameOverText.text = reason;
        Time.timeScale = 0f;
    }
}
