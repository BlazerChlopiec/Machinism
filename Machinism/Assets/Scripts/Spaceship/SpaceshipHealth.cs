using System;
using UnityEngine;

public class SpaceshipHealth : MonoBehaviour
{
	static SpriteFlashEffect spriteFlash;

	public static int health;
	public static float maxHealth = 3; // has to be float to be upgraded in the shop

	public static Action OnDeath;
	public static Action OnRefil;


	private void Start() => spriteFlash = GetComponentInChildren<SpriteFlashEffect>();

	public static void TakeDamage(int amount)
	{
		if (Timers.IsUp("SpaceshipInvFrames"))
		{
			health -= amount;
			spriteFlash.Flash();

			if (health <= 0)
			{
				Kill();
			}
		}
	}

	public static void RefillHealth()
	{
		health = (int)maxHealth;
		if (OnRefil != null) OnRefil();
	}

	public static void Kill()
	{
		if (Timers.IsUp("SpaceshipInvFrames"))
		{
			health = 0;
			AudioManager.instance.Play("PlayerDeath");
			if (OnDeath != null) OnDeath();
		}
	}
}
