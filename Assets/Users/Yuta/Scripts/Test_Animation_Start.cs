using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Animation_Start : MonoBehaviour
{
    [SerializeField] GameObject Slash_EF;

    private float Wait_time = 0f;

    void Update()
    {
        if (Slash_EF.activeSelf == false)
        {
            Wait_time += Time.deltaTime;
        }

        if(Wait_time >= 3f)
        {
            Slash_EF.SetActive(true);
            Wait_time = 0f;
        }
    }
}
