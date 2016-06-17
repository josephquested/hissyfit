using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerRender : NetworkBehaviour
{
	private SpriteRenderer spriteRenderer;

	public Sprite[] sprites;

	void Start ()
	{
		spriteRenderer = this.GetComponent<SpriteRenderer>();
	}

	public void UpdateDirection (int direction)
	{
		spriteRenderer.sprite = sprites[direction];
	}
}
