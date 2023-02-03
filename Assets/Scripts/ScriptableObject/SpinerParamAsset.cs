using UnityEngine;

[CreateAssetMenu(fileName = "SpinerParamAsset", menuName = "ScriptableObjects/Create SpinerParamAsset")]
public class SpinerParamAsset : ScriptableObject
{
    public int maxHp;
    public int power;
    public int possibleAttackNum;
    public int possibleAvoidNum;
    public float speed;
    public float onHitWallDecelRatio;
    public float onHitSpinerDecelRatio;
    public float onDamagedDecelRatio;
    public float minSpeed;
}