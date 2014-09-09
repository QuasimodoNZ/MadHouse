using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pallet : MonoBehaviour {

	private ArrayList cubes = new ArrayList();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddCube (GameObject c){
		var localCube = c.GetComponent<Cube>();
		if (localCube == null){
			return;
		} else {
			cubes.Add (c);
			c.transform.parent = gameObject.transform;
			gameObject.transform.localScale = gameObject.transform.localScale * 2;
		}
	}
}
