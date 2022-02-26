using UnityEngine;


/// <summary>
/// �ǲ߱���(�P�_��)
/// 1. if
/// 2. switch
/// </summary>
public class LearnCondition : MonoBehaviour
{
    public bool hasKey = true;
    public int combo = 0;
    public string weapon;

    // �C�| enum (�U�Ԧ����)
    // 1. �w�q�C�|
    public enum Season
    {
        spring, summer, fall, winter
    }
    // 2. ��@�C�|
    public Season season;

    private void Start()
    {
        #region if �P�_��
        // if �y�k
        // if (���L��) { �{���϶��B�t��k�B���z���@�b
        // else { �{���϶��B�t��k�B���z�� }
        // �ֳt���� if + Tab * 2

        //���L�� ���� true �|���� {} �����{��
        //���L�� ���� false ������
        //���� : �ϥ� true �P false �t��
        if (true)
        {
            print("�ڬO�P�_�� if");
        }

        // ���L�� ���� true �|���� if {} ���e
        // ���L�� ���� false �|���� else {} ���e
        // �p�G ���_�� �}��
        if (hasKey)
        {
            print("�}��");
        }
        // �_�h �S���_�� ����}��
        else
        {
            print("����}��");
        }
        #endregion

        #region switch �P�_�� 
        // switch �y�k
        // switch (�P�_�����)
        // {
        //      case ��1:
        //          �{�����e;
        //          �{�����e;
        //          �{�����e;
        //          �_�};
        //      case ��2:
        //          �{�����e;
        //          �{�����e;
        //          �{�����e;
        //          �_�};
        //      default:
        //          �{�����e;
        //          �{�����e;
        //          �{�����e;
        //          �_�};
        // }

        // �p�G�Z�� �O �M�l �����O 30
        // �p�G�Z�� �O AK47 �����O 300
        // �p�G�Z�� �O ���C �����O 100
        switch (weapon)
        {
            case "�M�l":
                print("�����O 30");
                break;
            case "AK47":
                print("�����O 300");
                break;
            case "���C":
                print("�����O 100");
                break;
            default:
                print("�o���O�Z��");
                break;
        }
        #endregion

        // switch + enum
        switch (season)
        {
            case Season.spring:
                print("�K��");
                break;
            case Season.summer:
                print("�L��");
                break;
            case Season.fall:
                print("���");
                break;
            case Season.winter:
                print("�V��");
                break;
            default:
                break;
        }

    }

    private void Update()
    {
        // else if �����g�b if �U��A�ƶq�S������
        // else if (���L��) { �{���϶��B�t��k�B���z���@�b

        // �p�G�s�� ���� 10 �����O�N�[ 10
        if (combo == 10)
        {
            print("�����[ 10");
        }
        // �p�G�s�� ���� 100 �����O�N�[ 100
        else if (combo == 100)
        {
            print("�����[ 100");
        }
        // �p�G�s�� ���� 500 �����O�N�[ 500
        else if (combo == 500)
        {
            print("�����[ 500");
        }
    }
}
