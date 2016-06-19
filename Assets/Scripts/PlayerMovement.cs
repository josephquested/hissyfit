using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
	private PlayerTail playerTail;
	private int direction;
	private float speed;
	private bool canTurn = true;
	private bool canMove = true;
	private bool breakMovementCoroutine = false;
	private Vector3 previousPosition;

	public float startingSpeed;
	public float speedMultiplier;
	public bool moveAutomatically;


	public override void OnStartLocalPlayer ()
	{
		this.GetComponent<SpriteRenderer>().color = Color.blue;
		playerTail = this.GetComponent<PlayerTail>();
		speed = startingSpeed;
	}

	void Start ()
	{
		playerTail = this.GetComponent<PlayerTail>();
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
		transform.Translate(new Vector2(0, 1));
		playerTail.UpdateEggs();
	}

	void Turn (int newDirection)
	{
		direction = newDirection;
		if (direction == 0) transform.localRotation = Quaternion.Euler(0, 0, 0);
		if (direction == 1) transform.localRotation = Quaternion.Euler(0, 0, 270);
		if (direction == 2) transform.localRotation = Quaternion.Euler(0, 0, 180);
		if (direction == 3) transform.localRotation = Quaternion.Euler(0, 0, 90);
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
