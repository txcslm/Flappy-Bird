using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionHandler))]
public class Bird : MonoBehaviour
{
	private BirdMover _birdMover;
	private BirdCollisionHandler _handler;

	public event Action GameOver;
	
	public void Reset() =>
		_birdMover.Reset();

	private void Awake()
	{
		_handler = GetComponent<BirdCollisionHandler>();
		_birdMover = GetComponent<BirdMover>();
	}
	
	private void OnEnable() =>
		_handler.CollisionDetected += ProcessCollision;
	
	private void OnDisable() =>
		_handler.CollisionDetected -= ProcessCollision;
	
	private void ProcessCollision(IInteractable interactable)
	{
		if (interactable is Enemy or Ground or Bullet)
			GameOver?.Invoke();
	}
}