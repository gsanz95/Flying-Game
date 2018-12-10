using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour {

	public Transform followingTarget;
	public float deltaX;
	public float deltaY;
	public float deltaZ;
	public float lerpSpeed;

	private Transform camera;
	
	//
	void Start()
	{
		this.camera = gameObject.GetComponent<Transform>();
	}
	// Update is called once per frame
	void FixedUpdate () {
		updateMovement();
	}

	void updateMovement(){
		Vector3 desiredPosition = new Vector3(followingTarget.position.x + deltaX,
											followingTarget.position.y + deltaY,
											followingTarget.position.z + deltaZ);

		camera.position = Vector3.Lerp(camera.position, desiredPosition, lerpSpeed);
	}
}
