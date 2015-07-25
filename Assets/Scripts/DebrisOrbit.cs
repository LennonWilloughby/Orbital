using UnityEngine;
using System.Collections;

public class DebrisOrbit : MonoBehaviour {
	
	private GameObject player;
	private GameObject audioManager;
	private Vector3 playerPos;
	private float distance;
	private bool hasRun = false;
	
	// Use this for initialization
	void Start () {
		distance = 0.4f;
		player = GameObject.FindGameObjectWithTag ("Player");
		audioManager = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		playerPos = player.transform.position;
		if (Vector3.Distance (transform.position, playerPos) <= distance && hasRun == false) {
			player.GetComponent<PlayerControl>().deathType = "debris";
			player.SetActive (false);
			player.GetComponent<PlayerControl>().dead = true;
			audioManager.GetComponent<AudioManager>().explosionSound = true;
			hasRun = true;

		}
		transform.RotateAround (transform.parent.position, Vector3.forward, 0.5f);
	}
}