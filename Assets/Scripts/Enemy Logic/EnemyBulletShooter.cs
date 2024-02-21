using System.Collections;
using UnityEngine;

public class EnemyBulletShooter : Shooter
{
	[SerializeField] private float _shootInterval = 1f;

	private WaitForSeconds _waitInterval;

	private void Update() =>
		ShootRoutine();

	private void OnEnable()
	{
		_waitInterval = new WaitForSeconds(_shootInterval);
		StartCoroutine(ShootRoutine());
	}

	private IEnumerator ShootRoutine()
	{
		while (enabled)
		{
			yield return _waitInterval;
			Shoot();
		}
	}

	protected override void Shoot()
	{
		Projectile bullet = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
		Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
		bulletRigidbody.AddForce(Vector2.left * shootForce, ForceMode2D.Impulse);
	}
}