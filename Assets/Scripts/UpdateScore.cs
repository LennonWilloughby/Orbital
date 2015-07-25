using UnityEngine;
using System.Collections;

public class UpdateScore : MonoBehaviour {

	private GameObject player;
	private int thrustCount;
	private int thrustUsed;
	private int astronautCount;
	private bool updateScore = true;
	private string starsString;
	private string astronautString;
	private string thrustString;
	private int bestThrust;
	private int numThrust;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		if(PlayerPrefs.HasKey("Mission01Stars") == false) {
			PlayerPrefs.SetInt("Mission01Stars", 0);
			PlayerPrefs.SetInt("Mission01Astronauts", 0);
			PlayerPrefs.SetInt("Mission01Thrusts", 0);
			PlayerPrefs.Save ();
		}
		if(PlayerPrefs.HasKey("Mission02Stars") == false) {
			PlayerPrefs.SetInt("Mission02Stars", 0);
			PlayerPrefs.SetInt("Mission02Astronauts", 0);
			PlayerPrefs.SetInt("Mission02Thrusts", 0);
			PlayerPrefs.Save ();
		}
		if(PlayerPrefs.HasKey("Mission03Stars") == false) {
			PlayerPrefs.SetInt("Mission03Stars", 0);
			PlayerPrefs.SetInt("Mission03Astronauts", 0);
			PlayerPrefs.SetInt("Mission03Thrusts", 0);
			PlayerPrefs.Save ();
		}
		if(PlayerPrefs.HasKey("Mission04Stars") == false) {
			PlayerPrefs.SetInt("Mission04Stars", 0);
			PlayerPrefs.SetInt("Mission04Astronauts", 0);
			PlayerPrefs.SetInt("Mission04Thrusts", 0);
			PlayerPrefs.Save ();
		}

	}
	
	// Update is called once per frame
	void Update () {

		if(player.GetComponent<PlayerControl>().atHome == true && updateScore == true) {

			updateScore = false;

			thrustCount = player.GetComponent<PlayerControl>().thrustCount;
			astronautCount = player.GetComponent<PlayerControl>().astronautCount;

			if (Application.loadedLevelName == "Mission01") {
				numThrust = 5;
				bestThrust = 2;
				starsString = "Mission01Stars";
				astronautString = "Mission01Astronauts";
				thrustString = "Mission01Thrusts";
			}
			else if (Application.loadedLevelName == "Mission02") {
				numThrust = 6;
				bestThrust = 3;
				starsString = "Mission02Stars";
				astronautString = "Mission02Astronauts";
				thrustString = "Mission02Thrusts";
			}
			else if (Application.loadedLevelName == "Mission03") {
				numThrust = 7;
				bestThrust = 2;
				starsString = "Mission03Stars";
				astronautString = "Mission03Astronauts";
				thrustString = "Mission03Thrusts";
			}
			else if (Application.loadedLevelName == "Mission04") {
				numThrust = 8;
				bestThrust = 3;
				starsString = "Mission04Stars";
				astronautString = "Mission04Astronauts";
				thrustString = "Mission04Thrusts";
			}

			thrustUsed = numThrust - thrustCount;

			if(astronautCount > PlayerPrefs.GetInt(astronautString)) {
				PlayerPrefs.SetInt(astronautString, astronautCount);
				PlayerPrefs.SetInt(thrustString, thrustUsed);
			}

			if(thrustUsed < PlayerPrefs.GetInt(thrustString) && PlayerPrefs.GetInt(astronautString) == astronautCount) {
				PlayerPrefs.SetInt(thrustString, thrustUsed);
			}
			
			if(astronautCount == 1 && PlayerPrefs.GetInt(starsString) < 1) {
				PlayerPrefs.SetInt(starsString, 1);
			}
			else if(astronautCount == 3 && thrustUsed > bestThrust && PlayerPrefs.GetInt(starsString) < 2) {
				PlayerPrefs.SetInt(starsString, 2);
			}
			else if(astronautCount == 3 && thrustUsed <= bestThrust && PlayerPrefs.GetInt(starsString) < 3) {
				PlayerPrefs.SetInt(starsString, 3);
			}
			PlayerPrefs.Save ();



		}

	}
}
