using System;
using UnityEngine;
using UniRx;

public class Spiner : MonoBehaviour
{
    [SerializeField]
    private SpinerParamAsset _spinerParamAsset = null;
    [SerializeField]
    private TagParamAsset _tagParamAsset = null;
    [SerializeField]
    private Attack _attack = null;
    [SerializeField]
    private Rigidbody2D _rb2D = null;


    // 外部(内部)で監視可能なパラメータ
    // いい変数名が思いつかない
    public int maxHP { get => _maxHP.Value; private set => _maxHP.Value = value; }
    private readonly ReactiveProperty<int> _maxHP = new();
    public IObservable<int> maxHPChanged => _maxHP;
    public int currentHP {get => _currentHP.Value; private set => _currentHP.Value = value; }
    private readonly ReactiveProperty<int> _currentHP = new();
    public IObservable<int> currentHPChanged => _currentHP;
    public Vector2 inputedDir { get => _inputedDir.Value; set => _inputedDir.Value = value; }
    private readonly ReactiveProperty<Vector2> _inputedDir = new();
    public IObservable<Vector2> inputedDirChanged => _inputedDir;
    public float currentVelocity { get => _currentVelocity.Value; private set => _currentVelocity.Value = value; }
    private readonly ReactiveProperty<float> _currentVelocity = new();
    public IObservable<float> currentVelocityChanged => _currentVelocity;
    //
    private int _attackedCount = 0;
    private int _avoidedCount = 0;

    public void SetUp()
    {
        _currentHP.Value = _spinerParamAsset.maxHp;
        _maxHP.Value = _spinerParamAsset.maxHp;

        currentHPChanged.Subscribe(value =>
        {
            if (value > maxHP)
                _currentHP.Value = maxHP;
            else if (value < 0)
                GameDirector.Instance.OnSpinerDowned(this);
        });

        currentVelocityChanged.Where(x => x < _spinerParamAsset.minSpeed).Subscribe(value =>
        {
            _rb2D.velocity = Vector3.zero;
            GameDirector.Instance.OnSpinerStopped();
        });
    }

    public void SetUpToNextRound()
    {
        // 体力は引継ぎ
        _rb2D.velocity = Vector3.zero;
        _attackedCount = 0;
        _avoidedCount = 0;
        _inputedDir.Value = Vector3.zero;
    }

    // TODO:tick無くせそう
    public void Tick()
    {
        _currentVelocity.Value = _rb2D.velocity.magnitude;
    }

    public void SetVelocity(Vector2 dir)
    {
        // 雑に倍率を設定
        _rb2D.velocity = dir * 50;
    }

    public void AddDamage(int damage)
    {
        _currentHP.Value -= damage;
    }

    public void Attack()
    {
        if (_attackedCount < _spinerParamAsset.possibleAttackNum)
        {
            float rot = MyMath.GetAim(Vector2.zero, inputedDir);
            _attack.transform.localRotation = Quaternion.Euler(Vector3.forward * rot);
            _attack.Fire();
            _attackedCount++;
        }
    }

    public void Avoid(Vector2 dir)
    {
        if (_avoidedCount < _spinerParamAsset.possibleAvoidNum)
        {
            SetVelocity(dir);
            _avoidedCount++;
        }
    }

    public void OnEnded(bool winner = false)
    {
        _inputedDir.Value = Vector3.zero;
    }

    private void HitWall()
    {
        _rb2D.velocity *= _spinerParamAsset.onHitWallDecelRatio;
    }

    private void HitSpiner()
    {
        _rb2D.velocity *= -1;
        _rb2D.velocity *= _spinerParamAsset.onHitSpinerDecelRatio;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_tagParamAsset.wallTag))
            HitWall();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // コマ同士はコリジョンさせず、ベクトルを反転させる
        if (collision.gameObject.CompareTag(_tagParamAsset.spinerTag))
            HitSpiner();
    }
}
