using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField] protected Projectile projectilePrefab;
	[SerializeField] protected Transform spawnPoint;
	[SerializeField] protected float shootForce = 10f;
	[SerializeField] protected float destroyDelay = 3f;
	

	protected virtual void Shoot()
	{
		Projectile projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
		Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
		projectileRigidbody.AddForce(spawnPoint.right * shootForce, ForceMode2D.Impulse);

		StartCoroutine(DestroyProjectileDelayed(projectile, destroyDelay));
	}

	private IEnumerator DestroyProjectileDelayed(Projectile projectile, float delay)
	{
		yield return new WaitForSeconds(delay);

		if (projectile != null)
			Destroy(projectile.gameObject);
	}
}