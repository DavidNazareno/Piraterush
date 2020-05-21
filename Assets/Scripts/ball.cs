using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

	[SerializeField]
	private GameObject part;
	void OnTriggerEnter(Collider other)
	{
		if(other.tag != "Player"){
			GameObject ins = Instantiate(part,transform.position,transform.rotation);
			Destroy(ins, 60 * Time.deltaTime);
			Destroy(this.gameObject, 60 * Time.deltaTime);
			Destroy(this.gameObject);
		}
	}
}
