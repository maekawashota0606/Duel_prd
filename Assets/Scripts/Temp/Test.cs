using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _numberSprites = new Sprite[4];
    [SerializeField]
    SpriteRenderer _r;
    private void Start()
    {
        _r.sprite = _numberSprites[3];
    }
}
