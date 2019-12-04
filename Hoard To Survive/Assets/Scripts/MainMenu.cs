using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	[SerializeField]
	private GameObject mainPanel;
	[SerializeField]
	private GameObject aboutPanel;

	public void Play ()
	{
		SceneManager.LoadScene ("Premise");
	}

	public void About ()
	{
		mainPanel.SetActive (false);
		aboutPanel.SetActive (true);
	}

	public void Quit ()
	{
		Application.Quit ();
	}

	public void Back ()
	{
		mainPanel.SetActive (true);
		aboutPanel.SetActive (false);
	}

}
