using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCondition : MonoBehaviour
{
	public float delayDecrease;

	[SerializeField]
	private HungerModel hunger;
	[SerializeField]
	private Image hungerBar;

	private IEnumerator cor;

	void Awake ()
	{
		hunger.hungerMeter = 100;
		cor = Starve ();
	}

	void Start ()
	{
		StartCoroutine (cor);
	}

	void Update ()
	{
		hungerBar.fillAmount = (float) hunger.hungerMeter/100f;
	}

	public void Replenish (int point)
	{
		hunger.ReplenishHunger (point);
	}
	
	IEnumerator Starve ()
	{
		while (true)
		{
			hunger.DecreaseHunger ();
			yield return new WaitForSeconds(delayDecrease);
		}
	}
}
