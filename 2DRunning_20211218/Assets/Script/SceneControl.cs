using UnityEngine;
using UnityEngine.SceneManagement;  //�ޥ� �����޲z �R�W�Ŷ��A�i�H�ϥγ��� API

/// <summary>
/// ��������
/// 1. �i�H��������
/// 2. �i�H���}�C�� 
/// </summary>
public class SceneControl : MonoBehaviour
{
    /// <summary>
    /// ������J����
    /// </summary>
    public void DelayLoadScene()
    {
        // �ϥ� MonoBehaviour �� API �y�k :
        // ��k�W��(�����޼�);
        Invoke("LoadScene", 1.5f); // ����I�s("��k�W��"�A������)�A���� 1.5 ��I�s LoadScene
    }

    /// <summary>
    /// ���J����
    /// </summary>
    public void LoadSence()
    {
        SceneManager.LoadScene("���d 1");
    }

    /// <summary>
    /// �������}�C��
    /// </summary>
    public void DelayQuitGame()
    {
        Invoke("QuitGame", 1.5f);
    }

    // Unity ���s�P�{�����q�覡
    // 1. ���}��k
    // 2. ���s button ���� On Click �i�H���w����k
    /// <summary>
    /// ���}�C�� 
    /// </summary>
    public void QuitGame()
    {
        print("���}�C��");
        Application.Quit();     // ���ε{��.���}() - �����C���AUnity �����|����
    }
}
