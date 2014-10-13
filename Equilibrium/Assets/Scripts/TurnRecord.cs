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

/*
 * used for recording what happened during the turn (um... duh)
 */ 
public class TurnRecord : MonoBehaviour {

	private int gold, materials, food, population, environment, foodGenerated, materialsGenerated;

	public TurnRecord(int gold, int materials, int food, int population, int environment, int foodGenerated, int materialsGenerated){
		this.gold = gold;
		this.materials = materials;
		this.food = food;
		this.population = population;
		this.environment = environment;
		this.foodGenerated = foodGenerated;
		this.materialsGenerated = materialsGenerated;
	}

	public int getGold(){
		return gold;
	}

	public int getMaterials(){
		return materials;
	}

	public int getFood(){
		return food;
	}

	public int getPopulation(){
		return population;
	}

	public int getEnvironment(){
		return environment;
	}

	public int getFoodGenerated(){
		return foodGenerated;
	}

	public int getMaterialsGenerated(){
		return materialsGenerated;
	}
}
