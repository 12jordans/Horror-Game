using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class FollowPlayer : MonoBehaviour
{
	public PlayerHealth playerHealth;
	public HealthBar healthBar;
	public int temp = 1;
	//public Animator animator;
	public Text text;
	//public Animator animator;

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
	}



	public void attack()
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
	}



	public void waiter()
	{
		if (temp == 1)
		{
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
}
