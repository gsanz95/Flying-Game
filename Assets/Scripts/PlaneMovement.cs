using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour {

	public float maxYaw;
	public float maxRoll;
	public float lerpSpeed;

	private Rigidbody planeBody;
	private Vector3 deltaEulerAngle;
	private Quaternion startingRotation;

	// Use this for initialization
	void Start () {
		this.planeBody = gameObject.GetComponent<Rigidbody>();
		this.startingRotation = this.planeBody.rotation;
	}

	void FixedUpdate()
	{
		deltaEulerAngle = new Vector3(-getYaw(), 0, -getRoll());
		Quaternion deltaRotation = Quaternion.Euler(deltaEulerAngle) * this.startingRotation;
		deltaRotation = Quaternion.Lerp(this.planeBody.rotation, deltaRotation, lerpSpeed);
		planeBody.MoveRotation(deltaRotation);
	}

	float getRoll()
	{
		float delta = Input.GetAxisRaw("Vertical");
		Debug.Log("Roll:" + delta);
		return delta * this.maxRoll;
	}

	float getYaw()
	{
		float delta = Input.GetAxisRaw("Horizontal");
		Debug.Log("Yaw" + delta);

		return delta * this.maxYaw;
	}
}
