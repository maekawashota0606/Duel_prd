using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Animation : MonoBehaviour
{
    [SerializeField] GameObject Slash_EF;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            Slash_EF.SetActive(false);
        }
    }
}
