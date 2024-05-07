using TMPro;
using UnityEngine;
using UnityEngine.UI;


	public class UIHealth : MonoBehaviour
	{
		public TextMeshProUGUI Value;
		public Image           Progress;
		public GameObject      DeathEffect;
		public TextMeshProUGUI HealValue;

		private int _lastHealth = -1;

		public void UpdateHealth(Health health)
		{

			int currentHealth = Mathf.CeilToInt(health.CurrentHealth);

			if (currentHealth == _lastHealth)
				return;

			Value.text = currentHealth.ToString();

			float progress = health.CurrentHealth / health.MaxHealth;
			Progress.fillAmount = progress;

			

			DeathEffect.SetActive(health.IsAlive == false);

			_lastHealth = currentHealth;
		}

		public void ShowHeal(float value)
		{
			HealValue.text = $"+{Mathf.RoundToInt(value)} HP";

			// Restart the animation.
			HealValue.gameObject.SetActive(false);
			HealValue.gameObject.SetActive(true);
		}

		private void Awake()
		{
			HealValue.gameObject.SetActive(false);
		}

	}

