using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceObjects : MonoBehaviour {

	public Transform ins_new,insPoint,ins_destroy,ins_reset;
	public GameObject[] insMap;
	RaycastHit hitIns,hitDes,hitRes;
	public LayerMask layer;
	private GameObject gameController;
	public bool onEnter,onExit;
	void Start () {
		onEnter = true;
		gameController =  GameObject.FindGameObjectWithTag("GameController");
	}
	
	
	void Update () {
		
		if (onEnter)
		{
			if (Physics.Raycast(ins_new.position , Vector3.forward ,out hitIns,250,layer ))
				{

					if (hitIns.collider != null)
					{ 
						
						if (hitIns.collider.tag =="Player")
						{
							InsMap();
							onEnter =  false;					
						}
								
					}
				}

				if (Physics.Raycast(ins_destroy.position , Vector3.forward ,out hitDes,250,layer ))
				{
					if (hitDes.collider != null)
					{
						Debug.LogError("No");
						
						if (hitDes.collider.tag =="Player")
						{
							RemoveMap();
							onEnter =false;
							
						}
						
					}
				}
		}
		
		if (Physics.Raycast(ins_reset.position , Vector3.forward ,out hitRes,250,layer ))
		{
			if (hitRes.collider != null)
			{
						
				if (hitRes.collider.tag =="Player")
				{
						
					onEnter = true;
					Debug.LogError("Reset");
							
				}
						
			}
		}
		
				
	}

	private void InsMap(){

		
			GameObject ins = Instantiate (insMap[0],insPoint.position, insPoint.rotation);
			ins.transform.SetParent(gameController.transform);
		
		
	}

	private void RemoveMap(){
		
		
			Destroy(gameController.transform.GetChild(0).gameObject);	
		

		

	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawRay(ins_destroy.position , Vector3.forward * 250);

		Gizmos.color = Color.magenta;
		Gizmos.DrawRay(ins_new.position , Vector3.forward * 250);

		Gizmos.color = Color.green;
		Gizmos.DrawRay(ins_reset.position , Vector3.forward * 250);
	}
}
