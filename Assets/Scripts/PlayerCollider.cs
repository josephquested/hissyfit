using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PlayerCollider : NetworkBehaviour
{
	void OnTriggerEnter2D (Collider2D collider) {
		if (!isLocalPlayer)
		{
			return;
		}

		if (collider.tag == "Egg")
		{
			print("hit an egg!");
			EggCollision(collider.gameObject.GetComponent<Egg>());
		}

		else if (collider.tag == "TailEgg")
		{
			TailEggCollision(collider.gameObject.GetComponent<Egg>());
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (!isLocalPlayer)
		{
			return;
		}

		if (collider.tag == "Board")
		{
			SceneManager.LoadScene(0);
			// transform.position = new Vector3(0, 0.5f, 0);
		}
	}

	void EggCollision (Egg egg)
	{
		egg.Pickup(gameObject);
	}

	void TailEggCollision (Egg egg)
	{
		// SceneManager.LoadScene(0);
	}
}
