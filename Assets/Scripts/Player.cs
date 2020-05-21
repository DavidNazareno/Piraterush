using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

public Rigidbody r_player;

[SerializeField]
private Transform cameraPivot;

private Vector3  rv_boat;
private Quaternion rq_boat;

[SerializeField]
private float s_normal,s_run;

[SerializeField]
private float s_rot,s_offsetRot;

[SerializeField]
[Range(90,200)]
private float minY;

[SerializeField]
[Range(10,90)]
private float maxY;

[SerializeField]
private GameObject partDes;


private float rot;
	void Start () {
		rv_boat.y = -90;
	}
	
	
	void Update()
	{
	}
	void FixedUpdate () {
		MovePlayer();
		cameraPivot.position = Vector3.Lerp(cameraPivot.position , transform.position , 0.7f );

	}

	private void MovePlayer(){
		r_player.velocity  = transform.forward * s_normal;

		//rv_boat.y += Input.GetAxis("Vertical");

		if (Input.GetKey(KeyCode.UpArrow))
		{
			if (rv_boat.y >= -minY)
			{
				rv_boat.y -= s_rot;
			}		  
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			if (rv_boat.y <= -maxY)
			{
				rv_boat.y += s_rot;			
			}		
		}
	
		if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
		{
			rv_boat.y =  Mathf.Lerp(rv_boat.y, -90 , 0.07f);
		}
		rq_boat = Quaternion.Euler(rv_boat);

		transform.rotation = rq_boat;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "obstacle")
		{
			GameObject ins  = Instantiate(partDes,transform.position,transform.rotation);
			Destroy(ins, 40 * Time.deltaTime);
			Destroy(this.gameObject);
		}
	}
}
