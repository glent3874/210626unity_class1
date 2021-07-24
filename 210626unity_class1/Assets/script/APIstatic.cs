using UnityEngine;

/// <summary>
/// 認識API
/// </summary>
public class APIstatic : MonoBehaviour
{
    //API分兩類
    //靜　態 有關鍵字 static
    //非靜態 無關鍵字 static

    //屬性 properties 可以理解為等同於欄位
    //函式 methods

    public float number = 9.99f;
    public Vector3 a = new Vector3(1, 1, 1);
    public Vector3 b = new Vector3(22, 22, 22);
    private void Start()
    {
        #region 認識靜態屬性與方法
        //靜態屬性
        //取得
        //語法:類別.靜態屬性
        print("隨機值:" + Random.value);
        print("無限大:" + Mathf.Infinity);

        //設定
        //語法:類別.靜態屬性 指定 值;
        Cursor.visible = false;
        //Random.value = 7.7f; Read Only 屬性不能設定
        Screen.fullScreen = true;

        //靜態方法
        //呼叫
        //語法:類別.靜態方法(對應引數);
        float r = Random.Range(7.5f, 9.8f);
        print("隨機範圍 7.5 ~ 9.8:" + r);
        #endregion

        #region 練習靜態屬性與方法
        print("所有攝影機數量:" + Camera.allCamerasCount);
        print("2D的重力大小:" + Physics2D.gravity);
        print("圓周率:" + Mathf.PI);
        Physics2D.gravity = new Vector2(0, -20);
        print("2D的重力大小:" + Physics2D.gravity);
        Time.timeScale = 0.5f;
        print("時間大小:" + Time.timeScale);

        //呼叫靜態方法
        number = Mathf.Floor(number);
        print("9.99去小數點" + number);

        float d = Vector3.Distance(a, b);
        print("a b 距離:" + d);

        Application.OpenURL("");
        #endregion
    }
    public float hp = 70;
    private void Update()
    {
        #region 認識靜態屬性與方法
        hp = Mathf.Clamp(hp, 0, 100);
        print("血量:" + hp);
        #endregion

        #region 練習靜態屬性與方法
        print("是否輸入任意鍵:" + Input.anyKey);
        //print("經過時間:" + Time.time);
        #endregion
    }
}
