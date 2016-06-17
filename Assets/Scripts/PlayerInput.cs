using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerInput : NetworkBehaviour
{
	private PlayerMovement playerMovement;

	void Start ()
	{
		playerMovement = gameObject.GetComponent<PlayerMovement>();
	}

	void Update ()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		if (horizontal > 0)
		{
			playerMovement.RecieveInput(1);
		}
		else if (horizontal < 0)
		{
			playerMovement.RecieveInput(3);
		}
		else if (vertical > 0)
		{
			playerMovement.RecieveInput(0);
		}
		else if (vertical < 0)
		{
			playerMovement.RecieveInput(2);
		}
	}
}
