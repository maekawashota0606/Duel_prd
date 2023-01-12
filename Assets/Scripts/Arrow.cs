using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private Transform _arrowApex = null;
    private const float _MAX_SCALE = 1.5f;
    private const float _AREA_WIDTH = 10f;
    private const float _AREA_HEIGHT = 10f;
    private Vector3 _scale = Vector3.one;

    public void Stretch(Vector3 spinerPos, Vector3 dir)
    {
        transform.position = spinerPos;
        // スティックの押し込みに合わせて矢印を大きく
        _scale.x = _MAX_SCALE * dir.magnitude;
        transform.localScale = _scale;

        // スティックの倒した方向に矢印を回転
        // ※InputSystemで入力方向を反転
        float rot = MyMath.GetAim(transform.position, transform.position + dir);
        transform.localRotation = Quaternion.Euler(Vector3.forward * rot);


        // 壁からはみ出た分だけひっこめる
        Vector3 diff = _arrowApex.position - MyMath.ClampPos(_arrowApex.position, _AREA_WIDTH, _AREA_HEIGHT);
        transform.position -= dir * diff.magnitude;
    }
}
