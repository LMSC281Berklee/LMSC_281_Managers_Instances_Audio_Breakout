//from https://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/creating-a-breakout-game

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GM instance = null;

	private GameObject clonePaddle;


	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		}
		else if (instance != this) {
			Destroy (gameObject);
		}
		Setup();
	}

	public void Setup () {
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate(bricksPrefab, transform.position, Quaternion.identity);
	}

	void CheckGameOver() {
		if (bricks <1) {
			youWon.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay*30);
		}

		if (lives <1) {
			if (!youWon.activeSelf) {	//jmc - only show Game Over if playher did not win the game
				gameOver.SetActive(true);
				Time.timeScale = .25f;
				Invoke ("Reset", resetDelay);
			}
		}
	}

	void Reset () {
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Main");
	}
	
	public void LoseLife() {
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Invoke ("SetupPaddle",resetDelay);
		CheckGameOver();
	}

	void SetupPaddle () {
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}

	public void DestroyBrick() {
		bricks--;
		CheckGameOver();
	}
}
