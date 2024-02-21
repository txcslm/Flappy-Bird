using System;

public class ScoreHandler
{
	private int _value;
	private Game _game;
	
	public event Action<int> ValueChanged;
	
	public ScoreHandler(Game game)
	{
		_game = game;
		game.GameOver += Reset;
	}

	public void Add(int value)
	{
		_value += value;
		ValueChanged?.Invoke(_value);
	}

	private void Reset()
	{
		_value = 0;
		ValueChanged?.Invoke(_value);
	}
}