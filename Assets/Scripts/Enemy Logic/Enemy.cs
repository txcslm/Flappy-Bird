using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable
{
	public event Action<Enemy> Died;
	public void Die()
	{
		Died?.Invoke(this);
		Destroy(gameObject);
	}
}