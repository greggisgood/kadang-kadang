using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class uiManager : MonoBehaviour {

    public Button[] buttons;
    public Text scoreText;
    //public Text countdownText;
	public GameObject gameOverScreen;
	public GameObject instructions, pauseScreen;
	public Text highscore, yourscore, hslabel;
	public Animation anim;
    //public int timeLeft = 0;
    bool gameOver;
    int score;
	int hs;

    // Use this for initialization
    void Start() {
        gameOver = false;
        score = 0;
        InvokeRepeating("scoreUpdate", .01f, 0.1f);
		if (SceneManager.GetActiveScene ().name == "Level 1") {
			Pause();
			instructions.SetActive (true);
		}
    }

    // Update is called once per frame
    void Update() {
		scoreText.text = score.ToString();
        //countdownText.text = "" + timeLeft;
        if (/*timeLeft <= 0 ||*/ gameOver)
        {
            gameOverActivated(false);
        }
    }

    void scoreUpdate()
    {
        if (!gameOver) {
            score += 1;
        }
    }

    public void stopScoreUpdate()
    {
        CancelInvoke("scoreUpdate");
    }

    public void gameOverActivated(bool hasCollided)
    {
        gameOver = true;
		Pause();
		gameOverScreen.SetActive (true);
		hs = PlayerPrefs.GetInt ("highscore");
		if(hs != 0 || hs != null){
			if (score > hs) {
				highscore.text = score.ToString();
				PlayerPrefs.SetInt ("highscore", score);
				hslabel.text = "NEW HIGH SCORE!";
			} else {
				highscore.text = hs.ToString();
			}
		}
		yourscore.text = score.ToString ();
    }

    public void Play() {
        SceneManager.LoadScene("Level 1");
       
    }

    public void Pause() {
       Time.timeScale = 0;
    }

	public void Unpause(){
		Time.timeScale = 1;
	}

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }

	public void okInstructions(){
		Unpause();
		instructions.SetActive (false);
	}

	public void inGamePause(){
		Pause ();
		pauseScreen.SetActive(true);
	}

	public void inGameUnpause(){
		Unpause ();
		pauseScreen.SetActive(false);
	}
}

