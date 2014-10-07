﻿using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;

public class Clock : MonoBehaviour
{

	private int environment;
	private int material;
	private int gold;
	private int food = 15;
	private int population = 10;
	private int materialsThisTurn = 0;
	private int foodThisTurn = 0;
	private int factoryCount = 0;
	private int powerCount = 0;
	private int schoolCount = 0;
	private BuildingCosts buildings = new BuildingCosts();
	private bool menuOpen = false;
	private TimeSpan timePressed = new TimeSpan();
	public GameObject menuButtonsPrefab;
	private bool gameOver = false;
	private GameObject menuButtonsInstance;

	private double powerBonus, factoryBonus, schoolBonus;

	//public GUIText text;

	// Use this for initialization
	void Start () {
		environment = 1000;
		material = 50;
		gold = 0;
		powerBonus = buildings.PowerBonus;
		factoryBonus = buildings.FactoryBonus;
		schoolBonus = buildings.SchoolBonus;
		//text.text = Convert.ToString ("Gold: " + gold + "\nResources: " + resource + "\nMaterials: " + material);
		updateResourceHUDs ();
		updateVisualDamage ();
	}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		private void OnEnable ()
		{
				GetComponent<PressGesture> ().Pressed += pressedHandler;
				GetComponent<ReleaseGesture> ().Released += releasedHandler;
				//GetComponent<LongPressGesture> ().LongPressed += LongPressHandler;
		}
	
		private void OnDisable ()
		{
				GetComponent<PressGesture> ().Pressed -= pressedHandler;
				GetComponent<ReleaseGesture> ().Released -= releasedHandler;
				//GetComponent<LongPressGesture> ().LongPressed -= LongPressHandler;
		}

	private void releasedHandler (object sender, EventArgs e)
	{
		TimeSpan temp = DateTime.Now.TimeOfDay - timePressed;

		if (temp.TotalMilliseconds > 750 && !menuOpen) {
			menuOpen = true;

			menuButtonsInstance = Instantiate (menuButtonsPrefab) as GameObject;
			menuButtonsInstance.transform.position = gameObject.transform.position;
			menuButtonsInstance.name = "Clock Menu";
			menuButtonsInstance.transform.parent = gameObject.transform;
			//obj.GetComponent<ClockMenu>().setTarget(gameObject);
			//menu = obj;

			return;
		}
		if (menuOpen) {
			menuOpen = false;
			Destroy (menuButtonsInstance);
			menuButtonsInstance = null;
			return;
		}

		Debug.LogWarning ("Taking turn!");
		if (!gameOver) {
						nextTurn ();
						//text.text = Convert.ToString ("Gold: " + gold + "\nResources: " + resource + "\nMaterials: " + material);
						updateResourceHUDs ();
				}
	}

	private void LongPressHandler(object sender, EventArgs e)
	{
		menuOpen = true;
		Debug.Log ("long press!");
	}

		private void pressedHandler (object sender, EventArgs e)
		{
				Debug.LogWarning ("do I work?");
				timePressed = DateTime.Now.TimeOfDay;
		}

		public int getGold ()
		{
				return gold;
		}

		public int getResources ()
		{
				return environment;
		}

		public int getMaterial ()
		{
				return material;
		}

		public int getFood ()
		{
				return food;
		}

	public int getPopulation ()
	{
		return population;
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
		environment = environment - amount;
		if (environment > 1000)
						environment = 1000;
		//text.text = Convert.ToString ("Gold: " + gold + "\nResources: " + resource + "\nMaterials: " + material);
		updateResourceHUDs ();
	}

	public void generateMaterials(int amount){
		materialsThisTurn = materialsThisTurn + amount;
		}

	public void generateGold(int amount){
		gold = gold + amount;
		updateResourceHUDs ();
		}

	public void generateFood(int amount){
		foodThisTurn = foodThisTurn + amount;
		}

	public void generatePopulation(){
		population = population + gold/10;
		food = food - Convert.ToInt32(population * .75);
		updateResourceHUDs ();
	}

	public void factoryCounter(){
		factoryCount++;
	}

	public void powerCounter(){
		powerCount++;
	}

	public void schoolCounter(){
		schoolCount++;
	}

	private void updateResources(){
		Debug.Log (powerCount);
		material = material + materialsThisTurn + Convert.ToInt32(materialsThisTurn * (factoryCount * factoryBonus) + materialsThisTurn * (powerCount * powerBonus));
		food = food + foodThisTurn + Convert.ToInt32(foodThisTurn * (schoolCount * schoolBonus));
		factoryCount = 0;
		powerCount = 0;
		schoolCount = 0;

		updateResourceHUDs ();
	}

	public void updateResourceHUDs()
	{
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag(Tags.HUD))
		{
			HUD component = obj.GetComponent<HUD>();
			component.updateResourceHUDs(gold, environment, material,food,population);
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

			generatePopulation ();
			updateResources ();
			materialsThisTurn = 0;
			foodThisTurn = 0;

				if (environment < 1 || food < 0) {
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
					gameOver = true;
						//OnDisable ();
				}
		}

	public void updateVisualDamage(){

	}
}
