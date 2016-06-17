using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerRender : NetworkBehaviour
{
	private SpriteRenderer renderer;

	public Sprite[] sprites;

	void Start ()
	{
		renderer = this.GetComponent<SpriteRenderer>();
	}

	public void UpdateDirection (int direction)
	{
		renderer.sprite = sprites[direction];
	}
}
