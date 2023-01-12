using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UIPresenter : MonoBehaviour
{
    // UI
    [SerializeField]
    private Image _lifeGauge1P = null;
    [SerializeField]
    private Image _lifeGauge2P = null;
    [SerializeField]
    private Arrow _arrow1P = null;
    //
    private event System.Action _drawUI;

    public void SetUp(Spiner spiner1, Spiner spiner2)
    {
        // 監視しているものの、結局複数の値が必要
        // カプセル化できず、キレイではない

        // 1P
        spiner1.currentHPChanged.Subscribe(value =>
        {
            _lifeGauge1P.fillAmount = (float)spiner1.currentHP / spiner1.maxHP;
        });

        spiner1.maxHPChanged.Subscribe(value =>
        {
            _lifeGauge1P.fillAmount = (float)spiner1.currentHP / spiner1.maxHP;
        });

        // 2P
        spiner2.currentHPChanged.Subscribe(value =>
        {
            _lifeGauge2P.fillAmount = (float)spiner2.currentHP / spiner2.maxHP;
        });

        spiner2.maxHPChanged.Subscribe(value =>
        {
            _lifeGauge2P.fillAmount = (float)spiner2.currentHP / spiner2.maxHP;
        });

        // 雑に毎フレーム回す
        _drawUI += () =>
        {
            // 1P
            _arrow1P.Stretch(spiner1.gameObject.transform.position, spiner1.inputedDir);

            // 2P
        };
    }

    public void Tick()
    {
        _drawUI();
    }
}