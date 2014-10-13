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

public class BuildingCosts : MonoBehaviour {

	public int City = 30;
	public int Factory = 40;
	public int Lumber = 10;
	public int Farm = 8;
	public int Fishing = 8;
	public int Mine = 10;
	public int Power = 10;
	public int School = 50;

	public int CityDamage = 20;
	public int FactoryDamage = 20;
	public int LumberDamage = 5;
	public int FarmDamage = 10;
	public int FishingDamage = 15;
	public int MineDamage = 10;
	public int PowerDamage = 35;
	public int SchoolDamage = -15;

	public int CityGold = 40;
	public int FactoryGold = 30;
	public int LumberGold = 7;
	public int FarmGold = 5;
	public int FishingGold = 10;
	public int MineGold = 25;
	public int PowerGold = 20;
	public int SchoolGold = 10;

	public int LumberMaterials = 8;
	public int MineMaterials = 16;
	public int FarmMaterials = 5;

	public double FactoryBonus = .25;
	public double PowerBonus = .18;
	public double SchoolBonus = .15;

	public int FarmFood = 20;
	public int FishingFood = 20;

}
