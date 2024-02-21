using System.Collections.Generic;

public class EnemiesHandler
{
	private readonly ScoreHandler _scoreHandler;
	private List<Enemy> _enemies = new List<Enemy>();

	public EnemiesHandler(ScoreHandler scoreHandler) =>
		_scoreHandler = scoreHandler;

	public void Add(Enemy enemy)
	{
		_enemies.Add(enemy);
		enemy.Died += OnDied;
	}

	private void OnDied(Enemy enemy)
	{
		enemy.Died -= OnDied;
		_enemies.Remove(enemy);
		_scoreHandler.Add(1);
	}
}