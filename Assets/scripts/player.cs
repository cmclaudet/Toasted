using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Camera;

public class player : MonoBehaviour {
	public Vector3 startPosition;
	public int tileLength;
	public float animationTime;
	public Text gameOverText;

	private float timeSinceAnimationStart;
	private float animationSpeed;
	private Animator playerAnimator;

	bool playingAnimation;
	private Vector3 pushDirection;

	// Use this for initialization
	void Start () {
		startPosition = new Vector3 ((startPosition.x + 0.5f)*96.0f, (startPosition.y + 0.5f)*96.0f, 10.0f);
		transform.position = Camera.main.ScreenToWorldPoint(startPosition);
		gameOverText.enabled = false;

		playerAnimator = GetComponent<Animator> ();
		playerAnimator.enabled = false;
		playingAnimation = false;
		timeSinceAnimationStart = 0;
		playerAnimator.speed = 2.0f;
//		calculateShift ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
//			playingAnimation = true;
//			pushDirection = new Vector3 (-1.0f, 0);
			transform.position = moveOneTile (new Vector3 (-1.0f, 0));
			playerAnimator.enabled = true;
			playerAnimator.Play("walkLeft", -1, 0f);
//			playerAnimator.Play ("walkLeft");
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			transform.position = moveOneTile (new Vector3 (1.0f, 0));
			playerAnimator.enabled = true;
			playerAnimator.Play("walkRight", -1, 0f);
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.position = moveOneTile (new Vector3 (0, 1.0f));
			playerAnimator.enabled = true;
			playerAnimator.Play("walkUp", -1, 0f);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			transform.position = moveOneTile (new Vector3 (0, -1.0f));
			playerAnimator.enabled = true;
			playerAnimator.Play("walkDown", -1, 0f);
		}

		if (playingAnimation) {
			moveOneTile (pushDirection);
		}

	}

	void calculateShift() {
		float tileLengthScreen = Camera.main.WorldToScreenPoint(Vector3.zero).x + tileLength;
		float tileLengthWorld = Camera.main.ScreenToWorldPoint (new Vector3(tileLengthScreen, Screen.height/2)).x;

		animationSpeed = tileLength / animationTime;

	}

	Vector3 moveOneTile (Vector3 direction) {
		
		Vector3 destinationPositionScreen = Camera.main.WorldToScreenPoint(transform.position) + direction * tileLength;
		Vector3 destinationPositionWorld = Camera.main.ScreenToWorldPoint (destinationPositionScreen);

//		Vector3 deltaPos = destinationPositionWorld - transform.position;
//		animationSpeed = deltaPos / animationTime;

//		timeSinceAnimationStart += Time.deltaTime;
//		if (timeSinceAnimationStart >= animationTime) {
//			playingAnimation = false;
//			timeSinceAnimationStart = 0;
//		}
		float tileLengthScreen = Camera.main.WorldToScreenPoint(Vector3.zero).x + tileLength;
		float tileLengthWorld = Camera.main.ScreenToWorldPoint (new Vector3(tileLengthScreen, Screen.height/2)).x;

		Vector3 newPosition = transform.position + direction * tileLengthWorld;
		return newPosition;
	}

	void OnTriggerEnter2D (Collider2D col) {
		Debug.Log ("collision");
		if (col.gameObject.CompareTag("Toast")) {
			gameObject.SetActive(false);
			gameOverText.enabled = true;
		}
	}
}
