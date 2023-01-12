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
        // �X�e�B�b�N�̉������݂ɍ��킹�Ė���傫��
        _scale.x = _MAX_SCALE * dir.magnitude;
        transform.localScale = _scale;

        // �X�e�B�b�N�̓|���������ɖ�����]
        // ��InputSystem�œ��͕����𔽓]
        float rot = MyMath.GetAim(transform.position, transform.position + dir);
        transform.localRotation = Quaternion.Euler(Vector3.forward * rot);


        // �ǂ���͂ݏo���������Ђ����߂�
        Vector3 diff = _arrowApex.position - MyMath.ClampPos(_arrowApex.position, _AREA_WIDTH, _AREA_HEIGHT);
        transform.position -= dir * diff.magnitude;
    }
}
