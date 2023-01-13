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
    private Rigidbody2D _rb2D = null;
    [SerializeField]
    private Attack _attack = null;

    // 外部で監視されるパラメータ
    // いい変数名が思いつかない
    public int maxHP {get => _maxHP.Value; private set => _maxHP.Value = value; }
    private readonly ReactiveProperty<int> _maxHP = new();
    public IObservable<int> maxHPChanged => _maxHP;
    public int currentHP {get => _currentHP.Value; private set => _currentHP.Value = value; }
    private readonly ReactiveProperty<int> _currentHP = new();
    public IObservable<int> currentHPChanged => _currentHP;
    public Vector2 inputedDir { get => _inputedDir.Value; set => _inputedDir.Value = value; }
    private readonly ReactiveProperty<Vector2> _inputedDir = new();
    public IObservable<Vector2> inputedDirChanged => _inputedDir;

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
            {
                // TODO:デス時処理
                Debug.Log("death");
            }
        });
    }

    // TODO:tick無くせそう
    public void Tick()
    {
        //Debug.Log(gameObject.name + ", " + _currentHP.Value);
        float rot = MyMath.GetAim(Vector2.zero, inputedDir);
        _attack.transform.localRotation = Quaternion.Euler(Vector3.forward * rot);
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

    private void HitWall()
    {
        _rb2D.velocity *= _spinerParamAsset.onHitWallDecelRatio;
    }

    private void HitSpiner()
    {
        _rb2D.velocity *= _spinerParamAsset.onHitSpinerDecelRatio;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_tagParamAsset.wallTag))
            HitWall();
        else if (collision.gameObject.CompareTag(_tagParamAsset.spinerTag))
            HitSpiner();
    }
}
