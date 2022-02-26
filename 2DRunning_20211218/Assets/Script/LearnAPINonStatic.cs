using UnityEditor;
using UnityEngine;

/// <summary>
/// �ǲ߫D�R�A API
/// �D�R�A Non-Static
/// ���骫��A�s�b�C��������������
/// ���Ǫ��T�ثD�R�A API �ϥΤ覡
/// 1. ���o�D�R�A�ݩ�
/// 2. �s��D�R�A�ݩ�
/// 3. �ϥΫD�R�A��k
/// </summary>
public class LearnAPINonStatic : MonoBehaviour
{
    public Transform traCar1;
    public GameObject goCar;
    public Camera cam;
    public SpriteRenderer spr;
    public Transform banana;
    public Rigidbody2D apple;

    private void Start()
    {
        #region �оǰ�
        // �R�A�P�D�R�A�̤j���t��
        // �� 1. �D�R�A�ݭn�����骫��s�b
        // �� 2. �w�q�@�����
        // �� 3. �x�s�ӹ��骫��
        // ���骫�� :
        // 1. �C������ Game Object : �b Hierarchy �����զ�u�عϥܪ���
        // 2. �w�m�� Prefab : �b Hierarchy �����Ŧ�c���ϥܪ���
        // 3. ���� Component : 1 �P 2 �ݩʭ��O�W�i���|��

        // �D�R�A�ݩʻy�k
        // 1. ���o Get
        // ���W��.�D�R�A�ݩʦW��
        print("�T�����y�� : " + traCar1.position);
        // 2. �s�� Set
        // ���W��.�D�R�A�ݩʦW�� ���w ��:
        traCar1.position = new Vector3(-5, 3, 1);

        // �R�A��k�y�k
        // 3. �ϥ�
        // ���W��.�D�R�A�ݩʦW��(�������޼�);
        goCar.SetActive(false);
        #endregion

        #region �m�߰�
        print("���o��v���`�� : " + cam.depth);
        print("���o�_���G���Ϥ��C�� : " + spr.color);

        cam.backgroundColor = Random.ColorHSV();
        spr.flipY = true;
        #endregion
    }

    private void Update()
    {
        banana.Rotate(0, 0, 10);
        apple.AddForce(new Vector2(0, 10));
    }
}
