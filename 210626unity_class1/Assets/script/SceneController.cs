using UnityEngine;
using UnityEngine.SceneManagement; //�ޥγ����޲zAPI

public class SceneController : MonoBehaviour
{
    //Unity ���s�p���}�����q
    //1. ���}���禡
    //2. �ݭn���骫�󱾸}��
    //3. ���s On Click �]�w�I���ƥ󬰦�����H�έn�I�s����k

    /// <summary>
    /// ���J�C������
    /// </summary>
    public void LoadGameScene()
    {
        //�����A���J����
        //����I�s(��k�W��, ����ɶ�)
        //�@��: ���ݫ��w�ɶ���A�I�s���w��k
        Invoke("DelayLoadGameScene", 2);
    }

    //���ݤ@�q�ɶ��A����禡
    //Invoke ����I�s
    public void DelayLoadGameScene()
    {
        //�����޲z.���J����(�����W��) - ���J���w������
        SceneManager.LoadScene("Game_scene");
    }

    /// <summary>
    /// ���}�C��
    /// </summary>
    public void QuitGame()
    {
        Application.Quit(); //���ε{��.���}() - �����C��
        print("���}�C��");  //Quit �b�sĶ�������|����
    }
}
