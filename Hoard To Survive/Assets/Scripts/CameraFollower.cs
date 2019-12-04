using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

	public Vector3 offset;

	[SerializeField]
	private Transform target;
	[SerializeField]
    private float smoothTime = 0.3F;
	
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
