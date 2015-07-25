using UnityEngine;
using System.Collections;

public class Wormhole : MonoBehaviour {
	
	private GameObject player;
	private GameObject audioManager;
	private Vector3 playerPos;
	public Vector3 endPos;
	private float distance;
	private bool useWormhole = false;
	
	// Use this for initialization
	void Start () {
		distance = 2;
		player = GameObject.FindGameObjectWithTag ("Player");
		audioManager = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		playerPos = player.transform.position;
		if (Vector3.Distance (transform.position, playerPos) >= distance/2 && Vector3.Distance (transform.position, playerPos) < distance) {
			useWormhole = true;
		}
		if (Vector3.Distance (transform.position, playerPos) < distance/2 && useWormhole == true) {
			player.transform.position = endPos;
			player.GetComponent<PlayerControl>().thrustPos = endPos;
			audioManager.GetComponent<AudioManager>().wormholeSound = true;
			useWormhole = false;
		}
	}
}