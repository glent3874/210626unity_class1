using UnityEngine;
using UnityEngine.SceneManagement; //引用場景管理API

public class SceneController : MonoBehaviour
{
    //Unity 按鈕如何跟腳本溝通
    //1. 公開的函式
    //2. 需要實體物件掛腳本
    //3. 按鈕 On Click 設定點擊事件為此物件以及要呼叫的方法

    /// <summary>
    /// 載入遊戲場景
    /// </summary>
    public void LoadGameScene()
    {
        //等兩秒再載入場景
        //延遲呼叫(方法名稱, 延遲時間)
        //作用: 等待指定時間後再呼叫指定方法
        Invoke("DelayLoadGameScene", 2);
    }

    //等待一段時間再執行函式
    //Invoke 延遲呼叫
    public void DelayLoadGameScene()
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
