using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhenCollision : MonoBehaviour {

	//private int cols = 0;
	//private GameObject blueGo;
	//private GameObject pinkGo;
	public PlayerMotor motor;
	private AudioSource aud;
	private GameManager gm;
	private SpawnManager sm;

	private GameObject red1;
	private GameObject red2;
	private GameObject red3;

//	public Text tempScoreText;
                             //	public Text highScoreText;

	public int tempScore;
	public int highScore;

	public GameObject go;

	public Vector3 tempPos;

	void Awake()
	{
		motor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
		aud = GameObject.FindGameObjectWithTag ("SM").GetComponent<AudioSource> ();

		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameManager> ();
	}

	void Start()
	{
		//blueGo = GameObject.FindGameObjectWithTag ("blue");
		//pinkGo = GameObject.FindGameObjectWithTag ("pink");
//		motor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
//		aud = GameObject.FindGameObjectWithTag ("SM").GetComponent<AudioSource> ();
//
//		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameManager> ();

//		red1 = GameObject.FindGameObjectWithTag ("red1");
//		red2 = GameObject.FindGameObjectWithTag ("red2");
//		red3 = GameObject.FindGameObjectWithTag ("red3");
	}

	void Update()
	{
		red1 = GameObject.FindGameObjectWithTag ("red1");
		red2 = GameObject.FindGameObjectWithTag ("red2");
		red3 = GameObject.FindGameObjectWithTag ("red3");
	}

	void OnTriggerEnter(Collider other) 
	{
		//cols = 0;
		if (this.gameObject.tag == "pink")
		{
			//cols++;
			gm.DecrementTemp ();
			OnHit();
		}
		else if (this.gameObject.tag == "red1")
		{
			//cols++;
			//OnHit();
			print ("die");
			motor.OnDeath();
		}
		else if (this.gameObject.tag == "red2")
		{
			//cols++;
             
			print ("die");
			motor.OnDeath();
		}
		else if (this.gameObject.tag == "red3")
		{
			//cols++;
			//OnHit();
			print ("die");
			motor.OnDeath();
		}
		else if(this.gameObject.tag == "blue1")
		{
			print ("Bounce");
			motor.needBounce = true;
//			Destroy (this.gameObject);
			tempPos = transform.position;
			StartCoroutine (ExecuteAfterTime1 (.2f));
			//this.gameObject.SetActive(false);
		}
		else if(this.gameObject.tag == "blue2")
		{
			print ("Bounce");
			motor.needBounce = true;
			//Destroy (this.gameObject);
			tempPos = transform.position;
			StartCoroutine (ExecuteAfterTime2 (.2f));
			//this.gameObject.SetActive(false);
		}
		else if(this.gameObject.tag == "blue3")
		{
			print ("Bounce");
			motor.needBounce = true;
			//Destroy (this.gameObject);
			tempPos = transform.position;
			StartCoroutine (ExecuteAfterTime3 (.2f));
			//this.gameObject.SetActive(false);
		}

//		if (cols > 1)
//		{
//			Destroy (blueGo);
//		}
//
//		if (this.gameObject.tag == "blue" && cols == 1)
//		{
//			
//			Destroy (other.gameObject);
//		}
//		else if (this.gameObject.tag == "pink" && cols == 1)
//		{
//			
//			Destroy (gameObject);
//		}
	}

	void OnHit()
	{
		gameObject.SetActive(false);
		aud.Play ();
	}

	IEnumerator ExecuteAfterTime1 (float time)
	{
		yield return new WaitForSeconds (time);

		go = Instantiate (red1) as GameObject;
		//go.transform.SetParent (transform);
		go.transform.position = tempPos;
		this.gameObject.SetActive(false);
		//Destroy (this.gameObject);
	}

	IEnumerator ExecuteAfterTime2 (float time)
	{
		yield return new WaitForSeconds (time);

		go = Instantiate (red2) as GameObject;
		//go.transform.SetParent (transform);
		go.transform.position = tempPos;
		this.gameObject.SetActive(false);
		//Destroy (this.gameObject);
	}

	IEnumerator ExecuteAfterTime3 (float time)
	{
		yield return new WaitForSeconds (time);

		go = Instantiate (red3) as GameObject;
		//go.transform.SetParent (transform);
		go.transform.position = tempPos;
		this.gameObject.SetActive(false);
		//Destroy (this.gameObject);
	}

}
