using UnityEngine;

/// <summary>
/// ��V���b���a����]�Ũt��
/// </summary>
public class Player : MonoBehaviour
{
    #region ���
    // �]�B�t�סB���D���סB�O�_�Ʀ�B�O�_���`
    // �ʵe�ѼƸ��D�B�Ʀ�P���`
    // ����ݩ� Attribute
    // Header ���D
    // Range �d��:�ȭ���ƭȫ��A��ơAfloat�Bint
    // Tooltip ����
    [Header("�]�B�t��"), Range(0, 500)]
    public float speed = 1.5f;
    [Header("���D����"), Range(0, 5000)]
    public float jump = 500;
    [Tooltip("�x�s����O�_�b�Ʀ�")]
    public bool isSlide;
    [Tooltip("�x�s����O�_���`")]
    public bool isDead;

    public string parameterJump = "Ĳ�o���D";
    public string parameterSlide = "�}���Ʀ�";
    public string parameterDead = "Ĳ�o���`";

    [Header("���D����")]
    public KeyCode keyJump = KeyCode.Space;

    // �s�� Transform �Ĥ@�ؤ覡
    //public Transform traPlayer;
    
    // �ݩʭ��O ... > Debug �Ҧ��i�H�ݨ�p�H���
    private Rigidbody2D rig;
    [Header("���D�q�Ƴ̤j��"), Range(0, 5)]
    public int countJumpMax = 2;

    public int countJump;

    [Header("�ˬd�a�O�첾")]
    public Vector3 v3GroudOffset;
    [Header("�ˬd�a�O�ؤo")]
    public Vector3 v3GroundSize = Vector3.one;
    [Header("�a�O���ϼh")]
    public LayerMask layerGround;
    
    //private Animation a;        // �ª� �ʵe�t��
    //private Animator b;         // �s�� �ʵe�t��

    private Animator ani;
    #endregion

    [Header("�Ʀ����")]
    public KeyCode KeySlide = KeyCode.DownArrow;

    private CapsuleCollider2D cc2d;

    #region �ƥ�
    // ø�s�Ϧ��ƥ�:�b Unity ��ø�s���U�Ϊ��ϥܡA�]�t:�u�B��ΡB��ε��X��ϧ�(�����ɤ��|���)
    private void OnDrawGizmos()
    {
        // 1. �M�w�ϥ��C��
        Gizmos.color = new Color(1, 0, 0.2f, 0.35f);
        // 2. ø�s�ϥ�
        // �ϥ�.ø�s����(�����I�A�ؤo)
        Gizmos.DrawCube(transform.position + v3GroudOffset, v3GroundSize);
    }

    private void Start()
    {
        // GetComponent<��������>() - <> �x���A�Ҧ�����
        // ���o���w����
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        cc2d = GetComponent<CapsuleCollider2D>();

        // ���D�q�� ���w�� �̤j��
        countJump = countJumpMax;
    }

    private void Update()
    {
        Run();
        Jump();
        Slide();
    }
    #endregion

    #region ��k
    /// <summary>
    /// �]�B
    /// </summary>
    private void Run()
    {
        // �s�� Transfrom �Ĥ@�ؤ覡
        // ���a�ܧ�.�첾(X�AY�AZ)
        // Time.deltaTime �@�V���ɶ�
        // traPlayer.Translate(speed * Time.deltaTime, 0, 0);

        // �s�� Transform �ĤG�ؤ覡
        // 1. ��n��� Transform �P������P�@���h
        // �y�k:
        // transform.�����W��
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    /// <summary>
    /// ���D
    /// </summary>
    private void Jump()
    {
        // �O�_���U���D = ��J.���o������U(���w����)
        bool inputJump = Input.GetKeyDown(keyJump);
        // print("�O�_���U���D:" + inputJump);

        //�p�G ���U���D �åB ���D�q�� �j�� �s �N ���W��
        if (inputJump && countJump > 0)
        {
            // print("���D");
            // ����.�K�[���O(�G���V�q)
            rig.AddForce(new Vector2(0, jump));
            // ���D����A���D�q�ƴ�@
            countJump--;
            // �ʵe.�]�wĲ�o(�ʵe�ѼƦW��)
            ani.SetTrigger(parameterJump);
        }

        // 2D �I�� = 2D ���z����л\(�����I�A�ؤo�A���סA�ϼh)
        Collider2D hit = Physics2D.OverlapBox(transform.position + v3GroudOffset, v3GroundSize, 0, layerGround);

        //print("���a�����O�[�t��:" + rig.velocity);

        // �p�G 2D �I������s�b �åB ���骺�[�t�� Y < 0 (���U����)
        if (hit && rig.velocity.y < 0)
        {
            // ���D���� ���w �̤j���D����
            countJump = countJumpMax;
        }
    }

    /// <summary>
    /// �Ʀ�
    /// </summary>
    private void Slide()
    {
        // �P�_�O�_���U�Ʀ�
        // ��s�Ʀ�ʵe
        // ��s�I����
        if (Input.GetKey(KeySlide))
        {
            ani.SetBool(parameterSlide, true);

            // �Ʀ�:0.2��-0.85 | 2, 1.2 h
            cc2d.offset = new Vector2(0.2f, -0.85f);
            cc2d.size = new Vector2(2, 1.2f);
            cc2d.direction = CapsuleDirection2D.Horizontal;
        }
        else
        {
            ani.SetBool(parameterSlide, false);
            // ����:0.2, -0.2 | 1, 2.5 v
            cc2d.offset = new Vector2(0.2f, -0.2f);
            cc2d.size = new Vector2(1, 2.5f);
            cc2d.direction = CapsuleDirection2D.Vertical;
        }
        
        
    }
    #endregion
}
