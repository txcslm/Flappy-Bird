using System.Collections;
using UnityEngine;

public class EnemyBulletShooter : MonoBehaviour
{
	[SerializeField] private Bullet _projectilePrefab;
	[SerializeField] private Transform _spawnPoint;
	[SerializeField] private float _shootInterval = 1f;
	[SerializeField] private float _shootForce = 10f;
	[SerializeField] private float _destroyDelay = 3f;

	private WaitForSeconds _waitInterval;
	
	private void OnEnable()
	{
		_waitInterval = new WaitForSeconds(_shootInterval);
		StartCoroutine(ShootRoutine());
		Shoot();
	}

	private void Update() =>
		ShootRoutine();
	
	private IEnumerator ShootRoutine()
	{
		while (enabled)
		{
			yield return _waitInterval;
			Shoot();
		}
	}

	private void Shoot()
	{
		Bullet bullet = Instantiate(_projectilePrefab, _spawnPoint.position, _spawnPoint.rotation);
		Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
		bulletRigidbody.AddForce(Vector2.left * _shootForce, ForceMode2D.Impulse);
		
		DestroyBulletDelayed(bullet, _destroyDelay);
		
	}
	
	private void DestroyBulletDelayed(Bullet bullet, float delay) =>
		Destroy(bullet.gameObject, delay);
}