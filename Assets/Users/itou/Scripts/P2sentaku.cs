using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
KeyCodeの部分などを今の設定に書き換えコメントアウトを解除
 */
public class P2sentaku : MonoBehaviour
{
    
    [SerializeField]
    private GameObject _sentakuP21;
    [SerializeField]
    private GameObject _sentakuP22;
    [SerializeField]
    private GameObject _sentakuP23;
    /*
    [SerializeField]
    int _sentakukekka2;
    public bool _2saisen = false;
    public bool _2kyarasen = false;
    public bool _2title = false;
    // Start is called before the first frame update
    void Start()
    {
        _sentakukekka2 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            if(_sentakukekka2 == 1)
            {
                _sentakuP21.SetActive(false);
                _sentakuP23.SetActive(true);
                _sentakukekka2 = 3;
            }
            else if (_sentakukekka2 == 2)
            {
                _sentakuP21.SetActive(true);
                _sentakuP22.SetActive(false);
                _sentakukekka2--;
            }
            else if (_sentakukekka2 == 3)
            {
                _sentakuP22.SetActive(true);
                _sentakuP23.SetActive(false);
                _sentakukekka2--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (_sentakukekka2 == 3)
            {
                _sentakuP21.SetActive(true);
                _sentakuP23.SetActive(false);
                _sentakukekka2 = 1;
            }
            else if (_sentakukekka2 == 2)
            {
                _sentakuP22.SetActive(false);
                _sentakuP23.SetActive(true);
                _sentakukekka2++;
            }
            else if (_sentakukekka2 == 1)
            {
                _sentakuP21.SetActive(false);
                _sentakuP22.SetActive(true);
                _sentakukekka2++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_sentakukekka2 == 1)
            {
                _2saisen = true;
            }
            else if (_sentakukekka2 == 2)
            {
                _2kyarasen = true;
            }
            else if (_sentakukekka2 == 3)
            {
                _2title = true;
            }
        }
    }*/
}
