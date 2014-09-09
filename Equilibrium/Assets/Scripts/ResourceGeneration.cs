using UnityEngine;
using System.Collections;
using System;

public class ResourceGeneration : MonoBehaviour {
	
	//public GameObject resource = (GameObject) Resources.Load("Basic Resource");
	private System.Random rand;

	// Use this for initialization
	void Start () {

		rand = new System.Random();
		for (float i = -16; i < 15; i++) {
			for(float j = -9; j < 8; j++){
				if(rand.Next(0, 100) > 90){

					GameObject resource = (GameObject) Resources.Load (generateDiffResources(i, j));
					Vector3 temp = new Vector3(i, j, 1);
					Instantiate(resource, temp, new Quaternion(0, 0, 0, 0));
					resource.tag = Tags.Resource;
				}
			}
		}
	}

	
	private string generateDiffResources(double x, double y){
		int num = rand.Next (0, 100);
		if(num < 12)
						return "Coal";
		if (num < 24)
						return "Copper Ore";
		if (num < 36)
						return "Farmland";
		if (num < 48)
						return "Fish";
		if (num < 60)
						return "Gold Ore";
		if (num < 72)
						return "Iron Ore";
		if (num < 84)
						return "Oil";
				else
						return "Trees";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
