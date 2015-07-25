using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {

	public string level;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter() {

		StartCoroutine(Wait());
		Application.LoadLevel (level);

	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2f);

	}
}
