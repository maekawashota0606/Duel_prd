using UnityEngine;

public class StartQueueAmimation : MonoBehaviour
{
    private Animation _queueAnim = null;
    private SpriteRenderer _number = null;
    [SerializeField]
    private Sprite[] _numberSprites = new Sprite[4];

    public void SetUp()
    {
        _queueAnim = GetComponent<Animation>();
        _number = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void PlayAnimation(int queueNumber)
    {
        if (_numberSprites.Length <= queueNumber)
        {
            //Debug.LogError("");
            return;
        }

        _number.sprite = _numberSprites[queueNumber];
        _queueAnim.Stop();
        _queueAnim.Play();
    }
}
