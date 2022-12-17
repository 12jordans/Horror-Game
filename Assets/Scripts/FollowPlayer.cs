using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class FollowPlayer : MonoBehaviour
{
	public bool flicker = true;
	Coroutine coroutine=null;
	public bool lightTimer = true;
	public SpotLightOn spotlightOn;
	public SpotLightOn spotlightOn2;
	public CameraSwitch cameraSwitch;
	public Transform ghost;
	public PlayerHealth playerHealth;
	public HealthBar healthBar;
	public GameController gameController;
	public int temp = 1;
	//public Animator animator;
	public Text text;
	//public Animator animator;
	public int _index = 2;
	public Transform target;
	NavMeshAgent nav;
	public int l;
	public MouseLook mouseLook;
	public PlayerMovement playerMovement;

	public MouseLook mouseLook2;
	public PlayerMovement playerMovement2;
	// Start is called before the first frame update
	public void Start()
	{
		spotlightOn.LightOff();
		spotlightOn2.LightOn();
		_index = 2;
		l = 0;
		ChangeAnimation();
		nav = GetComponent<NavMeshAgent>();
		//GetComponent<NavMeshAgent>().transform.position = new Vector3(-204, 3, 200);
		cameraSwitch.MainCam();
	}

	// Update is called once per frame
	public void Update()
	{
		if (Time.fixedTime >= 1)
		{
			nav.SetDestination(target.position);
		}
		float distance = Vector3.Distance(GetComponent<NavMeshAgent>().transform.position, target.transform.position);
        if (distance <= 30)
        {
			lightTimer = true;
			
		}
		if (distance <= 10)
		{
			Flicker();
			//mouseLook.StopGame();
			playerMovement.StopGame();
			//mouseLook.playerBody.transform.LookAt(ghost);
			spotlightOn2.LightOff();
			
		}
	}



	private void OnTriggerEnter(Collider other)
	{
		
		cameraSwitch.GhostCam();
		lightTimer = false;
		StopCoroutine(coroutine);
		StopAllCoroutines();
		spotlightOn2.LightOff();
		spotlightOn.LightOn();
		attack();
	}



	public void attack()
	{
		flicker = false;
		spotlightOn2.LightOff();
		_index = 3;
		ChangeAnimation();
		Invoke("waiter", 3f);
		//Invoke("OnceMoved", 7f);
	}



	public void waiter()
	{
		if (temp == 1)
		{
			float x;
			float z;
			float playerx = target.transform.position.x;
			float playerz = target.transform.position.z;
			playerHealth.currentHealth -= 1;
			healthBar.SetHealth(playerHealth.currentHealth);
			if (playerx <= -325)
			{
				float x2 = playerx + 100;
				x = Random.Range(x2, -185);
			}
			else
			{
				float x2 = playerx + -100;
				x = Random.Range(-498, x2);
			}
			if (playerz <= 115)
			{
				float z2 = playerz + 100;
				z = Random.Range(z2, 260);
			}
			else
			{
				float z2 = playerz + -100;
				z = Random.Range(-9, z2);
			}

			float y = 3;
			GetComponent<NavMeshAgent>().transform.position = new Vector3(x, y, z);
			//Debug.Log("here");
			//temp = 0;
			l = 0;
			_index = 1;
			ChangeAnimation();
			mouseLook.gameRunning = true;
			cameraSwitch.MainCam();
			playerMovement.gameRunning = true;
			Cursor.lockState = CursorLockMode.Locked;
			spotlightOn.LightOff();
			spotlightOn2.LightOn();
			lightTimer = true;
			flicker = true;
		}

	}

	public void OnceMoved()
	{
		temp = 1;
	}



	public void ChangeAnimation()
	{

		Animator animator1 = GameObject.Find("ghost_tPose").GetComponent<Animator>();
		animator1.SetInteger("index", _index);

		//animator1 = GameObject.Find("girl/clothingSet_01_body").GetComponent<Animator>();
		//animator1.SetInteger("index", _index);

		string name = "";
		switch (_index)
		{
			case 0:
				name = "idle";
				break;
			case 1:
				name = "walk";
				break;
			case 2:
				name = "run";
				break;
			case 3:
				name = "attack";
				break;
			case 4:
				name = "taking damage";
				break;


		}

		//text.text = string.Concat(_index.ToString(), ". ", name);
	}


	public IEnumerator ExampleCoroutine()
	{
		if (flicker)
		{
			//Print the time of when the function is first called.
			//yield on a new YieldInstruction that waits for 5 seconds.
			//yield return new WaitForSeconds(1);
			spotlightOn2.LightOff();
			yield return new WaitForSeconds(1);
			spotlightOn2.LightOn();



			//After we have waited 5 seconds print the time again.
		}
	
	}
	void Flicker()
    {
		if (lightTimer == true)
		{
			coroutine = StartCoroutine(ExampleCoroutine());
			//Debug.Log("here");
			lightTimer = false;
		}
	}
}
