using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class FollowPlayer : MonoBehaviour
{
<<<<<<< HEAD
=======
	public SpawnManager spawnManager;
	public GameObject ghostMove;
	public bool flicker = true;
	Coroutine coroutine=null;
	public bool lightTimer = true;
	public SpotLightOn spotlightOn;
	public SpotLightOn spotlightOn2;
	public CameraSwitch cameraSwitch;
	public Transform ghost;
>>>>>>> face785e18455f04d856fac268ac15eef05939a4
	public PlayerHealth playerHealth;
	public HealthBar healthBar;
	public int temp = 1;
	//public Animator animator;
	public Text text;
	//public Animator animator;
<<<<<<< HEAD

	public int _index = 1;
	public Transform target;
    NavMeshAgent nav;
    // Start is called before the first frame update
    public void Start()
    {
		
		ChangeAnimation();
		nav = GetComponent<NavMeshAgent>();

	}

    // Update is called once per frame
    public void Update()
    {
		
		if (Time.fixedTime >5)
		{
			_index = 1;
			ChangeAnimation();
		}
		if (Time.fixedTime > 8)
		{
			_index = 2;
			ChangeAnimation();
		}
		
		
		if (Time.fixedTime >= 10)
        {
            nav.SetDestination(target.position);
			attack();

			
		}
=======
	public int _index = 2;
	public Transform target;
	NavMeshAgent nav;
	public int l;
	public MouseLook mouseLook;
	public PlayerMovement playerMovement;
	// Start is called before the first frame update
	public void Start()
	{
		spotlightOn.LightOff();
		spotlightOn2.LightOn();
		_index = 2;
		l = 0;
		ChangeAnimation();
		nav = GetComponent<NavMeshAgent>();
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
		if (distance <= 20)
		{

			Flicker();
			spotlightOn2.LightOff();
			
		}
        if (distance <= 5)
        {
			ghostMove.GetComponent<NavMeshAgent>().isStopped = true;
			playerMovement.StopGame();
		}
	}



	private void OnTriggerEnter(Collider other)
	{
		ghostMove.GetComponent<NavMeshAgent>().isStopped = true;
		if (playerHealth.currentHealth == 1)
		{
			onLastAttack();
		}
		lightTimer = false;
		StopCoroutine(coroutine);
		StopAllCoroutines();
		spotlightOn2.LightOff();
		spotlightOn.LightOn();
		attack();
>>>>>>> face785e18455f04d856fac268ac15eef05939a4
	}

	private void onLastAttack()
    {
		StopCoroutine(coroutine);
		StopAllCoroutines();
		spotlightOn2.LightOff();
		spotlightOn.LightOn();
		cameraSwitch.GhostCam();
	}


	public void attack()
<<<<<<< HEAD
    {
		//Debug.Log("reached");
		if (Vector3.Distance(GetComponent<NavMeshAgent>().destination, GetComponent<NavMeshAgent>().transform.position) <= 3)
		{
			if (GetComponent<NavMeshAgent>().hasPath || GetComponent<NavMeshAgent>().velocity.sqrMagnitude == 0f)
			{
				//Debug.Log("reached");
				_index = 3;
				ChangeAnimation();
				_index = 0;
				Invoke("waiter", 3f);
				Invoke("OnceMoved", 7f);
			}
			
		}
=======
	{
		flicker = false;
		spotlightOn2.LightOff();
		_index = 3;
		ChangeAnimation();
		Invoke("waiter", 3f);
>>>>>>> face785e18455f04d856fac268ac15eef05939a4
	}



	public void waiter()
	{
		if (temp == 1)
		{
<<<<<<< HEAD
			Debug.Log("here");
			//yield return new WaitForSeconds(3);
			playerHealth.currentHealth -= 1;
			healthBar.SetHealth(playerHealth.currentHealth);
			int x = Random.Range(-244, 71);
			int y = 5;
			int z = Random.Range(-24, 210);
			GetComponent<NavMeshAgent>().transform.position = new Vector3(x, y, z);
			//Debug.Log("here");
			temp = 0;
=======
			playerHealth.currentHealth -= 1;
			healthBar.SetHealth(playerHealth.currentHealth);
			changeLocation();
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
>>>>>>> face785e18455f04d856fac268ac15eef05939a4
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
	}
<<<<<<< HEAD
=======


	public IEnumerator ExampleCoroutine()
	{
		if (flicker)
		{
			spotlightOn2.LightOff();
			yield return new WaitForSeconds(1);
			spotlightOn2.LightOn();
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

	void changeLocation()
	{
		ghostMove.SetActive(false);
		float x;
		float y;
		float z;
		Vector3 pos;
		x = Random.Range(-517,-237);
		y = 5;
		z = Random.Range(10, 240);
		ghostMove.transform.position = new Vector3(x, y, z);
		ghostMove.SetActive(true);
	}
>>>>>>> face785e18455f04d856fac268ac15eef05939a4
}
