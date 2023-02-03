using UniRx;

public enum ResultType
{
    None,
    Player1,
    Player2,
    Draw,
}

[System.Serializable]
public class ResultTypeReactyveProperty : ReactiveProperty<ResultType>
{
    public ResultTypeReactyveProperty() { }
    public ResultTypeReactyveProperty(ResultType value) : base(value) { }   
}
