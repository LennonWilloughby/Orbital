using UnityEngine;
using System.Collections;

public class MissionResult : MonoBehaviour {

	public string type;
	private GameObject player;
	private GameObject audioManager;
	private int numAstronauts;
	private int numThrusts;
	private int initialThrusts;
	private int minThrusts;
	private int numStars = 0;
	private int currentStars = 0;
	private string starsString;
	private bool hasRun = false;
	TextMesh tm;

	// Use this for initialization
	void Start () {

		transform.renderer.enabled = false;
		player = GameObject.FindGameObjectWithTag ("Player");
		audioManager = GameObject.FindGameObjectWithTag ("MainCamera");
		tm = GetComponent<TextMesh> ();
		initialThrusts = player.GetComponent<PlayerControl>().thrustCount;

		if(Application.loadedLevelName == "Mission01") {
			minThrusts = 2;
			starsString = "Mission01Stars";
		}
		else if(Application.loadedLevelName == "Mission02") {
			minThrusts = 3;
			starsString = "Mission02Stars";
		}
		else if(Application.loadedLevelName == "Mission03") {
			minThrusts = 2;
			starsString = "Mission03Stars";
		}
		else if(Application.loadedLevelName == "Mission04") {
			minThrusts = 3;
			starsString = "Mission04Stars";
		}
		currentStars = PlayerPrefs.GetInt(starsString);

	}
	
	// Update is called once per frame
	void Update () {

		numAstronauts = player.GetComponent<PlayerControl>().astronautCount;
		numThrusts = player.GetComponent<PlayerControl>().thrustCount;


		if(player.GetComponent<PlayerControl>().atHome == true || player.GetComponent<PlayerControl>().dead == true) {

			if(numAstronauts >= 1) {
				numStars = 1;
			}
			if(numAstronauts >= 3) {
				numStars = 2;
			}
			if(numAstronauts >= 3 && (initialThrusts-numThrusts) <= minThrusts) {
				numStars = 3;
			}

			if(type == "MissionResult" && hasRun == false) {
				if(player.GetComponent<PlayerControl>().atHome == true && numAstronauts > 0) {
					tm.text = "MISSION COMPLETE";
					audioManager.GetComponent<AudioManager>().victorySound = true;
				}
				else {
					tm.text = "MISSION FAILED";
				}
				transform.renderer.enabled = true;
				hasRun = true;
			}
			else if(type == "ScoreResult") {
				if(player.GetComponent<PlayerControl>().atHome == true && numAstronauts > 0) {
					tm.text = "Astronauts Collected: " + numAstronauts + " Thrusts Used: " + (initialThrusts-numThrusts);
				}
				else {
					if(player.GetComponent<PlayerControl>().deathType == "blackhole"){
						tm.text = "You have crashed into a blackhole!";
					}
					else if(player.GetComponent<PlayerControl>().deathType == "sun"){
						tm.text = "You have crashed into the sun!";
					}
					else if(player.GetComponent<PlayerControl>().deathType == "debris"){
						tm.text = "You have collided with space debris!";
					}
					else if(player.GetComponent<PlayerControl>().deathType == "time"){
						if(numThrusts == 0){
							tm.text = "You have run out of thrusts and crashed into a planet!";
						}
						else {
							tm.text = "You have crashed into a planet!";
						}
					}
					else if(player.GetComponent<PlayerControl>().atHome == true && numAstronauts == 0) {
						tm.text = "You have not saved any astronauts!";
					}
					else if(player.GetComponent<PlayerControl>().deathType == "drift"){
						tm.text = "You have drifted into empty space!";
					}
				}
				transform.renderer.enabled = true;
			}
			else if(type == "HighscoreResult" && player.GetComponent<PlayerControl>().atHome == true && numAstronauts > 0) {
				if(currentStars < numStars) {
					transform.renderer.enabled = true;
				}
			}
			else if(type == "Star01" && player.GetComponent<PlayerControl>().atHome == true && numAstronauts > 0) {
				if(numStars >= 1) {
					transform.renderer.enabled = true;
				}
			}
			else if(type == "Star02" && player.GetComponent<PlayerControl>().atHome == true && numAstronauts > 0) {
				if(numStars >= 2) {
					transform.renderer.enabled = true;
				}
			}
			else if(type == "Star03" && player.GetComponent<PlayerControl>().atHome == true && numAstronauts > 0) {
				if(numStars >= 3) {
					transform.renderer.enabled = true;
				}
			}
			else if(type == "background") {
				transform.renderer.enabled = true;
			}
			else if(type == "ContinueText") {
				transform.renderer.enabled = true;
			}
		}

		if (Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}
		
		if (Input.GetKeyDown(KeyCode.T)) {
			Application.LoadLevel("MissionSelect");
		}
	}
}
