using UnityEngine;

public class ArrowHandler : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Enemy enemy))
			enemy.Die();

		Destroy(gameObject);
	}
}