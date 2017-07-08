using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour 
{
	private CharacterController controller;
	public float speed = 10f;
	public PlayerMotor motor;
	private Transform lookAt;
	private Vector3 startOffset;
	private Vector3 moveVector;
//	private float minimum = 0f;
//	private float maximum = 0f;

	//public Vector3 playerRelative;

	public bool needAcc;
	public Vector3 tempPos;

	// Use this for initialization
	void Start () 
	{
		controller = GetComponent<CharacterController> ();
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
		startOffset = transform.position - lookAt.position;

		needAcc = motor.needCamAcc;

	}
	
	// Update is called once per frame
	void Update () 
	{



//		if (motor.moveVector.y > speed)
//		{
//			speed = motor.moveVector.y + 5f;
//		}
//		else
//		{
//			speed = 10f;
//		}
		if (motor.buttonEnabled == true)
		{
			transform.position = lookAt.position + startOffset;
		}
		else
		{
			if (!lookAt)
			{
				return;
			}
			//Vector3 playerRelative = lookAt.InverseTransformPoint(transform.position);
			tempPos = transform.position;

			if (motor.needCamAcc == true)
			{
				tempPos.y = lookAt.position.y;
				this.transform.position = Vector3.Lerp (this.transform.position, tempPos, Time.deltaTime);
			}



			controller.Move ((Vector3.up * speed) * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 0);
		}
	}
}
