using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	[SerializeField] private Transform _container;
	[SerializeField] private Enemy _prefab;

	private Queue<Enemy> _pool = new Queue<Enemy>();
	private EnemiesHandler _enemiesHandler;
	

	public IEnumerable<Enemy> PooledObjects => _pool;

	public void Initialize(EnemiesHandler enemiesHandler) =>
		_enemiesHandler = enemiesHandler;

	public Enemy GetObject()
	{
		if (_pool.Count == 0)
		{
			Enemy enemy = Instantiate(_prefab, _container, true);

			_enemiesHandler.Add(enemy);

			return enemy;
		}

		return _pool.Dequeue();
	}

	public void PutObject(Enemy enemy)
	{
		_pool.Enqueue(enemy);
		enemy.gameObject.SetActive(false);
	}

	public void Reset() =>
		_pool.Clear();
}