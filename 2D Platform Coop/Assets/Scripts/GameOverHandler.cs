using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    [SerializeField] float numOfPlayers;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TextMeshProUGUI winnerTxt;
    bool winnerDeclared;

    [Header("SFX")]
    [SerializeField] AudioClip yeheySfx;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        FindPlayers();
        numOfPlayers = players.Length;
    }
    // Update is called once per frame
    void Update()
    {
        CheckIfPlayerHasDied();
    }

    private void CheckIfPlayerHasDied()
    {
        FindPlayers();

        if (players.Length < numOfPlayers)
        {
            DeclareWinner();
            gameOverUI.SetActive(true);
            //Time.timeScale = 0f;
        }
    }
    private void DeclareWinner()
    {
        FindPlayers();
        if(!winnerDeclared)
        {
            PlayWinSound(0.7f);
            winnerDeclared = true;
            try
            {
                winnerTxt.SetText($"{players[0].name} Wins!");
            }
            catch (IndexOutOfRangeException e)
            {
                winnerTxt.SetText($"ITS A DRAW!");
            }
        }
       
    }

    void FindPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void PlayWinSound(float volume)
    {
        audioSource.PlayOneShot(yeheySfx, volume);
    }

    public void ResetGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }
}
