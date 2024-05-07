using UnityEngine;


	public class UIKillFeed : MonoBehaviour
	{
		public UIKillFeedItem Prefab;
		public float          ItemLifetime = 6f;
		public Sprite         ballSprite;

		public void ShowKill(string killer, string victim, Sprite ball)
		{
			var item = Instantiate(Prefab, transform);

			item.Winner.text = killer;
			item.Loser.text = victim;
		    item.Icon.sprite = ball;

			Destroy(item.gameObject, ItemLifetime);
		}

	}

