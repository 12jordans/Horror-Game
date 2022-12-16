using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class FollowPlayer : MonoBehaviour
{
	public SpawnManager spawnManager;
	public GameObject ghostMove;
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
	{
		flicker = false;
		spotlightOn2.LightOff();
		_index = 3;
		ChangeAnimation();
		Invoke("waiter", 3f);
	}



	public void waiter()
	{
		if (temp == 1)
		{
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
}
