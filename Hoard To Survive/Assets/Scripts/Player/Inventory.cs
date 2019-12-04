using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	public List<Food> foods;
	public static Inventory instance;

	[SerializeField]
	private Image[] items;

	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		} else
		{
			Destroy (gameObject);
			return;
		}
	}

	void Update ()
	{
		InventoryUIUpdate ();
	}

	void InventoryUIUpdate ()
	{
		for (int i = 0; i < foods.Count; i++)
		{
			items[i].sprite = foods[i].spriteRenderer.sprite;
		}
	}

	public void AddFood (Food food)
	{
		foods.Add (food);
		if (foods.Count > 5)
		{
			foods.RemoveAt (foods.Count - 1);
		}
	}

	public void RemoveFood ()
	{
		foods.RemoveAt (foods.Count - 1);
	}

	public void ClearFood ()
	{
		for (int i = 0; i < foods.Count; i++)
		{
			items[i].sprite = null;
		}
		foods.Clear ();
	}
}
