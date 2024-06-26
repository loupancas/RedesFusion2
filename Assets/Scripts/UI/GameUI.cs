using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;


	public class GameUI : MonoBehaviour
	{
		[HideInInspector]
		public NetworkRunner  Runner;

		public GameObject     ScoreboardView;
		public GameObject     MenuView;
		public GameObject     DisconnectedView;

		public void OnRunnerShutdown(NetworkRunner runner, ShutdownReason reason)
		{
			

			ScoreboardView.SetActive(false);
			MenuView.gameObject.SetActive(false);

			DisconnectedView.SetActive(true);
		}

		public void GoToMenu()
		{
			if (Runner != null)
			{
				Runner.Shutdown();
			}

			SceneManager.LoadScene("Startup");
		}

		private void Awake()
		{
			MenuView.SetActive(false);
			DisconnectedView.SetActive(false);


			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		private void Update()
		{
			if (Application.isBatchMode == true)
				return;

			
			//Runner = .Runner;

			//var keyboard = Keyboard.current;
			//bool gameplayActive = Gameplay.State < EGameplayState.Finished;

			//ScoreboardView.SetActive(gameplayActive && keyboard != null && keyboard.tabKey.isPressed);

			//if (gameplayActive && keyboard != null && keyboard.escapeKey.wasPressedThisFrame)
			//{
			//	MenuView.SetActive(!MenuView.activeSelf);
			//}

			//GameplayView.gameObject.SetActive(gameplayActive);
			//GameOverView.gameObject.SetActive(gameplayActive == false);

			//var playerObject = Runner.GetPlayerObject(Runner.LocalPlayer);
			//if (playerObject != null)
			//{
			//	var player = playerObject.GetComponent<Player>();
			//	var playerData = Gameplay.PlayerData.Get(Runner.LocalPlayer);

			//	PlayerView.UpdatePlayer(player, playerData);
			//	PlayerView.gameObject.SetActive(gameplayActive);
			//}
			//else
			//{
			//	PlayerView.gameObject.SetActive(false);
			//}
		}
	}

