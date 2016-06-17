using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
	private PlayerTail playerTail;
	private PlayerRender playerRender;
	private int direction;
	private float speed;
	private bool canTurn = true;
	private bool canMove = true;
	private bool breakMovementCoroutine;
	private Vector3 previousPosition;

	public float startingSpeed;
	public float speedMultiplier;
	public bool moveAutomatically;

	void Start ()
	{
		playerTail = this.GetComponent<PlayerTail>();
		playerRender = this.GetComponent<PlayerRender>();
		speed = startingSpeed;
	}

	void FixedUpdate ()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		if (moveAutomatically && canMove)
		{
			previousPosition = transform.position;
			StartCoroutine(MovementCoroutine());
		}
	}

	public void RecieveInput (int turn)
	{
		if (!canTurn || Mathf.Abs(turn - direction) == 2 || turn == direction)
		{
			return;
		}

		breakMovementCoroutine = true;
		Turn(turn);
	}

	IEnumerator MovementCoroutine ()
	{
		canMove = false;
		float i = 0;

    while (!breakMovementCoroutine)
		{
			if (i > speed)
			{
				breakMovementCoroutine = true;
			}
			yield return new WaitForSeconds(0.01f);
			i += Time.deltaTime;
		}

		Move();
		breakMovementCoroutine = false;
		canMove = true;
	}

	void Move ()
	{
		Vector2 movement = GetMovementVector();
		transform.Translate(movement);
		playerTail.UpdateEggs();
	}

	Vector2 GetMovementVector ()
	{
		Vector2 movementVector = new Vector2(0, 0);
		if (direction == 0) movementVector = new Vector2(0, 1);
		if (direction == 1) movementVector = new Vector2(1, 0);
		if (direction == 2) movementVector = new Vector2(0, -1);
		if (direction == 3) movementVector = new Vector2(-1, 0);
		return movementVector;
	}

	void Turn (int newDirection)
	{
		direction = newDirection;
		playerRender.UpdateDirection(direction);
	}

	public void UpdateSpeed ()
	{
		float newSpeed = startingSpeed - (speedMultiplier * playerTail.eggs.Count / 10);
		speed = newSpeed;
	}

	public Vector3 PreviousPosition {
		get
		{
			return previousPosition;
		}
	}

	public int Direction {
		get
		{
			return direction;
		}
	}
}
