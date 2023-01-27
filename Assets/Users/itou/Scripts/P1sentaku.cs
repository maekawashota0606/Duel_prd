using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
KeyCodeの部分などを今の設定に書き換えコメントアウトを解除
 */
public class P1sentaku : MonoBehaviour
{
    [SerializeField]
    private GameObject _sentakuP11;
    [SerializeField]
    private GameObject _sentakuP12;
    [SerializeField]
    private GameObject _sentakuP13;
    /*
   [SerializeField]
   int _sentakukekka1;
   public bool _1saisen = false;
   public bool _1kyarasen = false;
   public bool _1title = false;
   // Start is called before the first frame update
   void Start()
   {
       _sentakukekka1 = 1;
   }

   // Update is called once per frame
   void Update()
   {
       /*
       if (Input.GetKeyDown(KeyCode.JoystickButton3))
       {
           if(_sentakukekka1 == 1)
           {
               _sentakuP11.SetActive(false);
               _sentakuP13.SetActive(true);
               _sentakukekka1 = 3;
           }
           else if (_sentakukekka1 == 2)
           {
               _sentakuP11.SetActive(true);
               _sentakuP12.SetActive(false);
               _sentakukekka1--;
           }
           else if (_sentakukekka1 == 3)
           {
               _sentakuP12.SetActive(true);
               _sentakuP13.SetActive(false);
               _sentakukekka1--;
           }
       }
       else if (Input.GetKeyDown(KeyCode.JoystickButton0))
       {
           if (_sentakukekka1 == 3)
           {
               _sentakuP11.SetActive(true);
               _sentakuP13.SetActive(false);
               _sentakukekka1 = 1;
           }
           else if (_sentakukekka1 == 2)
           {
               _sentakuP12.SetActive(false);
               _sentakuP13.SetActive(true);
               _sentakukekka1++;
           }
           else if (_sentakukekka1 == 1)
           {
               _sentakuP11.SetActive(false);
               _sentakuP12.SetActive(true);
               _sentakukekka1++;
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
