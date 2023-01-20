using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _1Pwin;
    [SerializeField]
    private GameObject _2Pwin;
    [SerializeField]
    private GameObject _Draw;

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
        if (playerhp1 >= playerhp2)
        {
            _1Pwin.SetActive(true);
        }
        else if(playerhp1 <= playerhp2)
        {
            _2Pwin.SetActive(true);
        }
        else if(playerhp1 == playerhp2)
        {
            _Draw.SetActive(true);
        }
        else
        {
            _1Pwin.SetActive(false);
            _2Pwin.SetActive(false);
            _Draw.SetActive(false);
        }
    }

    public void bo()
    {
        SceneManager.LoadScene("Result");
    }
}
