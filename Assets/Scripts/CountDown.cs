using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CountDown
{
    public async UniTask StartCountDown()
    {
        GameObject prefab = (GameObject)Resources.Load("StartQueueAnim");
        GameObject instance = GameObject.Instantiate(prefab);
        StartQueueAmimation startQueueAmim = instance.GetComponent<StartQueueAmimation>();

        startQueueAmim.SetUp();
        startQueueAmim.PlayAnimation(3);
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        startQueueAmim.PlayAnimation(2);
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        startQueueAmim.PlayAnimation(1);
        await UniTask.Delay(TimeSpan.FromSeconds(1));

        // UIはアニメーションにより透過したまま終わるので放置
    }
}
