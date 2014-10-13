/*
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
using System;

/*
 * used for keeping track of all of the scores throughout the game
 */ 
public class GameRecord : MonoBehaviour {

	private ArrayList turns = new ArrayList();

	public GameRecord(){}

	public void addTurn(TurnRecord t){
		turns.Add (t);
	}

	public int getTotalFood(){
		int food = 15;
		foreach(TurnRecord t in turns){
			food += t.getFoodGenerated();
		}
		return food;
	}

	public int getTotalMaterials(){
		int materials = 50;
		foreach(TurnRecord t in turns){
			materials += t.getMaterialsGenerated();
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

	public int getFinalGold(){
		int gold = 0;
		foreach (TurnRecord t in turns) {
			gold = t.getGold();
		}
		return gold;
	}

	public int getNumTurns(){
		return turns.Count;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
