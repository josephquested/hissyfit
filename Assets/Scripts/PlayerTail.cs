using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class PlayerTail : NetworkBehaviour {

	public List<Egg> eggs;

	private PlayerMovement playerMovement;

	void Start () {
		if (!isLocalPlayer) { return; }
		eggs = new List<Egg>();
		playerMovement = gameObject.GetComponent<PlayerMovement>();
	}

	public void UpdateEggs () {
		foreach (Egg egg in eggs) {
			egg.PreviousPosition = egg.transform.position;
			Vector3 nextPosition = GetNextPositionForEgg(egg);
			egg.transform.position = nextPosition;
		}
	}

	public void AddEgg (Egg egg) {
		eggs.Add(egg);
		egg.transform.position = playerMovement.PreviousPosition;
		playerMovement.UpdateSpeed();
	}

	public Vector3 GetNextPositionForEgg (Egg egg) {
		int eggIndex = eggs.IndexOf(egg);
		if (eggIndex == 0) {
			return playerMovement.PreviousPosition;
		} else {
			return eggs[eggIndex - 1].PreviousPosition;
		}
	}
}
