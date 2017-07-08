using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRotation : MonoBehaviour {

	public Transform toFollow;
	public Vector3 tempRot;

	public bool buttonEnabled = true;

	private PlayerMotor motor;

	// Use this for initialization
	void Start () 
	{
		motor = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMotor> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
//		this.transform.localRotation.z = toFollow.transform.localRotation.z;

		if (motor.buttonEnabled == true)
		{
			return;
		}
		else
		{
			transform.eulerAngles = new Vector3 (0, 0, 0);
		}

	}

	public void enableDisableButton(bool whatever)
	{
		buttonEnabled = whatever;
	}

}
