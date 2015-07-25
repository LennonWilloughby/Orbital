using UnityEngine;
using System.Collections;

public class AstronautPickup : MonoBehaviour {

	private GameObject player;
	private GameObject audioManager;
	private Vector3 playerPos;
	private float distance;
	
	// Use this for initialization
	void Start () {
		
		distance = 0.5f;
		player = GameObject.FindGameObjectWithTag ("Player");
		audioManager = GameObject.FindGameObjectWithTag ("MainCamera");
		
		//PlayerControl playerControl = player.GetComponent<PlayerControl> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		playerPos = player.transform.position;
		if (Vector3.Distance (transform.position, playerPos) <= distance) {
			audioManager.GetComponent<AudioManager>().astronautSound = true;
			player.GetComponent<PlayerControl>().astronautCount += 1;
			Destroy (gameObject);
		}
	}
}
