using UnityEngine;
using System.Collections;

public class LevelArea : MonoBehaviour {

	private GameObject player;
	private GameObject audioManager;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		audioManager = GameObject.FindGameObjectWithTag ("MainCamera");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit() {

		if(Application.loadedLevelName == "OrbitalMenu" || Application.loadedLevelName == "MissionSelect") {
			Application.LoadLevel(Application.loadedLevel);
		}
		else {
			player.GetComponent<PlayerControl>().deathType = "drift";
			player.SetActive (false);
			player.GetComponent<PlayerControl>().dead = true;
			audioManager.GetComponent<AudioManager>().driftSound = true;
		}
	}
}
