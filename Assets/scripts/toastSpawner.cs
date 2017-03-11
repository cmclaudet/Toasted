using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toastSpawner : MonoBehaviour {

	public GameObject toastPrefab;
	public float spawnFrequency;

	private float timeSinceSpawn;

	// Use this for initialization
	void Start () {
		timeSinceSpawn = 0;
	}
				
	// Update is called once per frame
	void Update () {
		timeSinceSpawn += Time.deltaTime;

		if (timeSinceSpawn >= spawnFrequency) {
			SpawnToast ();
			timeSinceSpawn = 0;
		//	inactivateToasts ();
		}
	}

	void SpawnToast() {
		int xIndex = Random.Range (1, 9);
		int yIndex = Random.Range (1, 7);
		Vector3 screenPosition = new Vector3 (xIndex + 0.5f, yIndex + 0.5f) * 96;
		Vector3 worldPosition = Camera.main.ScreenToWorldPoint (screenPosition);
		worldPosition = new Vector3 (worldPosition.x, worldPosition.y, 10.0f);
		Instantiate (toastPrefab, worldPosition, Quaternion.identity);
	}



}
