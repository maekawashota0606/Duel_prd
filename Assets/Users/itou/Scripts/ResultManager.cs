using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    /*
    [SerializeField]
    private GameObject _1Pwin;
    [SerializeField]
    private GameObject _2Pwin;
    [SerializeField]
    private GameObject _Draw;

    [SerializeField]
    private GameObject _P1Diamond;
    [SerializeField]
    private GameObject _P2Diamond;

    [SerializeField]
    int playerhp1;
    int playerhp2;


    // Start is called before the first frame update
    void Start()
    {
        _1Pwin.SetActive(false);
        _2Pwin.SetActive(false);
        _Draw.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerhp1 > playerhp2)
        {
            _1Pwin.SetActive(true);
            _2Pwin.SetActive(false);
            _Draw.SetActive(false);
        }
        else if(playerhp1 < playerhp2)
        {
            _1Pwin.SetActive(false);
            _2Pwin.SetActive(true);
            _Draw.SetActive(false);
        }
        else if(playerhp1 == playerhp2)
        {
            _1Pwin.SetActive(false);
            _2Pwin.SetActive(false);
            _Draw.SetActive(true);
        }
        if (_P1Diamond.GetComponent<P1sentaku>()._1saisen == true
            && _P2Diamond.GetComponent<P2sentaku>()._2saisen == true)
        {
            SceneManager.LoadScene("Result");
        }
        else if (_P1Diamond.GetComponent<P1sentaku>()._1kyarasen == true
            && _P2Diamond.GetComponent<P2sentaku>()._2kyarasen == true)
        {
            SceneManager.LoadScene("Result");
        }
        else if (_P1Diamond.GetComponent<P1sentaku>()._1title == true
            && _P2Diamond.GetComponent<P2sentaku>()._2title == true)
        {
            SceneManager.LoadScene("Result");
        }
    }
    */
}
