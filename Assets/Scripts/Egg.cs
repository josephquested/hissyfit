using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Egg : NetworkBehaviour
{
  private PlayerTail tail;

  [SerializeField] private Vector3 previousPosition;

  public void Pickup (GameObject player)
	{
    PaintEgg(player.GetComponent<SpriteRenderer>().color);
    tail = player.GetComponent<PlayerTail>();
    tail.AddEgg(this);
    gameObject.tag = "TailEgg";
  }

  void PaintEgg (Color color)
	{
		this.GetComponent<SpriteRenderer>().color = color;
	}

  public Vector3 PreviousPosition
	{
		get {
      return previousPosition;
		}
    set {
      previousPosition = value;
    }
  }
}
