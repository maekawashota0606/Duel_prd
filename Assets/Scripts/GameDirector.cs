using System;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine.InputSystem;

public class GameDirector : SingletonMonoBehaviour<GameDirector>
{
#if UNITY_EDITOR
    [SerializeField]
    private Player _onEditorPlayer1 = null;
    [SerializeField]
    private Player _onEditorPlayer2 = null;
#endif
    [SerializeField]
    private Spiner _spiner1 = null;
    [SerializeField]
    private Spiner _spiner2 = null;
    [SerializeField]
    UIPresenter _UIPresenter = null;
    [SerializeField]
    private PlayerInputManager _playerInputManager = null;
    //
    private Player[] _playerInput = new Player[2];
    private delegate void OnUpdate(float delta);
    private OnUpdate _tick = null;
    public GameState _enumGameState { get => _gameState.Value; private set => _gameState.Value = value; }
    public readonly ReactiveProperty<GameState> _gameState = new();
    public IObservable<GameState> gameStateChanged => _gameState;
    //
    private const float defSpinersPosX = -4; 
    private const float defSpinersPosY = -4; 
    async void Start()
    {
#if UNITY_EDITOR
        // キーボード1台ではマルチ扱いにならない？
        _playerInput[0] = Instantiate(_onEditorPlayer1).GetComponent<Player>();
        _playerInput[1] = Instantiate(_onEditorPlayer2).GetComponent<Player>();
#else
        _playerInputManager.onPlayerJoined += OnPlayerJoined;
#endif
        // プレイヤー2人の参加を待つ
        await UniTask.WaitUntil(() => _playerInput[0] != null && _playerInput[1] != null);

        // セットアップ
        _spiner1.SetUp();
        _spiner2.SetUp();
        _UIPresenter.SetUp(_spiner1, _spiner2);

        // ステート監視/関数登録
        gameStateChanged.Where(x => x == GameState.waiting).Subscribe(value => _tick = OnWaiting);
        gameStateChanged.Where(x => x == GameState.counting).Subscribe(async value =>
        {
            _tick = OnCounting;
            // カウントダウン開始
            CountDown cd = new CountDown();
            await cd.StartCountDown();
            _gameState.Value = GameState.fighting;
        });
        gameStateChanged.Where(x => x == GameState.fighting).Subscribe(value => 
        {
            Vector3 move1 = _playerInput[0].GetInput().move;
            Vector3 move2 = _playerInput[1].GetInput().move;
            if (move1.magnitude < 0.01f)
                move1 = MyMath.GetRandomVector2();
            if (move2.magnitude < 0.01f)
                move2 = MyMath.GetRandomVector2();

            // 発射
            _spiner1.SetVelocity(move1);
            _spiner2.SetVelocity(move2);
            _tick = OnFighting;
        });
        gameStateChanged.Where(x => x == GameState.ended).Subscribe(value => _tick = OnEnded);

        // バッファ的な何か
        _gameState.Value = GameState.waiting;
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
        if(_tick != null)
            _tick(Time.deltaTime);
    }

    private async void OnWaiting(float delta)
    {
        // とりあえず入力を待つ
        await UniTask.WaitUntil(() => _playerInput[0].GetInput().attack || _playerInput[1].GetInput().attack);
        // 開始準備ができたらカウント開始
        _gameState.Value = GameState.counting;
    }

    private void OnCounting(float delta)
    {
        _spiner1.inputedDir = _playerInput[0].GetInput().move;
        _spiner2.inputedDir = _playerInput[1].GetInput().move;
    }

    private void OnFighting(float delta)
    {
        _spiner1.inputedDir = _playerInput[0].GetInput().move;
        _spiner2.inputedDir = _playerInput[1].GetInput().move;

        // TODO:ボタン押してる間毎fシグナルが出るのでできれば直す
        // 1P
        if (_playerInput[0].GetInput().attack)
            _spiner1.Attack();
        if (_playerInput[0].GetInput().avoid)
            _spiner1.Avoid(_playerInput[0].GetInput().move);

        // 2P
        if (_playerInput[1].GetInput().attack)
            _spiner2.Attack();
        if (_playerInput[1].GetInput().avoid)
            _spiner2.Avoid(_playerInput[1].GetInput().move);
    }

    private void OnEnded(float delta)
    {

    }

    public void OnSpinerStopped()
    {
        if (_gameState.Value != GameState.fighting)
            return;

        Vector3 setPos1 = new Vector3(defSpinersPosX, defSpinersPosY);
        Vector3 setPos2 = setPos1 * -1;
        _spiner1.SetUpToNextRound(setPos1);
        _spiner2.SetUpToNextRound(setPos2);
        _gameState.Value = GameState.waiting;
    }

    public void OnSpinerDowned(Spiner spiner)
    {
        if (spiner == _spiner1)
            Debug.Log("1p");
        else
            Debug.Log("2p");

        _gameState.Value = GameState.ended;
    }

    // マルチ用
    public void OnPlayerJoined(PlayerInput input)
    {
        _playerInput[input.playerIndex] = input.gameObject.GetComponent<Player>();
    }
}
