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
        // XXXこの判定だと多段ヒットせず、出入りを繰り返すことで複数ヒットするため注意
        if(collision.gameObject.CompareTag(_tagParamAsset.spinerTag))
        {
            collision.gameObject.transform.parent.GetComponent<Spiner>().AddDamage(_spinerParamAsset.power);
        }
    }
}
