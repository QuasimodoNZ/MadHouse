using UnityEngine;
using System.Collections;
using System;

public class ResourceGeneration : MonoBehaviour {
	
	//public GameObject resource = (GameObject) Resources.Load("Basic Resource");
	private System.Random rand;

	// Use this for initialization
	void Start () {
		int count = 0;
		rand = new System.Random();
		for (double i = -13.5; i < 13.5; i++) {
			for(double j = -6.7; j < 6.8; j++){
				if(rand.Next(0, 100) > 90){
					count++;
					GameObject resource = (GameObject) Resources.Load (generateDiffResources(i, j));
					Vector3 temp = new Vector3((int)i, (int)j, 1);
					Instantiate(resource, temp, new Quaternion(0, 0, 0, 0));
					resource.tag = Tags.Resource;
				}
			}
		}
	}
	private  int RoundOff (float i)
	{
		return ((int)Math.Round (i / 1.0)) * 1;
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
