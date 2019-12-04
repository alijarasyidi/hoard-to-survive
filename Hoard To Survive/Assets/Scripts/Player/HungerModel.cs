[System.Serializable]
public class HungerModel
{
	public int hungerMeter;

	public void ReplenishHunger (int food)
	{
		hungerMeter += food;
		if (hungerMeter >= 100)
		{
			hungerMeter = 100;
		}
	}

	public void DecreaseHunger ()
	{
		hungerMeter--;
		if (hungerMeter <= 0)
		{
			hungerMeter = 0;
			GameManager.instance.GameOver ("Wasted");
		}
	}
}
