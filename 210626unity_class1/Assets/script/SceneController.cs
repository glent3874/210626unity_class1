using UnityEngine;
using UnityEngine.SceneManagement; //�ޥγ����޲zAPI

public class SceneController : MonoBehaviour
{
    //Unity ���s�p���}�����q
    //1. ���}���禡
    //2. �ݭn���骫�󱾸}��

    /// <summary>
    /// ���J�C������
    /// </summary>
    public void LoadGameScene()
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
