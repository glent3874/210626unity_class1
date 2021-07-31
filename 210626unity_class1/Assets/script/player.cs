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
    /// <summary>
    /// ���a������J�ƭ�
    /// </summary>
    private float hValue;
    #endregion

    #region �ƥ�
    private void Start()
    {
        // GetCompoment<����>() �x����k, �i�H���w��������
        // �@��: ���o������ 2D ���餸��
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetPlayerInputHorizontal();
    }

    // �T�w��s�ƥ�
    // �@��T�w���� 50 ��, �x���ĳ���ϥΨ쪫�z API �n�b���ƥ󤺰���
    private void FixedUpdate()
    {
        Move(hValue);
    }
    #endregion
    #region �禡
    /// <summary>
    /// ���o���a��J�����b�V��: ���P�k A, D, ��, �k
    /// </summary>
    private void GetPlayerInputHorizontal()
    {
        // ������ = ��J.���o�b�V(�b�V�W��)
        // �@��: ���o���a���U�������䪺��, ���k�� 1 , ������-1, �S���� 0 
        hValue = Input.GetAxis("Horizontal");
        print("���a������: " + hValue);
    }

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="horizontal">���k�ƭ�</param>
    private void Move(float horizontal)
    {
        // �ϰ��ܼ�: �b��k�������, ���ϰ��, �ȭ��󦹤�k���s��
        // ²�g: transform ������ Transform �ܧΤ���
        // posMove = �����e�y�� + ���a��J��������
        // Time.fixedDeltaTime �� 1/50 ��
        Vector2 posMove = transform.position + new Vector3(horizontal, 0, 0) * moveSpeed * Time.fixedDeltaTime;
        // ����.���ʮy��(�n�e�����y��);
        rig.MovePosition(posMove);
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
