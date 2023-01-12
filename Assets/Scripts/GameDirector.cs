using System;
using UnityEngine;
using UniRx;

public class GameDirector : MonoBehaviour
{
    [SerializeField]
    private Player1 _player1 = null;
    [SerializeField]
    private Player2 _player2 = null;
    [SerializeField]
    private Spiner _spiner1 = null;
    [SerializeField]
    private Spiner _spiner2 = null;
    [SerializeField]
    UIPresenter _UIPresenter = null;
    //
    private delegate void OnUpdate(float delta);
    private OnUpdate _tick = null;
    public GameState _enumGameState { get => _gameState.Value; private set => _gameState.Value = value; }
    public readonly ReactiveProperty<GameState> _gameState = new();
    public IObservable<GameState> gameStateChanged => _gameState;

    async void Start()
    {
        // バッファ的な何か
        _gameState.Value = GameState.waiting;

        // ステート監視
        gameStateChanged.Where(x => x == GameState.waiting).Subscribe(_ => _tick = OnWaiting);
        gameStateChanged.Where(x => x == GameState.counting).Subscribe(_ => _tick = OnCounting);
        gameStateChanged.Where(x => x == GameState.fighting).Subscribe(_ => 
        { 
            _tick = OnFighting;
            _spiner1.SetVelocity(_player1.GetInput().move);
            //_spiner2.SetVelocity(_player2.GetInput().move);
        });
        gameStateChanged.Where(x => x == GameState.ended).Subscribe(_ => _tick = OnEnded);

        //
        _spiner1.SetUp();
        _spiner2.SetUp();
        _UIPresenter.SetUp(_spiner1, _spiner2);

        // 開始準備ができたらカウント開始
        _gameState.Value = GameState.counting;

        //
        CountDown cd = new CountDown();
        await cd.StartCountDown();
        _gameState.Value = GameState.fighting;
    }

    private void Update()
    {
        _spiner1.Tick();
        _spiner2.Tick();
        _UIPresenter.Tick();
        Tick();
    }

    private void Tick()
    {
        _tick(Time.deltaTime);
    }

    private void OnWaiting(float delta)
    {

    }

    private void OnCounting(float delta)
    {
        _spiner1.inputedDir = _player1.GetInput().move;
        //_spiner2.inputedDir = _player2.GetInput().move;
    }

    private void OnFighting(float delta)
    {
        _spiner1.inputedDir = _player1.GetInput().move;
        _spiner2.inputedDir = _player2.GetInput().move;

        // TODO:ボタン押してる間毎fシグナルが出るので直す
        // 1P
        if (_player1.GetInput().attack)
            _spiner1.Attack();
        if (_player1.GetInput().avoid)
            _spiner1.Avoid(_player1.GetInput().move);

        // 2P


        // TODO:スピードチェック
    }

    private void OnEnded(float delta)
    {

    }
}
