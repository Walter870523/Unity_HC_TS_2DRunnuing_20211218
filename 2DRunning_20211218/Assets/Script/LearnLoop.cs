using UnityEngine;


/// <summary>
/// �j��
/// 1. while *
/// 2. do while
/// 3. for *
/// 4. foreach
/// </summary>
public class LearnLoop : MonoBehaviour
{
    // �j��@��
    // �B�z���Ƶ{��

    public int[] scores = new int[20];

    private void Start()
    {
        #region �j�� while �P for
        //��X�������o
        print("���o");
        print("���o");
        print("���o");
        print("���o");
        print("���o");

        // while �j��y�k
        // �P if �P�_�O�����ۦP
        // if (���L��) { �{���϶� }

        if (true)
        {
            print("�P�_�� if");
        }

        // ���L�Ȭ� true ����i�� {}
        /*
        while (true)
        {
            print("�j�� while");
        }
        */

        int count = 0;

        while (count < 5)
        {
            print("���o while");
            count++;
        }

        for (int i =0; i < 5; i++)
        {
            print("���o for");
        }

        //��X�Ʀr 1 ~ 100
        for (int i = 1; i < 101; i++)
        {
            print("��X�Ʀr: " + i);
        }
        #endregion

        // �j��P�}�C����
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = 70 + 1;
        }
    }
}
