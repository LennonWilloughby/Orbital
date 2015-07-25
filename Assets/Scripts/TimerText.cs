using UnityEngine;
using System.Collections;

public class TimerText : MonoBehaviour {

	public float initialTime;
	private float orbitTime;
	private float distance;
	private Vector3 playerPos;
	private GameObject player;
	TextMesh tm;

	// Use this for initialization
	void Start () {

		tm = GetComponent<TextMesh> ();
		distance = 2;
		player = GameObject.FindGameObjectWithTag ("Player");
		orbitTime = initialTime;

	}
	
	// Update is called once per frame
	void Update () {

		playerPos = player.transform.position;
		if (Vector3.Distance (transform.position, playerPos) <= distance && player.GetComponent<PlayerControl>().orbiting == true) {
			orbitTime = player.GetComponent<PlayerControl>().time;
		}
		else {
			orbitTime = initialTime;
		}
			tm.text = orbitTime.ToString ("F2");
	}
}