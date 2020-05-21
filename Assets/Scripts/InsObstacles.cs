using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsObstacles : MonoBehaviour {

[SerializeField]
	private GameObject[] elements;


	[SerializeField]
	private Transform[] pos;

	
	void Start () {
		Insance();
	}

	
	void Update()
	{
		
	}

	private void Insance(){

		for (int i = 0; i < Random.Range(0,10); i++)
		{
			GameObject ins = Instantiate(elements[Random.Range(0,elements.Length)],
			new Vector3( Random.Range(pos[3].position.x, pos[2].position.x),0,Random.Range(pos[0].position.z, pos[1].position.z)),transform.rotation);
			ins.transform.SetParent(transform);
			
		}

		
	}
	
}
