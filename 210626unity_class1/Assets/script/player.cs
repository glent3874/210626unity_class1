using UnityEngine;

public class player : MonoBehaviour
{
    #region ���
    [Header("���ʳt��"), Range(0,1000)]
    public float moveSpeed = 10.5f;
    [Header("���D����"),Range(0, 3000)]
    public int jumpHeight = 100;
    [Header("��q"), Range(0, 200)]
    public float HP = 100;
    [Header("�O�_�b�a�O�W"),Tooltip("�Ψ��x�s����O�_�b�a�O�W����T, �b�a�O�Wtrue, �Ϥ�false")]
    public bool onFloor = false;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    #endregion
}
