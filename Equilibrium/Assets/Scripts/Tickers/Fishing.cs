using UnityEngine;
using System.Collections;

public class Fishing : BuildingTicker
{
		private BuildingCosts buildings = new BuildingCosts();
	
	public override void tick (Clock c)
		{
				//c.eatFood (upkeep);
				//c.spendGold (enviormentDamage);
				c.ruinEnvironment (buildings.FishingDamage);
				c.generateGold (buildings.FishingGold);
				c.generateFood (buildings.FishingFood);
	}	

	public override bool canCollideWith (GameObject other){
		
		if (other.tag.Equals (Tags.Built))
			return false;
		
		
		if (other.name == "Fish")
			return true;
		
		return false;
		}
}
