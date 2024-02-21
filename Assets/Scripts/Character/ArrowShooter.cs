using UnityEngine;

public class ArrowShooter : Shooter
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
			Shoot();
	}
}