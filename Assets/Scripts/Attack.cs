using UnityEngine;

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

    public void Fire()
    {
        _spinerAnimator.SetTrigger(_animTagParamAsset.attackTag);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // XXX���̔��肾�Ƒ��i�q�b�g�����A�o������J��Ԃ����Ƃŕ����q�b�g���邽�ߒ���
        if(collision.gameObject.CompareTag(_tagParamAsset.spinerTag))
        {
            collision.gameObject.GetComponent<Spiner>().AddDamage(_spinerParamAsset.power);
        }
    }
}
