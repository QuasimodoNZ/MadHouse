using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {

	private GameObject target;

	// Use this for initialization
	void Start () {
		GetComponentInChildren<Improve> ().setMenu (gameObject);
		GetComponentInChildren<Remove> ().setMenu (gameObject);
	}

	public void setTarget (GameObject target){
		this.target = target;
	}

	public void improve (){
		Debug.Log ("Improvement!");
		target.name = target.name + "+";
	}

	public void remove(){
		Destroy (target);
		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
