using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_EnemyCollisionFix : MonoBehaviour
{
	void Start()
	{
		//Ignoring collisions with Player, Weapons and other Enemies
		//This works for enemies that must hit the player, but still touch floors etc.
		Physics2D.IgnoreLayerCollision(7, 6, true);
		Physics2D.IgnoreLayerCollision(7, 7, true);
		Physics2D.IgnoreLayerCollision(7, 8, true);
	}
}
