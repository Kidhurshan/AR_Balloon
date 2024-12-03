using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameLoop : MonoBehaviour
{
    //set up the variables needed
    private int playerHealth = 5;
    private int score = 0;
    private Boolean isGameOver = false;

    //set up the ui 
    public TextMeshProUGUI scoreText;
    public GameObject gameStartUI;
    public GameObject gameOverUI;
    public TextMeshProUGUI finalScore;
    public Image healthBar;


    void Start()
    {
        startGame();
    }

    private void startGame()
    {
        playerHealth = 5;
        score = 0;
        isGameOver = false;
        scoreText.text = "Score: " + score;
        gameStartUI.SetActive(true);
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            checkGameOver();
            scoreText.text = "Score: " + score;
        }
    }

    private void checkGameOver()
    {
        if (playerHealth <= 0)
        {
            isGameOver = true;
            showGameOverScreen();
        }
    }

    public void incrementScore()
    {
        score++;
    }
    public void decrementHealth()
    {
        if (playerHealth > 0)
        {
            playerHealth--;
            healthBar.fillAmount = playerHealth/ 5f;
        }
    }

    private void showGameOverScreen()
    {
        gameStartUI.SetActive(false);
        gameOverUI.SetActive (true);
        finalScore.text = "Score: "+ score; 
        Time.timeScale = 0f;
    }

    public void restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
