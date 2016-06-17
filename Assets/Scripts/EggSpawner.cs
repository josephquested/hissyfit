using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class EggSpawner : NetworkBehaviour {

	private bool breakSpawnCoroutine;
	private bool canSpawn = true;

	public GameObject eggPrefab;
	public GameObject preEggPrefab;
	public Transform spawnTrans;
	public float spawnRate;
	public int maxEggs;

	Vector3 RandomPosition ()
	{
		float yScale = spawnTrans.localScale.y / 2;
		float xScale = spawnTrans.localScale.x / 2;
    return new Vector3(Random.Range(-yScale, yScale), 0.5f, Random.Range(-xScale, xScale));
	}

	public void SpawnPreEgg ()
	{
		Vector2 position = RandomPosition();
    Instantiate(preEggPrefab, position, Quaternion.identity);
	}

	public void SpawnEgg (Vector2 eggPosition)
	{
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
