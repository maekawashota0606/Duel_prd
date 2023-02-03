using System;
using UnityEngine;
using UniRx;

public class Result : MonoBehaviour
{
    public ResultType enumResultType { get => _resultType.Value; private set => _resultType.Value = value; }
    public readonly ReactiveProperty<ResultType> _resultType = new();
    public IObservable<ResultType> resultTypeChanged => _resultType;

    public void GameEnd(ResultType type)
    {
        Debug.Log(type);
        enumResultType = type;
        switch(type)
        {
            case ResultType.Player1:
                break;
            case ResultType.Player2:
                break;
            case ResultType.Draw:
                break;
            default:
                break;
        }
    }
}