using UnityEngine;
using System.Collections;

public class BlackHole : MonoBehaviour {

	private GameObject player;
	private GameObject audioManager;
	private Vector3 playerPos;
	private float distance;
	private bool hasRun = false;
	
	// Use this for initialization
	void Start () {
		distance = 2;
		player = GameObject.FindGameObjectWithTag ("Player");
		audioManager = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0,0.05f,0);
		playerPos = player.transform.position;
		if (Vector3.Distance (transform.position, playerPos) <= distance && Application.loadedLevelName == "Mission04" && hasRun == false) {
			player.GetComponent<PlayerControl>().deathType = "sun";
			player.SetActive (false);
			player.GetComponent<PlayerControl>().dead = true;
			audioManager.GetComponent<AudioManager>().driftSound = true;
			hasRun = true;
		}
		else if (Vector3.Distance (transform.position, playerPos) <= distance && hasRun == false) {
			player.GetComponent<PlayerControl>().deathType = "blackhole";
			player.SetActive (false);
			player.GetComponent<PlayerControl>().dead = true;
			audioManager.GetComponent<AudioManager>().driftSound = true;
			hasRun = true;
		}
	}
}