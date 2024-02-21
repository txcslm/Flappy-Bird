using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
	[SerializeField] private Arrow _projectilePrefab;
	[SerializeField] private Transform _spawnPoint;
	[SerializeField] private float _shootForce = 10f;
	[SerializeField] private float _destroyDelay = 3f;
	
	private void OnEnable() =>
		InputManager.OnShoot += Shoot;

	private void OnDisable() =>
		InputManager.OnShoot -= Shoot;

	private void Shoot()
	{
		Arrow arrow = Instantiate(_projectilePrefab, _spawnPoint.position, _spawnPoint.rotation);
		Rigidbody2D projectileRigidbody = arrow.GetComponent<Rigidbody2D>();
		projectileRigidbody.AddForce(_spawnPoint.right * _shootForce, ForceMode2D.Impulse);

		DestroyArrowDelayed(arrow, _destroyDelay);
	}

	private void DestroyArrowDelayed(Arrow arrow, float delay) =>
		Destroy(arrow.gameObject, delay);
}