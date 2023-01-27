using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 キーコードなどを今の設定に書き換えコメントアウトを解除
 */
public class P1sentaku : MonoBehaviour
{
    /*
    [SerializeField]
    int _sentakukekka1;

    public bool _1saisen = false;
    public bool _1kyarasen = false;
    public bool _1title = false;
    Vector2 _P1pos;
    // Start is called before the first frame update
    void Start()
    {
        _P1pos = this.transform.position;
        _sentakukekka1 = 1;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(_sentakukekka1 == 1)
            {
                _sentakukekka1 = 3;
                this.transform.position = new Vector2(-7.6f, -4);
                _P1pos = this.transform.position;
            }
            else if (_sentakukekka1 != 1)
            {
                _sentakukekka1--;
                _P1pos.y += 0.6f;
                this.transform.position = _P1pos;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (_sentakukekka1 == 3)
            {
                _sentakukekka1 = 1;
                this.transform.position = new Vector2(-7.6f, -2.8f);
                _P1pos = this.transform.position;
            }
            else if (_sentakukekka1 != 3)
            {
                _sentakukekka1++;
                _P1pos.y -= 0.6f;
                this.transform.position = _P1pos;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_sentakukekka1 == 1)
            {
                _1saisen = true;
            }
            else if (_sentakukekka1 == 2)
            {
                _1kyarasen = true;
            }
            else if (_sentakukekka1 == 3)
            {
                _1title = true;
            }
        }
    }*/
}
