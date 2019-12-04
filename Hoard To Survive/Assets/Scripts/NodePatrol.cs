using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePatrol : MonoBehaviour
{
	[SerializeField]
    private List<Transform> destinations;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            int rd = Random.Range (0, destinations.Count);
            col.gameObject.GetComponent<EnemyBehaviour> ().MoveTo (destinations[rd].position);
        }
    }
}
