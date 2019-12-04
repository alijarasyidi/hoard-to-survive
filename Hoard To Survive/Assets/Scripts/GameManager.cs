using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public bool isGameOver = false;

	[SerializeField]
	private int containerCount;
	[SerializeField]
	private GameObject gameOverPanel;
	[SerializeField]
	private GameObject transienPanel;
	[SerializeField]
	private GameObject pausePanel;
	[SerializeField]
	private GameObject winPanel;
	[SerializeField]
	private GameObject level1;
	[SerializeField]
	private GameObject level2;
	[SerializeField]
	private Vector3 playerPos;
	[SerializeField]
	private Transform player;
	[SerializeField]
	private Text gameOverText;
	[SerializeField]
	private PlayerCondition playerCondition;

	private int currentLevel = 1;
	private IEnumerator cor;

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

		cor = CekInventori ();
	}

	public void GameOver (string mode)
	{
		isGameOver = true;
		gameOverText.text = mode;
		gameOverPanel.SetActive (true);
	}

	public void DecreaseContainer ()
	{
		containerCount--;
		if (containerCount <= 0)
		{
			Invoke ("DelayCoroutinePlay", 1f);
		}
	}

	void DelayCoroutinePlay ()
	{
		StartCoroutine (cor);
	}

	void Finish ()
	{
		StopCoroutine (cor);
		isGameOver = true;
		if (currentLevel == 1)
		{
			transienPanel.SetActive(true);
			// Lanjut level 2
			player.position = playerPos;
			level1.SetActive (false);
			level2.SetActive (true);
			containerCount = 5; // Reset count
			currentLevel++;
			playerCondition.delayDecrease = 0.65f;

			Invoke ("MulaiLevel2", 3f);

		} else
		{
			// Finish game
			winPanel.SetActive(true);
		}
	}

	void MulaiLevel2 ()
	{
		transienPanel.SetActive(false);
		isGameOver = false;
	}

	public void Pause ()
	{
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
	}

	public void Resume ()
	{
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void Restart ()
	{
		SceneManager.LoadScene ("MainGame");
	}

	public void MainMenu ()
	{

	}

	IEnumerator CekInventori ()
	{
		while (true)
		{
			if (Inventory.instance.foods.Count == 0)
			{
				Finish ();
			}

			yield return null;
		}
	}

	public void BackToMenu ()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
