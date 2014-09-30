using UnityEngine;
using System.Collections;

public class Power : BuildingTicker
{
	private BuildingCosts buildings = new BuildingCosts();
	
	public override void tick (Clock c)
		{
				//c.eatFood (upkeep);
				//c.spendGold (enviormentDamage);
				c.ruinEnvironment (buildings.PowerDamage);
				c.generateGold (buildings.PowerGold);
				c.powerCounter ();
	}
	public override bool canCollideWith (GameObject other){
		
		if (other.tag.Equals (Tags.Built))
			return false;
		
		
		if (other.name != "Trees" && other.name != "Mountain" && other.name != "Water" && other.name != "Fish")
			return true;

		return false;
		}
}
