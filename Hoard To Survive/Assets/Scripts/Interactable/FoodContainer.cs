using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodContainer : Interactable
{
	[SerializeField]
	private bool isActive = true;
	[SerializeField]
	[Range(0,100)]
	private int[] segment;
	[SerializeField]
	private Food[] foodSupply;
	[SerializeField]
	private int searchProgress = 0;
	[SerializeField]
	private int foodGet = 0;
	[SerializeField]
	private Image actionBarMeter;
	[SerializeField]
	private GameObject actionBar;
	[SerializeField]
	private GameObject lootText;

	private IEnumerator cor;

	void Awake ()
	{
		cor = Searching ();
	}

	void Update ()
	{
		if (isActive)
		{
			actionBarMeter.fillAmount = (float) searchProgress / 100f;
		}
	}

	public override void Interact ()
	{
		if (isActive)
		{
			StartCoroutine (cor);
			lootText.SetActive (true);
		}
	}

	public override void StopInteract ()
	{
		if (isActive)
		{
			StopCoroutine (cor);
			lootText.SetActive(false);
		}
	}

	public override void ExtraInteraction () // Kondisi mendapat makanan
	{
		StopCoroutine (cor);
		lootText.SetActive(false);
		if (isActive)
		{
			// Cek segment berapa saja yang dilewati
			for (int i = 0; i < segment.Length; i++)
			{
				if (searchProgress >= segment[i])
				{
					foodGet++;
				}
			}

			if (foodGet > 0)
			{
				isActive = false;
				GameManager.instance.DecreaseContainer ();
				AddFood ();
			}

			searchProgress = 0;
		}
	}

	void AddFood ()
	{
		for (int i = 0; i < foodGet; i++)
		{
			int rd = Random.Range(0, foodSupply.Length);
			Inventory.instance.AddFood (foodSupply[rd]);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (isActive)
		{
			actionBar.SetActive (true);
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		actionBarMeter.fillAmount = 0f;
		actionBar.SetActive (false);
	}

	IEnumerator Searching ()
	{
		while (true)
		{
			searchProgress += 2;

			yield return new WaitForSeconds(.1f);
			if (searchProgress >= 100)
			{
				foodGet++;
				ExtraInteraction ();
			}
		}
	}
}
