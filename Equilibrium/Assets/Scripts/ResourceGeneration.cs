using UnityEngine;
using System.Collections;
using System;

public class ResourceGeneration : MonoBehaviour {
	
	public GameObject resource = (GameObject) Resources.Load("Basic Resource");
	private System.Random rand;

	// Use this for initialization
	void Start () {
		rand = new System.Random();
		for (double i = -13.5; i < 13.5; i = i+.5) {
			for(double j = -6.7; j < 6.8; j = j + .5	){
				if(rand.Next(0, 100) > 98){
					Vector3 temp = new Vector3((float)i, (float)j, -1);
					Instantiate(resource, temp, new Quaternion(0, 0, 0, 0));
					resource.tag = Tags.Resource;
					//resource.transform.parent = 
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
