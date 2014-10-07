using UnityEngine;
using System.Collections;
using System;

public class GameRecord : MonoBehaviour {

	private ArrayList turns = new ArrayList<TurnRecord>();

	public GameRecord(){

	}

	public void addTurn(TurnRecord t){
		turns.Add (t);
	}

	public int getTotalFood(){
		int food = 0;
		foreach(TurnRecord t in turns){
			food = t.getFoodGenerated();
		}
		return food;
	}

	public int getTotalMaterials(){
		int materials = 0;
		foreach(TurnRecord t in turns){
			materials = t.getMaterialsGenerated();
		}
		return materials;
	}

	public int getFinalPopulation(){
		int pop = 0;
		foreach (TurnRecord t in turns) {
			pop = t.getPopulation();
		}
		return pop;
	}

	public int getFinalEnvironment(){
		int environment = 0;
		foreach (TurnRecord t in turns) {
			environment = t.getEnvironment();
		}
		return environment;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
