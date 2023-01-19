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
    [SerializeField]
    GameObject _spiner1P = null;
    [SerializeField]
    GameObject _spiner2P = null;

    List<GameObject> spinerList = null;

    public void Fire()
    {
        _spinerAnimator.SetTrigger(_animTagParamAsset.attackTag);

        spinerList = new List<GameObject>() { _spiner1P, _spiner2P };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // XXX���̔��肾�Ƒ��i�q�b�g�����A�o������J��Ԃ����Ƃŕ����q�b�g���邽�ߒ���
        if(collision.gameObject.CompareTag(_tagParamAsset.spinerTag))
        {
            if (spinerList.Contains(collision.gameObject))
            {
                collision.gameObject.GetComponent<Spiner>().AddDamage(_spinerParamAsset.power);

                spinerList.Remove(collision.gameObject);
            }
        }
    }
}
