using Fusion;
using UnityEngine;


	public class Health : NetworkBehaviour
	{
		public float MaxHealth = 100f;
		

		public bool IsAlive => CurrentHealth > 0f;
	

		[Networked]
		public float CurrentHealth { get; private set; }

		[Networked]
		private int _hitCount { get; set; }
		[Networked]
		private Vector3 _lastHitPosition { get; set; }
		[Networked]
		private Vector3 _lastHitDirection { get; set; }
	

		private int _visibleHitCount;
		private SceneObjects _sceneObjects;

		public bool ApplyDamage(PlayerRef instigator, float damage, Vector3 position, Vector3 direction, Ball ball)
		{
			if (CurrentHealth <= 0f)
				return false;

			CurrentHealth -= damage;

			if (CurrentHealth <= 0f)
			{
				CurrentHealth = 0f;

				//_sceneObjects.Gameplay.PlayerKilled(instigator, Object.InputAuthority, weaponType, isCritical);
			}

			
			_lastHitPosition = position - transform.position;
			_lastHitDirection = -direction;

			_hitCount++;

			return true;
		}	
		

		public override void Spawned()
		{
			_sceneObjects = Runner.GetSingleton<SceneObjects>();

			if (HasStateAuthority)
			{
				CurrentHealth = MaxHealth;

			}

			_visibleHitCount = _hitCount;
		}

	}

