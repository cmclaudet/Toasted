using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomWalk : MonoBehaviour {

	public float moveFrequency;
	public int tileLength;

	private float timeSinceLastMove;
	private int overallDirection;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		timeSinceLastMove = 0;
		overallDirection = Random.Range (0, 3);
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastMove += Time.deltaTime;

		if (timeSinceLastMove >= moveFrequency) {
			direction = getRandomDirection ();
			transform.position = moveOneTile (direction);
			timeSinceLastMove = 0;
		}
	}

	Vector3 getRandomDirection() {
		Vector3[] directions = new Vector3[] {
			new Vector3 (1.0f, 0),
			new Vector3 (-1.0f, 0),
			new Vector3 (0, 1.0f),
			new Vector3 (0, -1.0f)
		};

		Vector3 nextDirection = directions [overallDirection];

		//add some randomness to getting a change in direction
		bool changeDirection = (Random.value > 0.4f);
		if (changeDirection) {
			nextDirection = directions [Random.Range (0, 3)];
		}

		return nextDirection;
	}

	Vector3 moveOneTile (Vector3 direction) {
		Vector3 newPositionScreen = Camera.main.WorldToScreenPoint(transform.position) + direction * tileLength;
		Vector3 newPositionWorld = Camera.main.ScreenToWorldPoint (newPositionScreen);
		return newPositionWorld;
	}
}
