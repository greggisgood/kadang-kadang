using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadSplash : MonoBehaviour {

	public Texture imageToDisplay;
	public float timeToDisplayImage;
	public string nextLevelToLoad;

	private float timeForNextLevel;

	// Use this for initialization
	void Start () {
		timeForNextLevel = Time.time + timeToDisplayImage;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), imageToDisplay);
		if (Time.time >= timeForNextLevel) {
			Application.LoadLevel(nextLevelToLoad	);
		}
	}
}
