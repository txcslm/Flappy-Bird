using UnityEngine;
using UnityEngine.Serialization;

public class Projectile : MonoBehaviour
{
	[SerializeField] protected float speed = 10f;

	protected virtual void Update() =>
		MoveProjectile();

	protected virtual void MoveProjectile() =>
		transform.Translate(Vector2.right * speed * Time.deltaTime);

	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Enemy enemy))
			enemy.Die();

		Destroy(gameObject);
	}
}