using UnityEngine;
using System.Collections;

public class Bag : MonoBehaviour {
	private int bagCount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		bagCount = 0;
		foreach (Transform child in transform) {
			bagCount++;
		}
		if (bagCount == 0) {
			//THIS IS WHERE THE GAME STARTS
			//Destroy empty pallets
			foreach(GameObject obj in GameObject.FindGameObjectsWithTag(Tags.Pallet)){
				Pallet component = obj.GetComponent<Pallet>();
				if(component!=null)
					component.killSelf();
			}
			//Set building states to be buildable
			foreach(GameObject obj in GameObject.FindGameObjectsWithTag(Tags.Draggable)){
				Cube component = obj.GetComponent<Cube>();
				if(component!=null)
					component.setState(Cube.BuildingState.Pallet);
			}
			//Build terrain object
			Destroy (gameObject);
		}
	}
}
