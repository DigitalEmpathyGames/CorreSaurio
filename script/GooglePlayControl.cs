using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlayControl : MonoBehaviour {

	private string leaderboard = "CgkI9Zz3j5QdEAIQAA";
	void Start () {
		Debug.Log (" gPlay Start metodo...");
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();
	}


	public bool LogIn(){
		bool logeado = false;
		Social.localUser.Authenticate ((bool success) =>
			{
				if (success) {
					logeado = true;
				}
			});

		return logeado;
	}

	public void ActualizarPuntaje(int puntaje){
		if (Social.localUser.authenticated) {
			Social.ReportScore (puntaje, leaderboard, (bool success) =>
				{
					if (success) {
						Debug.Log ("Update Score Success");

					} else {
						Debug.Log ("Update Score Fail");
					}
				});
		}
	}

	public void MostrarRanking(){
		((PlayGamesPlatform)Social.Active).ShowLeaderboardUI (leaderboard);
	}
		
}
