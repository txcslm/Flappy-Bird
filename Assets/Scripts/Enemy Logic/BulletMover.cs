using UnityEngine;

public class BulletMover : Projectile
{
	protected override void MoveProjectile() =>
		transform.Translate(Vector2.left * speed * Time.deltaTime);
}