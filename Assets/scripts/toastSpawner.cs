using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toastSpawner : MonoBehaviour {

	public GameObject toastPrefab;
	public GameObject toasterPrefabHor;
	public GameObject toasterPrefabVer;
	private GameObject[] toasters;
	public float spawnFrequency;
	private float moveFrequency;


	private float timeSinceSpawn;
	private float timeSinceMove;

	// Use this for initialization
	void Start () {
		timeSinceSpawn = 0;
		timeSinceMove = 0;
		moveFrequency = toastPrefab.GetComponent<randomWalk> ().moveFrequency;
		toasters = new GameObject[] { toasterPrefabHor, toasterPrefabVer };
	}
				
	// Update is called once per frame
	void Update () {
		timeSinceSpawn += Time.deltaTime;
		timeSinceMove += Time.deltaTime;

		if (timeSinceSpawn >= spawnFrequency) {
			SpawnToast ();
			timeSinceSpawn = 0;
		}

		if (timeSinceMove >= moveFrequency) {
			inactivateToasts ();
			timeSinceMove = 0;
		}
	}

	void SpawnToast() {
		int xIndex = Random.Range (1, 9);
		int yIndex = Random.Range (1, 7);
		Vector3 screenPosition = new Vector3 (xIndex + 0.5f, yIndex + 0.5f) * 96;
		Vector3 worldPosition = Camera.main.ScreenToWorldPoint (screenPosition);
		worldPosition = new Vector3 (worldPosition.x, worldPosition.y, 10.0f);

		int num = Random.Range (0, 2);
		Instantiate (toasters[num], worldPosition, Quaternion.identity);
	}

	void inactivateToasts() {
		GameObject[] allToasts = GameObject.FindGameObjectsWithTag ("Toast");
		Vector3 screenWorldSize = Camera.main.ScreenToWorldPoint( new Vector3 (Screen.width, Screen.height));
		foreach (GameObject toast in allToasts) {
			if (toast.transform.position.x > screenWorldSize.x || toast.transform.position.x < -screenWorldSize.x
				|| toast.transform.position.y > screenWorldSize.y || toast.transform.position.y < -screenWorldSize.y) {

				toast.gameObject.SetActive (false);
			}
		}
	}

}
