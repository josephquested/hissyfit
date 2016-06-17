using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PreEgg : NetworkBehaviour
{

	private bool initialFrame = true;
	private bool inTrigger = false;
	private EggSpawner eggSpawner;

	void Start ()
	{
		eggSpawner = GameObject.FindGameObjectWithTag("EggSpawner").GetComponent<EggSpawner>();
	}

	void OnTriggerStay2D (Collider2D collider)
	{
		if (collider.tag == "Player" || collider.tag == "Egg" || collider.tag == "TailEgg")
		{
			inTrigger = true;
		}
	}

	void Update () {
		if (initialFrame)
		{
			initialFrame = false; return;
		}

		if (inTrigger)
		{
			eggSpawner.SpawnPreEgg();
		}

		else
		{
			eggSpawner.SpawnEgg(transform.position);
		}

		Destroy(gameObject);
	}
}
