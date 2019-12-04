using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private float movementSpeed;

	private Rigidbody2D rb;

	void Awake ()
	{
		rb = GetComponent<Rigidbody2D> ();
 	}

	public void HorizlontalMovement (float input)
	{
		rb.velocity = Vector2.right * input * Time.deltaTime * movementSpeed;
	}

	public void VerticalMovement (float input)
	{
		rb.velocity = Vector2.up * input * Time.deltaTime * movementSpeed;
	}
}
