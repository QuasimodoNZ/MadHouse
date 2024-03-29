﻿/*
Equilibirium, a game simulator for balancing economic progress and environmental collapse.
Copyright (C) 2014, Mad House Studios.
		
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
		
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
			
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;


/**
 * The main powerhouse during the game. Used to update the turn count and calls 
 * all necessary building tickers on all buildings that have been placed.
 * Also maintains scores during the game.
 */ 
public class Clock : MonoBehaviour
{
	private int environment;
	private int material;
	private int gold;
	private int currentTurn = 1;
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
	private GameRecord game = new GameRecord();
	public GameObject gameOverScreen;

	private double powerBonus, factoryBonus, schoolBonus;

	// Use this for initialization
	void Start () {
		//Game starting point
		environment = 1000;
		material = 50;
		gold = 0;
		powerBonus = buildings.PowerBonus;
		factoryBonus = buildings.FactoryBonus;
		schoolBonus = buildings.SchoolBonus;
		//text.text = Convert.ToString ("Gold: " + gold + "\nResources: " + resource + "\nMaterials: " + material);
		updateResourceHUDs ();
	}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		/*
		 * allows touch handling for the clock
		 */ 
		private void OnEnable ()
		{
				GetComponent<PressGesture> ().Pressed += pressedHandler;
				GetComponent<ReleaseGesture> ().Released += releasedHandler;
				//GetComponent<LongPressGesture> ().LongPressed += LongPressHandler;
		}

		/*
		 * removes touch handling for the clock
		 */ 
		private void OnDisable ()
		{
				GetComponent<PressGesture> ().Pressed -= pressedHandler;
				GetComponent<ReleaseGesture> ().Released -= releasedHandler;
				//GetComponent<LongPressGesture> ().LongPressed -= LongPressHandler;
		}

	/*
	 * called when touch event ends on the clock face
	 */ 
	private void releasedHandler (object sender, EventArgs e)
	{
		TimeSpan temp = DateTime.Now.TimeOfDay - timePressed;

		//check to see if they held it for a while, if so open menu
		if (temp.TotalMilliseconds > 750 && !menuOpen) {
			menuOpen = true;

			menuButtonsInstance = Instantiate (menuButtonsPrefab) as GameObject;
			menuButtonsInstance.transform.position = gameObject.transform.position;
			menuButtonsInstance.name = "Clock Menu";
			menuButtonsInstance.transform.parent = gameObject.transform;
			return;
		}
		//destroy menu if open
		if (menuOpen) {
			menuOpen = false;
			Destroy (menuButtonsInstance);
			menuButtonsInstance = null;
			return;
		}

		Debug.LogWarning ("Taking turn!");
		if (!gameOver) {
						
						nextTurn ();
						updateResourceHUDs ();
				}
	}

	/*
	 * starts the timer for long press
	 */ 
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
		updateResourceHUDs ();
	}

	public void spendGold(int amount){
		gold -= amount;
		updateResourceHUDs ();
	}

	public void ruinEnvironment (int amount){
		environment = environment - amount;
		//cap the environment at 1000 (100%)
		if (environment > 1000)
						environment = 1000;
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

	public void eatFood (int amount)
	{
		food -= amount;
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

	/*
	 * calculate all materials and food generated that turn and add it to current stockpile
	 */ 
	private void updateResources(){
		material = material + materialsThisTurn + Convert.ToInt32(materialsThisTurn * (factoryCount * factoryBonus) + materialsThisTurn * (powerCount * powerBonus));
		food = food + foodThisTurn + Convert.ToInt32(foodThisTurn * (schoolCount * schoolBonus));
		TurnRecord t = new TurnRecord (gold, material, food, population, environment, foodThisTurn, materialsThisTurn);
		game.addTurn (t);
		factoryCount = 0;
		powerCount = 0;
		schoolCount = 0;

		updateResourceHUDs ();
	}

	/*
	 * update all the player HUDs with new values.
	 */ 
	public void updateResourceHUDs()
	{
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag(Tags.HUD))
		{
			HUD component = obj.GetComponent<HUD>();
			component.updateResourceHUDs(gold, environment, material,food,population);
		}
	}

	/*
	 * move on to the next turn
	 */ 
		public void nextTurn ()
		{
		FadingPopup.SpawnPopup ("" + currentTurn++, gameObject.transform.position.x, gameObject.transform.position.y, Color.black);
				var collect = GameObject.FindGameObjectsWithTag (Tags.Built);
				
				//call all the building tickers
				foreach (GameObject o in collect) {
						BuildingTicker ticker = o.GetComponent<BuildingTicker> ();
						if (ticker != null)
								ticker.tick (this);
				}

			//update values and display
			generatePopulation ();
			updateResources ();
			materialsThisTurn = 0;
			foodThisTurn = 0;

				//have you lost yet?
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
					//lost, bring up stats screen
					gameOver = true;
					GameObject endScreen = GameObject.Instantiate(gameOverScreen) as GameObject;
					string deathMessage = "";
					if(food < 0)deathMessage = "Your people were hungry! They left.";
					else deathMessage = "You destroyed the environment and everyone left!";
							endScreen.GetComponent<GameOver>().setText(deathMessage + "\nYou survived: " +game.getNumTurns() + " turns" + "\n\nTotals:\nGold: " + game.getFinalGold() + ", Materials: " + game.getTotalMaterials() + ", Food: " + game.getTotalFood()
					                                           + "\n\nEnd Game:\nPopulation: " + game.getFinalPopulation() + ", Environment: " + game.getFinalEnvironment()/10 + "%, Food: " + food + "\n");
				}
		}
}
