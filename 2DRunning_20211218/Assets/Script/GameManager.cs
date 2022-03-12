using UnityEngine;
using UnityEngine.UI;          // �ޥ� ���� API

/// <summary>
/// �C���޲z��
/// �����q�B�ɶ��P���ƺ޲z
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("���")]
    public Image imgHp;
    [Header("�ɶ�")]
    public Text textTime;
    [Header("����")]
    public Text textScore;
    [Header("���a��q"),Range(0, 5000)]
    public float hp = 100;
    [Header("�D�����")]
    public string tagProp = "�D��";
    [Header("��������")]
    public string tagTrap = "����";

    private int score;
    private float hpMax;

    private void Start()
    {
        hpMax = hp;            // ��q�̤j�ȹC���}�l�ɫ��w����q��l��
    }

    private void Update()
    {
        UpdateTimeUI();
        UpdateHpUI();
    }

    /// <summary>
    /// ��s�ɶ�����
    /// </summary>
    private void UpdateTimeUI()
    {
        // print("��e�����ɶ� : " + Time.timeSinceLevelLoad);
        // ToString() �N����ର�r������
        // () ���i�H�榡�Ʀr��AF�Ʀr:�p���I��X��A�Ҧp:F2 �p���I�����
        textTime.text = "�ɶ� : " + Time.timeSinceLevelLoad.ToString("F2");
    }

    /// <summary>
    /// ��s�������
    /// </summary>
    private void UpdateHpUI()
    {
        hp -= Time.deltaTime;
        imgHp.fillAmount = hp / hpMax;
    }

    /// <summary>
    /// �[���ƨåB��s����
    /// </summary>
    private void AddScoreAndUpdateUI(int add)
    {
        score += add;
        textScore.text = "����:" + score;
    }

    // �󴫦W�٧ֱ��� C+ R R
    /// <summary>
    /// �ܧ��q�åB��s����
    /// </summary>
    /// <param name="value">�n�ܧ󪺭�</param>
    private void ChangeHpAndUpdateUI(float value)
    {
        hp += value;
        hp = Mathf.Clamp(hp, 0, hpMax);
        imgHp.fillAmount = hp / hpMax;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // print("���a�I�쪺����:" + collision.name);

        if (collision.tag == tagProp)
        {
            AddScoreAndUpdateUI(collision.GetComponent<Prop>().score);
            if (collision.name.Contains("���")) ChangeHpAndUpdateUI(10);
            Destroy(collision.gameObject);                             // Destroy (����) �R������
        }

        if (collision.tag == tagTrap)
        {
            ChangeHpAndUpdateUI(-collision.GetComponent<Trap>().damage);
        }
    }
}
