using System;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine.InputSystem;

public class GameDirector : MonoBehaviour
{
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

    async void Start()
    {
        _playerInputManager.onPlayerJoined += OnPlayerJoined;
        //
        await UniTask.WaitUntil(() => _playerInput[0] != null && _playerInput[1] != null);

        // �o�b�t�@�I�ȉ���
        _gameState.Value = GameState.waiting;

        // �X�e�[�g�Ď�
        gameStateChanged.Where(x => x == GameState.waiting).Subscribe(_ => _tick = OnWaiting);
        gameStateChanged.Where(x => x == GameState.counting).Subscribe(_ => _tick = OnCounting);
        gameStateChanged.Where(x => x == GameState.fighting).Subscribe(_ => 
        { 
            _tick = OnFighting;
            _spiner1.SetVelocity(_playerInput[0].GetInput().move);
            _spiner2.SetVelocity(_playerInput[1].GetInput().move);
        });
        gameStateChanged.Where(x => x == GameState.ended).Subscribe(_ => _tick = OnEnded);

        //
        _spiner1.SetUp();
        _spiner2.SetUp();
        _UIPresenter.SetUp(_spiner1, _spiner2);

        // �J�n�������ł�����J�E���g�J�n
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

    //
    private void Tick()
    {
        if(_tick != null)
            _tick(Time.deltaTime);
    }

    private void OnWaiting(float delta)
    {

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

        // TODO:�{�^�������Ă�Ԗ�f�V�O�i�����o��̂łł���Β���
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

        // TODO:�X�s�[�h�`�F�b�N
    }

    private void OnEnded(float delta)
    {

    }

    public void OnPlayerJoined(PlayerInput input)
    {
        _playerInput[input.playerIndex] = input.gameObject.GetComponent<Player>();
    }
}
