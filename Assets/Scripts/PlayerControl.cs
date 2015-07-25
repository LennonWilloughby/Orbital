using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float distance = 1.5f;
	public float moveSpeed = 5;
	private float orbitDirection = 1;
	private Vector3 playerPos;
	private GameObject startPlanet;
	private Vector3 startPlanetPos;
	private Vector3 targetPosition;
	private Quaternion targetRotation; 
	private Camera mainCam;
	private bool docked = true;
	public bool orbiting = false;
	public bool canOrbit = true;
	public bool orbitingComet = false;
	public Vector3 orbitPos;
	public Vector3 cometPos;
	public int astronautCount = 0;
	public int thrustCount = 100;
	public float time = 0;
	public Vector3 thrustPos;
	public Vector3 enterPos;
	public int cometDirection;
	public bool setOrbit = true;
	public bool atHome = false;
	public string deathType;
	public bool dead = false;
	private GameObject audioManager;

	void Start () {
		time = 0;
		mainCam = Camera.main;
		startPlanet = GameObject.FindGameObjectWithTag ("StartPlanet");
		startPlanetPos = new Vector3 (startPlanet.transform.position.x, startPlanet.transform.position.y, 0);
		transform.position = startPlanetPos - new Vector3 (distance, 0, 0);
		audioManager = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 15;
		mousePos = mainCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z - mainCam.transform.position.z));

		if (docked == true && Vector3.Distance (mousePos, startPlanetPos) >= Vector3.Distance (transform.position, startPlanetPos)*1.3) {
			gameObject.transform.LookAt (mousePos);
			Vector3 direction = mousePos - startPlanetPos;
			transform.position = startPlanetPos + distance * direction.normalized;
		}

		if (Input.GetMouseButtonDown (0)) {
			if (docked == true && Vector3.Distance (mousePos, startPlanetPos) >= Vector3.Distance (transform.position, startPlanetPos)*1.3) {
				thrustPos = transform.position;
				docked = false;
				audioManager.GetComponent<AudioManager>().thrustSound = true;
			}
			else if (orbiting == true && thrustCount > 0 && atHome == false) {
				orbitDirection *= 0.5f;
			}
		} 
		if (Input.GetMouseButtonUp (0)) {
			if (orbiting == true && thrustCount > 0 && atHome == false) {
				canOrbit = false;
				thrustPos = transform.position;
				thrustCount -= 1;
				time = 0;
				orbiting = false;
				orbitingComet = false;
				transform.position += transform.forward*Time.deltaTime*moveSpeed;
				audioManager.GetComponent<AudioManager>().thrustSound = true;
			}
		}

		if (Vector3.Distance(orbitPos, transform.position) > 1.5f) {
			canOrbit = true;
		}

		if (docked == false && orbiting == false){
			transform.position += transform.forward*Time.deltaTime*moveSpeed;
		}

		if (setOrbit == true) {

			Vector3 thrustVec = thrustPos - enterPos;
			Vector3 perpVec = enterPos - orbitPos;
			thrustVec.Normalize();
			perpVec.Normalize ();
			Vector3 thrustEnd = enterPos + (thrustVec);
			Vector3 perpEnd = enterPos + (perpVec);

			if (enterPos.x >= orbitPos.x) {
				if(thrustEnd.y <= perpEnd.y) {
					orbitDirection = 1;
				}
				else {
					orbitDirection = -1;
				}
			}	
			else if (enterPos.x < orbitPos.x) {
				if(thrustEnd.y >= perpEnd.y) {
					orbitDirection = 1;
				}
				else {
					orbitDirection = -1;
				}
			}
			setOrbit = false;
		}

		if (orbiting == true && canOrbit == true) {
			time -= Time.deltaTime;
			if (orbitingComet == true) {
				orbitPos = cometPos;
				transform.position = new Vector3(transform.position.x+(0.03f*cometDirection), transform.position.y, transform.position.z);
			}
			transform.RotateAround(orbitPos, Vector3.forward, 1*orbitDirection);
			Vector3 newVec = orbitPos - transform.position;
			Vector3 newVector = Vector3.Cross (newVec, Vector3.forward);
			newVector.Normalize();
			Vector3 newPoint = orbitDirection*10*newVector+orbitPos;
			transform.LookAt(newPoint);
		}

		if (time < 0 && time > -1) {
			deathType = "time";
			gameObject.SetActive (false);
			dead = true;
			audioManager.GetComponent<AudioManager>().explosionSound = true;

		}

		if (Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}

		if (Input.GetKeyDown(KeyCode.T)) {
			Application.LoadLevel("MissionSelect");
		}
	}
}
