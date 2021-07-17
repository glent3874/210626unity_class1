using UnityEngine;

public class player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0,1000)]
    public float moveSpeed = 10.5f;
    [Header("跳躍高度"),Range(0, 3000)]
    public int jumpHeight = 100;
    [Header("血量"), Range(0, 200)]
    public float HP = 100;
    [Header("是否在地板上"),Tooltip("用來儲存角色是否在地板上的資訊, 在地板上true, 反之false")]
    public bool onFloor = false;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    #endregion
}
