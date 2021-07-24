using UnityEngine;
using UnityEngine.SceneManagement; //引用場景管理API

public class SceneController : MonoBehaviour
{
    //Unity 按鈕如何跟腳本溝通
    //1. 公開的函式
    //2. 需要實體物件掛腳本

    /// <summary>
    /// 載入遊戲場景
    /// </summary>
    public void LoadGameScene()
    {
        //場景管理.載入場景(場景名稱) - 載入指定的場景
        SceneManager.LoadScene("Game_scene");
    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void QuitGame()
    {
        Application.Quit(); //應用程式.離開() - 關閉遊戲
        print("離開遊戲");  //Quit 在編譯器內不會執行
    }
}
