using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

	public bool allowChance = true;
	public bool reloadScore = false;
	public int tempScore;

	public bool isSignedIn = false;
	public bool askedOnce = false;

	public AudioSource aud;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (SceneManager.GetActiveScene().name == "Game")
		{
			aud.enabled = true;
		}
	}

	void Awake () {
		DontDestroyOnLoad (this);

		if (FindObjectsOfType (GetType ()).Length > 1)
		{
			Destroy (gameObject);
		}

	}
}
