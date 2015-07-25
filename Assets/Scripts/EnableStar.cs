using UnityEngine;
using System.Collections;

public class EnableStar : MonoBehaviour {

	public int starNum;
	public string levelName;
	private int mission01Stars = 0;
	private int mission02Stars = 0;
	private int mission03Stars = 0;
	private int mission04Stars = 0;

	// Use this for initialization
	void Start () {

		gameObject.SetActive (false);

		mission01Stars = PlayerPrefs.GetInt ("Mission01Stars");
		mission02Stars = PlayerPrefs.GetInt ("Mission02Stars");
		mission03Stars = PlayerPrefs.GetInt ("Mission03Stars");
		mission04Stars = PlayerPrefs.GetInt ("Mission04Stars");

		if(levelName == "Mission01") {
			if(starNum <= mission01Stars) {
				gameObject.SetActive (true);
			}
		}
		else if(levelName == "Mission02") {
			if(starNum <= mission02Stars) {
				gameObject.SetActive (true);
			}
		}
		else if(levelName == "Mission03") {
			if(starNum <= mission03Stars) {
				gameObject.SetActive (true);
			}
		}
		else if(levelName == "Mission04") {
			if(starNum <= mission04Stars) {
				gameObject.SetActive (true);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
