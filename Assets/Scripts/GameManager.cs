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

    public GameObject winUI;
    public Text winText;

    public static bool gameOver = false;
    public static bool winCondition = false;
    public static int actualPlayer = 0;

    public List<Controller_Target> targets;
    public List<Controller_Player> players;

    public int targetsToWinInFirstScene = 7; // Number of targets to win in the first scene
    public int targetsToWinInSecondScene = 7; // Number of targets to win in the second scene

    void Start()
    {
        Physics.gravity = new Vector3(0, -30, 0);
        gameOver = false;
        winCondition = false;
        SetConstraits();

        gameOverUI.SetActive(false);
        if (winUI != null) winUI.SetActive(false);
    }

    void Update()
    {
        GetInput();
        CheckWin();
    }

    private void CheckWin()
    {
        int i = 0;
        foreach (Controller_Target t in targets)
        {
            if (t.playerOnTarget)
            {
                i++;
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 0 && i >= targetsToWinInFirstScene)
        {
            winCondition = true;
            SceneManager.LoadScene(1);

        }
        else if (SceneManager.GetActiveScene().buildIndex == 1 && i >= targetsToWinInSecondScene)
        {
            winCondition = true;
            ShowWinMessage("Ganastee!");
        }
    }

    private void ShowWinMessage(string message)
    {
        if (winUI != null)
        {
            winUI.SetActive(true);
            winText.text = message;
        }
        Time.timeScale = 0f;
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
        gameOverText.text = "Has Perdido";
        Time.timeScale = 0f;
    }
}
