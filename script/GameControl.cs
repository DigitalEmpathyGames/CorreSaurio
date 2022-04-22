using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControl : MonoBehaviour {

	public static GameControl instance = null;

	[SerializeField]
	GameObject restartButton;

	[SerializeField]
	GameObject inicioButton;

	[SerializeField]
	Text highScoreText;

	[SerializeField]
	Text yourScoreText;

	[SerializeField]
	GameObject[] obstacles;

	[SerializeField]
	Transform spawnPoint;

	[SerializeField]
	float spawnRate = 2f;
	float nextSpawn = 2f;

	[SerializeField]
	float timeToBoost = 5f;
	float nextBoost;

	int highScore = 0;
	int yourScore = 0;

	public static bool gameStopped;

	float nextScoreIncrease = 0f;

	void Start () {
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy (gameObject);
		}

		restartButton.SetActive (false);
		inicioButton.SetActive (false);
		yourScore = 0;
		gameStopped = false;
		Time.timeScale = 1f;
		highScore = PlayerPrefs.GetInt ("highScore");
		nextSpawn = Time.time + spawnRate;
		nextBoost = Time.unscaledTime + timeToBoost;
	}

	void Update () {
		if(!gameStopped){
			IncreaseYourScore ();
		}

		highScoreText.text = "High Score: " + highScore;
		yourScoreText.text = "Your Score: " + yourScore;

		if(Time.time > nextSpawn){
			SpawnObstacle ();
		}

		if(Time.unscaledTime > nextBoost && !gameStopped){
			BoostTime ();
		}

	}

	void IncreaseYourScore(){
		if(Time.unscaledTime > nextScoreIncrease){
			yourScore = yourScore + 1;
			nextScoreIncrease = Time.unscaledTime + 1;
		}
	}

	void SpawnObstacle(){
		nextSpawn = Time.time + spawnRate;
		int randomObstacle = Random.Range (0, obstacles.Length);
		if (randomObstacle == 0) {
			SoundManager.PlaySound ("bee");
		} else {
			SoundManager.PlaySound ("pop");
		}

		Instantiate (obstacles[randomObstacle], spawnPoint.position, Quaternion.identity);
	}

	void BoostTime(){
		nextBoost = Time.unscaledTime + timeToBoost;
		Time.timeScale += 0.25f;
	}

	public void  RestartGame(){
		SceneManager.LoadScene ("Scene01");
	}

	public void MenuInicio(){
		SceneManager.LoadScene ("EscenaMenu");
	}

	public void DinoHit(){
		SoundManager.audioSrc.Stop ();
		SoundManager.PlaySound ("endGame");

		if(yourScore > highScore){
			PlayerPrefs.SetInt ("highScore",yourScore);
		}
		Time.timeScale = 0;
		gameStopped = true;
		restartButton.SetActive (true);
		inicioButton.SetActive (true);
	}

}
