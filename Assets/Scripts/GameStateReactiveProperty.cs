using UniRx;

public enum GameState
{
    none = -1,
    waiting,
    counting,
    fighting,
    ended,
}

[System.Serializable]
public class GameStateReactiveProperty : ReactiveProperty<GameState>
{
    public GameStateReactiveProperty() { }
    public GameStateReactiveProperty(GameState value) : base(value) {}
}
