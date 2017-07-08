using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

	public GameObject[] spawnPrefabs;

	private Transform playerTransform;
	private float spawnY = -30.0f;
	private float spawnLength = 5.0f;
	private int amnOnScreen = 30;
	private float safeZone = 50f;
	private int lastPrefabIndex = 0;
	private int prevIndexx = 0;

	private List<GameObject> activeTiles;

	// Use this for initialization
	void Start () 
	{
		activeTiles = new List<GameObject> ();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		for (int i = 0; i < amnOnScreen; i++)
		{
			SpawnTile ();
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerTransform)
		{
			if (playerTransform.position.y - safeZone > (spawnY - amnOnScreen * spawnLength))
			{
				SpawnTile ();
				DeleteTile ();
			}
		}
		else
			return;
	}

	void SpawnTile(int prefabIndex = -1)
	{
		GameObject go;
		int indexx;
		indexx = RandomPrefabIndex ();

		if ((indexx == 0 && prevIndexx == 1) || (indexx == 0 && prevIndexx == 6) 
			|| (indexx == 1 && prevIndexx == 0) || (indexx == 1 && prevIndexx == 6)
			|| (indexx == 6 && prevIndexx == 1) || (indexx == 6 && prevIndexx == 0))
		{
			spawnLength = 3f;
		}
		else if ((indexx == 0 && prevIndexx == 3) || (indexx == 0 && prevIndexx == 7) || (indexx == 3 && prevIndexx == 0) || (indexx == 7 && prevIndexx == 0)
			|| (indexx == 1 && prevIndexx == 2) || (indexx == 1 && prevIndexx == 7) || (indexx == 2 && prevIndexx == 1) || (indexx == 7 && prevIndexx == 1)
			|| (indexx == 6 && prevIndexx == 2) || (indexx == 6 && prevIndexx == 3) || (indexx == 2 && prevIndexx == 6) || (indexx == 3 && prevIndexx == 6))
		{
			spawnLength = 4f;
		}
		else if ((indexx == 0 && prevIndexx == 5) || (indexx == 0 && prevIndexx == 8) || (indexx == 5 && prevIndexx == 0) || (indexx == 8 && prevIndexx == 0)
			|| (indexx == 1 && prevIndexx == 4) || (indexx == 1 && prevIndexx == 8) || (indexx == 4 && prevIndexx == 1) || (indexx == 8 && prevIndexx == 1)
			|| (indexx == 6 && prevIndexx == 4) || (indexx == 6 && prevIndexx == 5) || (indexx == 4 && prevIndexx == 6) || (indexx == 5 && prevIndexx == 6))
		{
			spawnLength = 5.5f;
		}
		else if ((indexx == 2 && prevIndexx == 3) || (indexx == 2 && prevIndexx == 7)
			|| (indexx == 3 && prevIndexx == 2) || (indexx == 3 && prevIndexx == 7)
			|| (indexx == 7 && prevIndexx == 2) || (indexx == 7 && prevIndexx == 3))
		{
			spawnLength = 5f;
		}
		else if ((indexx == 2 && prevIndexx == 5) || (indexx == 2 && prevIndexx == 8) || (indexx == 5 && prevIndexx == 2) || (indexx == 8 && prevIndexx == 2)
			|| (indexx == 3 && prevIndexx == 4) || (indexx == 3 && prevIndexx == 8) || (indexx == 4 && prevIndexx == 3) || (indexx == 8 && prevIndexx == 3)
			|| (indexx == 7 && prevIndexx == 4) || (indexx == 7 && prevIndexx == 5) || (indexx == 4 && prevIndexx == 7) || (indexx == 5 && prevIndexx == 7))
		{
			spawnLength = 6.5f;
		}
		else if ((indexx == 4 && prevIndexx == 5) || (indexx == 4 && prevIndexx == 8)
			|| (indexx == 5 && prevIndexx == 4) || (indexx == 5 && prevIndexx == 8)
			|| (indexx == 8 && prevIndexx == 4) || (indexx == 8 && prevIndexx == 5))
		{
			spawnLength = 8f;
		}

//		if ((indexx == 2 && prevIndexx < 2) || (indexx == 3 && prevIndexx < 2))
//		{
//			spawnLength = 4f;
//		}
//		else
//		if (indexx < 2 && prevIndexx >= 2)
//		{
//			spawnLength = 4f;
//		}
//		else
//		if (indexx < 2 && prevIndexx < 2)
//		{
//			spawnLength = 5f;
//		}
//		else
//		if ((indexx == 3 && prevIndexx == 2) || (indexx == 2 && prevIndexx == 3))
//		{
//			spawnLength = 3f;
//		}
		spawnY += spawnLength;
		go = Instantiate (spawnPrefabs [indexx]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.up * spawnY;

		activeTiles.Add (go);

		prevIndexx = indexx;
	}

	void DeleteTile()
	{
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0);
	}

	int RandomPrefabIndex()
	{
		if (spawnPrefabs.Length <= 1)
		{
			return 0;
		}

		int randomIndex = lastPrefabIndex;
		while ((randomIndex == lastPrefabIndex) 
			|| (randomIndex == 2 && lastPrefabIndex == 0) || (randomIndex == 2 && lastPrefabIndex == 4) 
			|| (randomIndex == 0 && lastPrefabIndex == 2) || (randomIndex == 0 && lastPrefabIndex == 4) 
			|| (randomIndex == 4 && lastPrefabIndex == 0) || (randomIndex == 4 && lastPrefabIndex == 2) 
			|| (randomIndex == 1 && lastPrefabIndex == 3) || (randomIndex == 1 && lastPrefabIndex == 5)
			|| (randomIndex == 3 && lastPrefabIndex == 1) || (randomIndex == 3 && lastPrefabIndex == 5)
			|| (randomIndex == 5 && lastPrefabIndex == 1) || (randomIndex == 5 && lastPrefabIndex == 3)
			|| (randomIndex == 6 && lastPrefabIndex == 7) || (randomIndex == 6 && lastPrefabIndex == 8)
			|| (randomIndex == 7 && lastPrefabIndex == 6) || (randomIndex == 7 && lastPrefabIndex == 8)
			|| (randomIndex == 8 && lastPrefabIndex == 6) || (randomIndex == 8 && lastPrefabIndex == 7)
		)
		{
			randomIndex = Random.Range (0, spawnPrefabs.Length);
		}

		lastPrefabIndex = randomIndex;
		return randomIndex;
	}
}
