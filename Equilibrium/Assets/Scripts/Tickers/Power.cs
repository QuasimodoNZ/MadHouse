using UnityEngine;
using System.Collections;

public class Power : BuildingTicker
{
		private int upkeep, enviormentDamage, foodConsumed;
	
	public override void tick (Clock c)
		{
				c.eatFood (upkeep);
				c.spendGold (enviormentDamage);
				c.ruinEnvironment (enviormentDamage);
	}
	public override bool canCollideWith (GameObject other){

			if (other.tag.Equals (Tags.Built))
				return false;
		return true;
		}
}
