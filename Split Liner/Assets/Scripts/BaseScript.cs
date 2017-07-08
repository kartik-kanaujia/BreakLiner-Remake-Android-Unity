using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour {

	//private int cols = 0;
	//private GameObject blueGo;
	//private GameObject pinkGo;
	private PlayerMotor motor;

	void Start()
	{
		//blueGo = GameObject.FindGameObjectWithTag ("blue");
		//pinkGo = GameObject.FindGameObjectWithTag ("pink");
		motor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player")
		{
			//cols++;
			//Destroy (other.gameObject);
			motor.OnDeath();
		}
		if(other.tag == "red1")
		{
			Destroy (other.gameObject);
		}
	}
}
