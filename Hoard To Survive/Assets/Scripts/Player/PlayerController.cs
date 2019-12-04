using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private PlayerMovement playerMovement;
	private PlayerInteraction playerInteraction;
	private float horizontalInput;
	private float verticalInput;
	private Animator anim;

	void Awake ()
	{
		playerMovement = GetComponent <PlayerMovement> ();
		playerInteraction = GetComponent <PlayerInteraction> ();
		anim = GetComponent<Animator> ();
	}

	void Update ()
	{
		if (!GameManager.instance.isGameOver)
		{
			if (Input.GetKeyDown (KeyCode.E))
			{
				playerInteraction.DoInteract ();
			}

			if (Input.GetKeyUp (KeyCode.E))
			{
				playerInteraction.StopDoInteract ();
			}

			if (Input.GetKeyDown (KeyCode.Escape))
			{
				GameManager.instance.Pause ();
			}
		}
	}
	
	void FixedUpdate ()
	{
		if (!GameManager.instance.isGameOver)
		{
			horizontalInput = Input.GetAxis ("Horizontal");
			verticalInput = Input.GetAxis ("Vertical");

			anim.SetFloat ("Hori", horizontalInput);
			anim.SetFloat ("Verti", verticalInput);


			if (Mathf.Abs(horizontalInput) > .1f)
			{
				playerMovement.HorizlontalMovement (horizontalInput);
			}

			if (Mathf.Abs(verticalInput) > .1f)
			{
				playerMovement.VerticalMovement (verticalInput);
			}
		}
	}
}
