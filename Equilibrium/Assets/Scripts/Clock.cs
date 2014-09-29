﻿using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;

public class Clock : MonoBehaviour
{

	private int resource;
	private int material;
	private int gold;
	private int food;

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
		void Update ()
		{
	
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
				Debug.LogWarning ("do I work?");
		}

		public int getGold ()
		{
				return gold;
		}

		public int getResources ()
		{
				return resource;
		}

		public int getMaterial ()
		{
				return material;
		}
		public int getFood ()
		{
				return food;
		}

	public void spendMaterial(int amount){
		material = material - amount;
		//text.text = Convert.ToString ("Gold: " + gold + "\nResources: " + resource + "\nMaterials: " + material);
		updateResourceHUDs ();
	}

	public void spendGold(int amount){
		gold -= amount;
		//text.text = Convert.ToString ("Gold: " + gold + "\nResources: " + resource + "\nMaterials: " + material);
		updateResourceHUDs ();
	}

	public void ruinEnvironment (int amount){
		resource = resource - amount;
		//text.text = Convert.ToString ("Gold: " + gold + "\nResources: " + resource + "\nMaterials: " + material);
		updateResourceHUDs ();
	}

	public void generateMaterials(int amount){
		material = material + amount;
		updateResourceHUDs ();
		}

	public void generateGold(int amount){
		gold = gold + amount;
		updateResourceHUDs ();
		}

	public void generateFood(int amount){
		food = food + amount;
		updateResourceHUDs ();
		}

	public void updateResourceHUDs()
	{
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag(Tags.HUD))
		{
			HUD component = obj.GetComponent<HUD>();
			component.updateResourceHUDs(gold, resource, material,food);
		}
	}

		public void eatFood (int amount)
		{
				food -= amount;
				updateResourceHUDs ();		
		//text.text = Convert.ToString ("Gold: " + gold + "\nResources: " + resource + "\nMaterials: " + material);
		}

		public void nextTurn ()
		{
				var collect = GameObject.FindGameObjectsWithTag (Tags.Built);
				foreach (GameObject o in collect) {
						BuildingTicker ticker = o.GetComponent<BuildingTicker> ();
						if (ticker != null)
								ticker.tick (this);
				}
				if (resource < 1) {
						var down = GameObject.FindGameObjectsWithTag (Tags.Draggable);
						foreach (GameObject o in down) {
								o.renderer.material.color = Color.black;
								o.GetComponent<PressGesture> ().enabled = false;
								o.GetComponent<PanGesture> ().enabled = false;
						}
						foreach (GameObject o in collect) {
								o.renderer.material.color = Color.black;
								o.GetComponent<PressGesture> ().enabled = false;
						}
						OnDisable ();
				}
		}
}
