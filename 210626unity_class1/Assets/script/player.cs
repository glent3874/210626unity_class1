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

    #region �ƥ�

    #endregion
    #region �禡
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="horizontal">���k�ƭ�</param>
    private void Move(float horizontal)
    {
        
    }
    /// <summary>
    /// ���D
    /// </summary>
    private void Jump()
    {

    }
    /// <summary>
    /// ����
    /// </summary>
    private void Attack()
    {

    }
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="damage">�y�����ˮ`</param>
    public void Hurt(float damage)
    {

    }
    /// <summary>
    /// ���`
    /// </summary>
    private void Dead()
    {

    }
    /// <summary>
    /// �߹D��
    /// </summary>
    /// <param name="propName">�D��W��</param>
    private void EatProp(string propName)
    {

    }
    #endregion
}
