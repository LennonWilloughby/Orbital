using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour {

	private GameObject player;
	TextMesh tm;

	// Use this for initialization
	void Start () {
	
		tm = GetComponent<TextMesh> ();
		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {

		tm.text = "Astronauts Collected: " + player.GetComponent<PlayerControl>().astronautCount + "  Thrusts Remaining: " + player.GetComponent<PlayerControl>().thrustCount;
	
	}
}
