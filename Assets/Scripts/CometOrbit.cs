using UnityEngine;
using System.Collections;

public class CometOrbit : MonoBehaviour {

	private GameObject player;
	private Vector3 playerPos;
	private float distance;
	private int move = 1;
	public float orbitTime;
	public float startPoint;
	public float endPoint;

	
	// Use this for initialization
	void Start () {
		distance = 1;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		playerPos = player.transform.position;

		if (transform.position.x >= endPoint) {
			player.GetComponent<PlayerControl>().cometDirection = -1;
			move = -1;
		} 
		else if (transform.position.x <= startPoint) {
			player.GetComponent<PlayerControl>().cometDirection = 1;
			move = 1;	
		}
		transform.Translate (0.03f * move, 0, 0);

		player.GetComponent<PlayerControl>().cometPos = transform.position;

		if (Vector3.Distance (transform.position, playerPos) <= distance && player.GetComponent<PlayerControl>().orbiting == false && player.GetComponent<PlayerControl> ().canOrbit == true) {
			player.GetComponent<PlayerControl>().enterPos = player.transform.position;
			player.GetComponent<PlayerControl>().orbitPos = transform.position;
			player.GetComponent<PlayerControl>().setOrbit = true;	
			player.GetComponent<PlayerControl>().orbiting = true;	
			player.GetComponent<PlayerControl>().orbitingComet = true;	
			player.GetComponent<PlayerControl>().time = orbitTime;
		}
	}
}