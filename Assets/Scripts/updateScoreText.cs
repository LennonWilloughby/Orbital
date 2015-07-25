using UnityEngine;
using System.Collections;

public class updateScoreText : MonoBehaviour {
	
	public string levelName;
	private int astronautNum;
	private int thrustNum;
	TextMesh tm;

	// Use this for initialization
	void Start () {
	
		tm = GetComponent<TextMesh> ();

		if(levelName == "Mission01") {
			astronautNum = PlayerPrefs.GetInt("Mission01Astronauts");
			thrustNum = PlayerPrefs.GetInt("Mission01Thrusts");
		}
		if(levelName == "Mission02") {
			astronautNum = PlayerPrefs.GetInt("Mission02Astronauts");
			thrustNum = PlayerPrefs.GetInt("Mission02Thrusts");
		}
		if(levelName == "Mission03") {
			astronautNum = PlayerPrefs.GetInt("Mission03Astronauts");
			thrustNum = PlayerPrefs.GetInt("Mission03Thrusts");
		}
		if(levelName == "Mission04") {
			astronautNum = PlayerPrefs.GetInt("Mission04Astronauts");
			thrustNum = PlayerPrefs.GetInt("Mission04Thrusts");
		}

		tm.text = "BEST Astronauts: " + astronautNum + " Thrusts: " + thrustNum;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
