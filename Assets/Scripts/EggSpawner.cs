using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class EggSpawner : NetworkBehaviour {

	private bool breakSpawnCoroutine;
	private bool canSpawn = true;

	public GameObject eggPrefab;
	public GameObject preEggPrefab;
	public int boardHeight;
	public int boardWidth;
	public float spawnRate;
	public int maxEggs;

	Vector3 RandomPosition ()
	{
		float xScale = boardWidth / 2;
		float yScale = boardHeight / 2;
    return new Vector2(
			Mathf.Round(Random.Range(-xScale, xScale)),
			Mathf.Round(Random.Range(-yScale, yScale))
		);
	}

	public void SpawnPreEgg ()
	{
		print("spawning PRE egg");
		Vector2 position = RandomPosition();
    Instantiate(preEggPrefab, position, Quaternion.identity);
	}

	public void SpawnEgg (Vector2 eggPosition)
	{
		print("spawning egg");
    Instantiate(eggPrefab, eggPosition, Quaternion.identity);
	}

	void Update ()
	{
		if (canSpawn) {
			StartCoroutine(SpawnCoroutine());
		}
	}

	IEnumerator SpawnCoroutine ()
	{
 		int eggCount = GameObject.FindGameObjectsWithTag("Egg").Length;
		if (eggCount >= maxEggs) yield break;
		canSpawn = false;
		float i = 0;

    while (!breakSpawnCoroutine)
		{
			if (i > spawnRate) { breakSpawnCoroutine = true; }
			yield return new WaitForSeconds(0.01f);
			i += Time.deltaTime;
		}

		SpawnPreEgg();
		breakSpawnCoroutine = false;
		canSpawn = true;
	}
}
