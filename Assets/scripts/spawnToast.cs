using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnToast : MonoBehaviour {
	public float toastDelay;
	public GameObject toast;
	private AudioSource toastSound;
	private float timeSinceToasterSpawn;
	// Use this for initialization
	void Start () {
		timeSinceToasterSpawn = 0;
		toastSound = GameObject.Find("toastSound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceToasterSpawn += Time.deltaTime;

		if (timeSinceToasterSpawn >= toastDelay) {
			Instantiate (toast, transform.position, Quaternion.identity);
			gameObject.SetActive (false);
			toastSound.Play();
		}
	}
}
