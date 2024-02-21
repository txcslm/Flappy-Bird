using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public static event Action OnMovement;
	public static event Action OnShoot;

	private void Update()
	{
		HandleInput();
	}

	private void HandleInput()
	{
		HandleMovementInput();
		HandleShootInput();
	}

	private void HandleMovementInput()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			OnMovement?.Invoke();
		}
	}

	private void HandleShootInput()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			OnShoot?.Invoke();
		}
	}
}