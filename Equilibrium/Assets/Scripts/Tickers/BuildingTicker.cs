using UnityEngine;
using System.Collections;

public class BuildingTicker : MonoBehaviour
{		
		public void tick (Clock c)
		{
				c.eatFood (upkeep);
				c.spendGold (enviormentDamage);
				c.ruinEnvironment (enviormentDamage);
		}
}
