using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	[SerializeField]
	private bool isFocus = false;

	private Rigidbody2D rb;
	private Interactable targetFocus;
	private PlayerCondition playerCondition;

	void Awake ()
	{
		rb = GetComponent<Rigidbody2D> ();
		playerCondition = GetComponent<PlayerCondition> ();
	}

	public void DoInteract ()
	{
		if (targetFocus)
		{
			targetFocus.Interact ();
		}
	}

	public void StopDoInteract ()
	{
		if (targetFocus)
		{
			targetFocus.StopInteract ();
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Interactable")
		{
			targetFocus = col.gameObject.GetComponent<Interactable> ();
			isFocus = true;
		}

		if (col.gameObject.tag == "Door")
		{
			// Masuk ruang orang
		}

		if (col.gameObject.tag == "MyRoom")
		{
			int replenish = 0;
			for (int i = 0; i < Inventory.instance.foods.Count; i++)
			{
				replenish = Inventory.instance.foods[i].point;
			}
			playerCondition.Replenish (replenish);
			Inventory.instance.ClearFood ();
		}

		if (col.gameObject.tag == "Trigger")
		{
			GameManager.instance.GameOver ("Busted");
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.tag == "Interactable")
		{
			targetFocus.ExtraInteraction ();
			targetFocus = null;
			isFocus = false;
		}

		if (col.gameObject.tag == "Door")
		{
			// Keluar ruang orang
		}

		if (col.gameObject.tag == "MyRoom")
		{
			// Keluar ruang sendiri
		}
	}
}
