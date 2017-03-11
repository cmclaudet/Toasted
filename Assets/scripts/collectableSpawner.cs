using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectableSpawner : MonoBehaviour {

	public GameObject[] collectablePrefab;
	public int score = 0;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		SpawnCollectable();
	}

	void SpawnCollectable() {
		int xIndex = Random.Range (0, 9);
		int yIndex = Random.Range (0, 7);
		int randomCollectableIndex = Random.Range(1, 4);
		Vector3 screenPosition = new Vector3 (xIndex + 0.5f, yIndex + 0.5f) * 96;
		Vector3 worldPosition = Camera.main.ScreenToWorldPoint (screenPosition);
		worldPosition = new Vector3 (worldPosition.x, worldPosition.y, 10.0f);
		Instantiate (collectablePrefab[randomCollectableIndex], worldPosition, Quaternion.identity);
	}

	void OnTriggerEnter2D (Collider2D col) {
		Debug.Log ("collision");
		if (col.gameObject.CompareTag("Collectable")) {
			Destroy(col.gameObject);
			SpawnCollectable();
			score += 50;
			print("Score:" +score);
			scoreText.text = score.ToString();
		}
	}

}
