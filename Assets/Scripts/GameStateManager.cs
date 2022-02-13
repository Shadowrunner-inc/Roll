public class GameStateManager 
{
    // When Called if the instance is null spawn and assign a new instance.
    #region Singelton
    private static GameStateManager _instance;
    public static GameStateManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameStateManager();
            }
            return _instance;
        }
    }
    #endregion

    public GameState CurrentGameState { get; private set; }

    public delegate void GameStateChangHandler(GameState NewGameState);
    public event GameStateChangHandler OnGameStateChange;

    
    private GameStateManager() { }

    public void SetState(GameState newGameState) 
    {
        if (newGameState == CurrentGameState) return;

        CurrentGameState = newGameState;
        OnGameStateChange?.Invoke(newGameState);
    }
}
