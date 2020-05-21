using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCanon : MonoBehaviour {

	[SerializeField]
	private GameObject ball;
	[SerializeField]
	private ParticleSystem shotPar;
	[SerializeField]
	private bool enemyShoot;
	
	void Start () {
		if (enemyShoot)
		{
			EnemyShoot();
		}
	}
	
	void FixedUpdate () {
		if (!enemyShoot)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				GameObject ins =  Instantiate(ball ,transform.position, transform.rotation);
				ins.GetComponent<Rigidbody>().velocity = transform.forward * -100;
				Destroy(ins,5);
				shotPar.Play();
			}
		}
		

	}

	private void EnemyShoot(){
			GameObject ins =  Instantiate(ball ,transform.position, transform.rotation);
			ins.GetComponent<Rigidbody>().velocity = transform.forward * -100;
			ins.tag = "E_ball";
			Destroy(ins,5 * Time.deltaTime);
			shotPar.Play();
			Invoke("EnemyShoot",Random.Range(40 ,400) * Time.deltaTime);
	}
}
