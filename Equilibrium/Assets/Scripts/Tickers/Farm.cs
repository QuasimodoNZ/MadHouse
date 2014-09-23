using UnityEngine;
using System.Collections;

public class Farm : BuildingTicker
{
	private int upkeep = 20, enviormentDamage = 2, foodConsumed = -50;


	public override void tick (Clock c)
		{
				c.eatFood (upkeep);
				c.spendGold (enviormentDamage);
				c.ruinEnvironment (enviormentDamage);
		}
	public override bool canCollideWith (GameObject other){
		
		if (other.tag.Equals (Tags.Built))
			return false;
		
		
		if (other.name == "Farmland")
			return true;
		
		return false;
		}
}
