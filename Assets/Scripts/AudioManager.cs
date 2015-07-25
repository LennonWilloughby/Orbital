using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public bool astronautSound = false;
	public bool thrustSound = false;
	public bool explosionSound = false;
	public bool wormholeSound = false;
	public bool victorySound = false;
	public bool driftSound = false;

	public AudioSource[] sounds;
	public AudioSource astronaut;
	public AudioSource thrust;
	public AudioSource explosion;
	public AudioSource wormhole;
	public AudioSource victory;
	public AudioSource drift;

	// Use this for initialization
	void Start () {
	
		sounds = GetComponents<AudioSource>();
		astronaut = sounds[0];
		thrust = sounds[1];
		explosion = sounds[2];
		wormhole = sounds[3];
		victory = sounds[4];
		drift = sounds[5];
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(astronautSound == true) {
			astronaut.Play();
			astronautSound = false;
		}
		if(thrustSound == true) {
			thrust.Play();
			thrustSound = false;
		}
		if(explosionSound == true) {
			explosion.Play();
			explosionSound = false;
		}
		if(wormholeSound == true) {
			wormhole.Play();
			wormholeSound = false;
		}
		if(victorySound == true) {
			victory.Play();
			victorySound = false;
		}
		if(driftSound == true) {
			drift.Play();
			driftSound = false;
		}
	}
}
