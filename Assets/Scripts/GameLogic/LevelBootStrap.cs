using UnityEngine;

public class LevelBootStrap : MonoBehaviour
{
	[SerializeField] private ScoreView _scoreView;
	[SerializeField] private EnemyGenerator _enemyGenerator;
	[SerializeField] private ObjectPool _pool;
	[SerializeField] private Game _game;
	[SerializeField] private ObjectRemover _objectRemover;
	
	
	private ScoreHandler _scoreHandler;
	private EnemiesHandler _enemiesHandler;
	
	private void Awake()
	{
		_scoreHandler = new ScoreHandler(_game);
		_enemiesHandler = new EnemiesHandler(_scoreHandler);
		_scoreView.Initialize(_scoreHandler);
		_pool.Initialize(_enemiesHandler);
		_enemyGenerator.Initialize();
	}
}