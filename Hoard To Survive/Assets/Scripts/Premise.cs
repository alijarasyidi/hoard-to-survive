using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Premise : MonoBehaviour
{
	[SerializeField]
	private GameObject panel1;
	[SerializeField]
	private GameObject panel2;
	[SerializeField]
	private GameObject panel3;
	[SerializeField]
	private GameObject panel4;
	[SerializeField]
	private Image panelClose;
	[SerializeField]
	private float delay;
	[SerializeField]
	private float wait;


	// Use this for initialization
	void Start ()
	{
		panelClose.DOFade (0f, delay);
		Invoke ("Trans2", wait);
	}

	void Trans2 ()
	{
		panel1.SetActive (false);
		panel2.SetActive (true);
		Invoke ("Trans3", wait);
	}

	void Trans3 ()
	{
		panel2.SetActive (false);
		panel3.SetActive (true);
		Invoke ("Trans4", wait);
	}

	void Trans4 ()
	{
		panel3.SetActive (false);
		panel4.SetActive (true);
		Invoke ("Trans5", wait);
	}

	void Trans5 ()
	{
		SceneManager.LoadScene ("MainGame");
	}
	
}
