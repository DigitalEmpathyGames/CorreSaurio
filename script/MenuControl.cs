using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;


public class MenuControl : MonoBehaviour {
	
	[SerializeField]
	Text highScoreText;

	private bool logeado;
	private int puntajeMaximo;
	private string leaderboard = "CgkI9Zz3j5QdEAIQAg";

	void Start () {
		puntajeMaximo = PlayerPrefs.GetInt ("highScore");
		highScoreText.text = "High Score: " + puntajeMaximo;
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
		PlayGamesPlatform.InitializeInstance(config);
		PlayGamesPlatform.Activate();
		if (!Social.localUser.authenticated) {
			LogIn ();
		}

	}

	public void EmpezarJuego(){
		SceneManager.LoadScene ("Scene01");
	}

	public void DesplegarRanking(){
		if (Social.localUser.authenticated) {
			Social.ReportScore (puntajeMaximo, leaderboard, (bool success) => {
				((PlayGamesPlatform)Social.Active).ShowLeaderboardUI (leaderboard);
			});
		}

	}

	public void LogIn(){
		Social.localUser.Authenticate ((bool success) =>{});
	}

}
