using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Camera;

public class player : MonoBehaviour {
	public Vector3 startPosition;
	public int tileLength;

	// Use this for initialization
	void Start () {
		transform.position = startPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			transform.position = moveOneTile (new Vector3 (-1.0f, 0));
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			transform.position = moveOneTile (new Vector3 (1.0f, 0));
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.position = moveOneTile (new Vector3 (0, 1.0f));
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			transform.position = moveOneTile (new Vector3 (0, -1.0f));
		}

	}

	Vector3 moveOneTile (Vector3 direction) {
		Vector3 newPositionScreen = Camera.main.WorldToScreenPoint(transform.position) + direction * tileLength;
		Vector3 newPositionWorld = Camera.main.ScreenToWorldPoint (newPositionScreen);
		return newPositionWorld;
	}
}
