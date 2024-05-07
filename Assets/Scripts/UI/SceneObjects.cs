using Fusion;


public class SceneObjects : SimulationBehaviour
{
    private GameUI _gameUI;

    public GameUI GameUI
    {
        get
        {
            if (_gameUI == null && Runner != null && Runner.SceneManager != null && Runner.SceneManager.MainRunnerScene.IsValid())
            {
                //var gameUIs = Runner.SceneManager.MainRunnerScene.GetComponentsInChildren<GameUI>(true);
                //if (gameUIs.Length > 0)
                //{
                //    _gameUI = gameUIs[0];
                //}
            }

            return _gameUI;
        }
    }
}

