using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField]
	private GameObject p_destroy;

	private Rigidbody r_enemy;

	[SerializeField]
	private Transform pointPart;

	[SerializeField]
	private bool enemyNormal,enemyShot;

	[SerializeField]
	[Range(0,70)]
	private float speed;

	private Collider[] r_cast;

	[SerializeField]
	[Range(0,300)]
	private float radius;

	public LayerMask layer;

	private Vector3 lookPlayer;
	void Start () {

		r_enemy =  GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		r_enemy.velocity = transform.forward * speed;

		r_cast = Physics.OverlapSphere(transform.position,radius,layer);

	
		if (r_cast.Length != 0)
		{
			lookPlayer = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
			lookPlayer.y = Mathf.Clamp(lookPlayer.y , -150,-30);			
			transform.LookAt(lookPlayer);
		}
	}

	private void Shooter(){

		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Ball" || other.tag =="obstacle")
		{
			GameObject ins = Instantiate(p_destroy,pointPart.position,pointPart.rotation);
			//Destroy(ins, 10 * Time.deltaTime);
			Destroy(this.gameObject);
		}
	}


	void OnDrawGizmos()
	{
		Gizmos.color =  Color.red;
		Gizmos.DrawWireSphere (transform.position, radius);
	}
}
