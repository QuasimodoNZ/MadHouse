using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;

public class Clock : MonoBehaviour {

	private int resource;
	private int material;
	private int gold;
	//public GUIText text;

	// Use this for initialization
	void Start () {
		resource = 100;
		material = 5;
		gold = 0;
		//text.text = Convert.ToString ("Gold: " + gold + "\nResources: " + resource + "\nMaterials: " + material);
		updateResourceHUDs ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnEnable ()
	{
		GetComponent<PressGesture> ().Pressed += pressedHandler;
		GetComponent<ReleaseGesture> ().Released += releasedHandler;
	}
	
	private void OnDisable ()
	{
		GetComponent<PressGesture> ().Pressed -= pressedHandler;
		GetComponent<ReleaseGesture> ().Released -= releasedHandler;
	}

	private void releasedHandler (object sender, EventArgs e)
	{
		Debug.LogWarning ("Taking turn!");
		nextTurn ();
		//text.text = Convert.ToString ("Gold: " + gold + "\nResources: " + resource + "\nMaterials: " + material);
		updateResourceHUDs ();
	}

	private void pressedHandler (object sender, EventArgs e)
	{
		Debug.LogWarning("do I work?");
	}

	public int getGold(){
		return gold;
	}

	public int getResources(){
		return resource;
	}

	public int getMaterial(){
		return material;
	}

	public void spendMaterial(int amount){
		material = material - amount;
		//text.text = Convert.ToString ("Gold: " + gold + "\nResources: " + resource + "\nMaterials: " + material);
		updateResourceHUDs ();
	}

	public void ruinEnvironment (int amount){
		resource = resource - amount;
		//text.text = Convert.ToString ("Gold: " + gold + "\nResources: " + resource + "\nMaterials: " + material);
		updateResourceHUDs ();
	}

	public void updateResourceHUDs()
	{
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag(Tags.HUD))
		{
			HUD component = obj.GetComponent<HUD>();
			component.updateResourceHUDs(gold, resource, material);
		}
	}

	public void nextTurn(){
		var collect = GameObject.FindGameObjectsWithTag (Tags.Built);
		foreach (GameObject o in collect) {
			var ticker = o.GetComponent<Cube>();
			if (ticker != null){
				ticker.tick ();
				gold++;
				material++;
				resource--;
			}
		}
		if (resource < 1) {
			var down = GameObject.FindGameObjectsWithTag (Tags.Draggable);
			foreach (GameObject o in down) {
				o.renderer.material.color = Color.black;
				o.GetComponent<PressGesture>().enabled = false;
				o.GetComponent<PanGesture>().enabled = false;
			}
			foreach (GameObject o in collect) {
				o.renderer.material.color = Color.black;
				o.GetComponent<PressGesture>().enabled = false;
			}
			OnDisable();
		}
	}
}
