using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toastSpawner : MonoBehaviour {

	public GameObject toastPrefab;
	private Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
		SpawnToast();		
	}
				
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnToast() {
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (toastPrefab, transform.position, Quaternion.identity);
	}

	Vector3 GenerateSpawnPosition() {
		
	}

}
