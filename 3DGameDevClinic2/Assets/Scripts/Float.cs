using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
	public float spinSpeed = 10f;
	float originalY;
	public float floatStrength = 1; 
	public bool yesRotate;

	void Start()
	{
		this.originalY = this.transform.position.y;

	}

	void Update()
	{
		transform.position = new Vector3(transform.position.x,
			originalY + ((float)Mathf.Sin(Time.time) * floatStrength),
			transform.position.z);
		if (yesRotate == true) {
			transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
		}
	}
}