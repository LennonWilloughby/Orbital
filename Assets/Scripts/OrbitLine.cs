using UnityEngine;
using System.Collections;

public class OrbitLine : MonoBehaviour {
	
	private GameObject player;

	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag ("Player");
		gameObject.renderer.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			if (player.GetComponent<PlayerControl>().orbiting == true && player.GetComponent<PlayerControl>().thrustCount > 0 && player.GetComponent<PlayerControl>().atHome == false) {
				gameObject.renderer.enabled = true;
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			gameObject.renderer.enabled = false;
		}
	}
}
