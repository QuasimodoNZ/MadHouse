using UnityEngine;
using System.Collections;

public class Power : BuildingTicker
{
	private int enviroDamage = 35;
	private int gold = 9;
	private double bonus = .25; 	//increase materials genearted for all buildings by 25%
	private int materialsBuild = 12;
	
	public override void tick (Clock c)
		{
				//c.eatFood (upkeep);
				//c.spendGold (enviormentDamage);
				c.ruinEnvironment (enviroDamage);
				c.generateGold (gold);
	}
	public override bool canCollideWith (GameObject other){
		
		if (other.tag.Equals (Tags.Built))
			return false;
		
		
		if (other.name != "Trees" && other.name != "Mountain" && other.name != "Water" && other.name != "Fish")
			return true;

		return false;
		}
}
