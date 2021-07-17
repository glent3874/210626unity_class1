using UnityEngine;  // 引用 Unity 引擎 提供的 API (Unity Engine 命名空間)

// 類別
// 語法: 類別關鍵字 腳本名稱
public class car : MonoBehaviour
{
    
    #region 基本類型
    public float weight = 3.5f;
    public int cc = 2000;
    public string brand = "賓士";
    public bool windowSky = true;
    //標題屬性(輔助): 可以顯示中文在unity inspector 且穩定不出錯
    [Header("輪胎數量")] //[Header(字串)]
    public int wheelcount = 4;
    //提示: [Tooltip(字串)]
    [Tooltip("設定汽車高度")]
    public float height = 1.5f;
    //範圍: [Range(min, Max)]  <限float, int
    [Range(2, 10)]
    public int doorCount;
    #endregion
    #region 其他類型
    //color
    public Color color1;                                        //預設黑色透明
    public Color red = Color.red;                               //設定內建顏色
    public Color yellow = Color.yellow;                         
    public Color colorCustom1 = new Color(0.5f, 0.5f, 0);       //自訂顏色(R,G,B)
    public Color colorCustom2 = new Color(0.5f, 0, 0.5f, 0.5f);

    //座標 2 - 4 維 Vector2 - 4
    //保存數值資訊, 常為浮點數
    public Vector2 v2;
    public Vector2 v2Zero = Vector2.zero;
    public Vector2 v2One = Vector2.one;
    public Vector2 v2Up = Vector2.up;
    public Vector2 v2Right = Vector2.right;
    public Vector2 v2Custom = new Vector2(-99.5f, 100.5f);

    public Vector3 v3;
    public Vector4 v4;

    //按鍵類型
    public KeyCode kc;
    public KeyCode forward = KeyCode.D;
    public KeyCode attack = KeyCode.Mouse0; //左鍵0, 右鍵 1, 滾輪2

    //遊戲物件與元件
    public GameObject goCamera; //遊戲物件包含場景上的以及專案內的預製物
    //元件僅限於存放屬性面板有此的物件
    public Transform traCar;
    public SpriteRenderer sprPicture;
    #endregion
    #region 事件
    // 開始事件: 播放遊戲時執行一次, 處理初始化
    private void Start()
    {
        // 輸出(任何類型資料);
        print("HI");

        //練習取得欄位 Get
        print(brand);
        //練習設定欄位 Set
        windowSky = true;
        cc = 5000;
        weight = 9.9f;
    }
    //更新事件: 大約一秒60次, 60FPS, 處理物件移動或者監聽玩家輸入
    private void Update()
    {
        
    }
    #endregion
}
