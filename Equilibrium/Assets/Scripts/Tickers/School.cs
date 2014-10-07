﻿using UnityEngine;
using System.Collections;

public class School : BuildingTicker
{
		private BuildingCosts buildings = new BuildingCosts();
	
	public override void tick (Clock c)
		{
				//c.eatFood (upkeep);
				//c.spendGold (enviormentDamage);
				c.ruinEnvironment (buildings.SchoolDamage);
				c.schoolCounter ();
				c.generateGold (buildings.SchoolGold);
		}

	
	public override bool canCollideWith (GameObject other){
		
		if (other.tag.Equals (Tags.Built))
			return false;
		
		
		if (other.name == "Grass")
			return true;

		return false;
	}
}
