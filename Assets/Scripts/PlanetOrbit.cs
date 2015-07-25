using UnityEngine;
using System.Collections;

public class PlanetOrbit : MonoBehaviour {

	private GameObject player;
	private Vector3 playerPos;
	private float distance;
	public float orbitTime;
	
	// Use this for initialization
	void Start () {
		distance = transform.localScale.x/2 + 0.25f;
		player = GameObject.FindGameObjectWithTag ("Player");

 	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (0, -0.1f, 0);
		playerPos = player.transform.position;
		if (Vector3.Distance (transform.position, playerPos) <= distance && player.GetComponent<PlayerControl> ().orbiting == false && player.GetComponent<PlayerControl> ().canOrbit == true) {
				player.GetComponent<PlayerControl> ().enterPos = player.transform.position;
				player.GetComponent<PlayerControl> ().setOrbit = true;	
				player.GetComponent<PlayerControl> ().orbitPos = transform.position;
				player.GetComponent<PlayerControl> ().orbiting = true;
				player.GetComponent<PlayerControl> ().time = orbitTime;
		}
	}
}
