using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBehaviour : MonoBehaviour
{
	// [SerializeField]
	// private float speed;
	[SerializeField]
	private Transform setPoint;
	[SerializeField]
	private GameObject losKanan;
	[SerializeField]
	private GameObject losBawah;
	[SerializeField]
	private GameObject losKiri;
	[SerializeField]
	private GameObject losAtas;

	void Start ()
	{
		transform.DOMove (setPoint.position, 3f, false);
	}

	public void MoveTo (Vector3 dest)
	{
		float hor = dest.x - transform.position.x;
		float ver = dest.y - transform.position.y;
		if (Mathf.Abs(hor) >= Mathf.Abs(ver))
		{
			if (hor >= 0f)
			{
				Kanan ();
			} else
			{
				Kiri ();
			}
		} else
		{
			if (ver >= 0f)
			{
				Atas ();
			} else
			{
				Bawah ();
			}
		}

		transform.DOMove (dest, 3f, false);
	}

	void Kanan ()
	{
		losKanan.SetActive (true);
		losKiri.SetActive (false);
		losBawah.SetActive (false);
		losAtas.SetActive (false);
	}

	void Kiri ()
	{
		losKanan.SetActive (false);
		losKiri.SetActive (true);
		losBawah.SetActive (false);
		losAtas.SetActive (false);
	}

	void Bawah ()
	{
		losKanan.SetActive (false);
		losKiri.SetActive (false);
		losBawah.SetActive (true);
		losAtas.SetActive (false);
	}

	void Atas ()
	{
		losKanan.SetActive (false);
		losKiri.SetActive (false);
		losBawah.SetActive (false);
		losAtas.SetActive (true);
	}
}
