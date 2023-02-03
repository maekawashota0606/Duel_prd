using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara : MonoBehaviour
{
    [SerializeField] GameObject _chara;

    private int move_count = 3;
    private int count = 0;
    private float wait_time = 1.0f;
    private float time = 0.0f;
    private float moveX = 0.0f;
    private bool damage = false;

    // Update is called once per frame
    void Update()
    {
        if(damage)
        {
            time += Time.deltaTime;
            if(time >= wait_time)
            {
                Vector3 pos = _chara.transform.position;
                pos.x += moveX;
                _chara.transform.position = pos;
                moveX *= -1;

                count++;
                if(count >= move_count)
                {
                    damage = false;
                    pos.x = 0;
                }
            }
        }
    }

    public void Start_Move()
    {
        damage = true;
        moveX = 10.0f;
        count = 0;
    }
}
