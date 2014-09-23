using UnityEngine;
using System.Collections;

public class Farm : BuildingTicker
{
	private upkeep = 20, enviormentDamage = 2, foodConsumed = -50;


		public void tick (Clock c)
		{
				c.eatFood (upkeep);
				c.spendGold (enviormentDamage);
				c.ruinEnvironment (enviormentDamage);
		}
}
