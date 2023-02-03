using UnityEngine;
using System.Collections.Generic;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private TagParamAsset _tagParamAsset = null;
    [SerializeField]
    private AnimatorTagParamAsset _animTagParamAsset = null;
    [SerializeField]
    private SpinerParamAsset _spinerParamAsset = null;
    [SerializeField]
    private Animator _spinerAnimator = null;
    //
    private List<Spiner> _hitedSpiners = new List<Spiner>(10);

    public void Fire()
    {
        _hitedSpiners.Clear();
        _spinerAnimator.SetTrigger(_animTagParamAsset.attackTag);

        spinerList = new List<GameObject>() { _spiner1P, _spiner2P };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(_tagParamAsset.spinerTag))
        {
            Spiner spiner = collision.gameObject.transform.parent.GetComponent<Spiner>();

            // ‘½’iƒqƒbƒg–hŽ~
            if (!_hitedSpiners.Contains(spiner))
            {
                spiner.AddDamage(_spinerParamAsset.power);
                _hitedSpiners.Add(spiner);
            }
        }
    }
}
