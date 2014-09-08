using UnityEngine;
using System.Collections;

public class BuildingTicker : MonoBehaviour
{
	public virtual void tick(Clock clock)
	{
		Debug.LogWarning ("Taking turn!");
	}
	
}
