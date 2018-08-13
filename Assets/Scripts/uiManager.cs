using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class uiManager : MonoBehaviour {

    public Button[] buttons;
    public Text scoreText;
    public Text countdownText;
    public int timeLeft = 0;
    bool gameOver;
    int score;

    // Use this for initialization
    void Start() {
        gameOver = false;
        score = 0;
        InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
        StartCoroutine("TimeUpdate");
    }

    // Update is called once per frame
    void Update() {
        scoreText.text = "Score: " + score;
        countdownText.text = "" + timeLeft;
        if (timeLeft <= 0 || gameOver)
        {
            gameOverActivated(false);
        }
    }

    void scoreUpdate()
    {
        if (!gameOver) {
            score += 10;
        }
    }

    IEnumerator TimeUpdate()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }

    public void gameOverActivated(bool hasCollided)
    {
        gameOver = true;
        foreach(Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
        StopCoroutine("TimeUpdate");
        if (hasCollided)
        {
            countdownText.text = "Game Over!";
        }
        else
        {
            countdownText.text = "Time's Up!";
        }
    }

    public void Play() {
        SceneManager.LoadScene("Level 1");
       
    }

    public void Pause() {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0) {
            Time.timeScale = 1;
        }
    }

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}

