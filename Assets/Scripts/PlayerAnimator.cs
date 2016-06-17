using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerAnimator : NetworkBehaviour
{
	private Animator animator;

	void Start ()
	{
		animator = this.GetComponent<Animator>();
	}

	public void UpdateDirection (int direction)
	{
		animator.SetInteger("direction", direction);
	}
}
