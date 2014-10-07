using UnityEngine;
using System.Collections;

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
