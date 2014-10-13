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

public class Farm : BuildingTicker
{
	private BuildingCosts buildings = new BuildingCosts();


	public override void tick (Clock c)
		{
				//c.eatFood (upkeep);
				//c.spendGold (enviormentDamage);
				c.ruinEnvironment (buildings.FarmDamage);
				c.generateGold (buildings.FarmGold);
				c.generateFood (buildings.FarmFood);
				c.generateMaterials (buildings.FarmMaterials);
		}
	public override bool canCollideWith (GameObject other){
		
		if (other.tag.Equals (Tags.Built))
			return false;
		
		
		if (other.name == "Farmland")
			return true;
		
		return false;
		}
}
