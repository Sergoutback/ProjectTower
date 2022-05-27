using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class camcontroll : MonoBehaviour {
	public Transform playerTransform;
	public float moveSpeed;
	
	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
		/*
		this.transform.position = new Vector3(){
				x=playerTransform.position.x,
				y=playerTransform.position.y,
				z=transform.position.z,
		};
		if(this.playerTransform){
		Vector3 target= new Vector3(){
		x=playerTransform.position.x,
		y=playerTransform.position.y,
		z=transform.position.z,
		};
	*/
		Vector3 target = new Vector3()
		{
			x = playerTransform.position.x,
			y = playerTransform.position.y,
			z = transform.position.z,
		};
			Vector3 pos= Vector3.Lerp(a: transform.position,b: target, t: moveSpeed * Time.deltaTime);
		transform.position = pos;
		
		

	}
}
