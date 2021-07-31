using UnityEngine;

public class player : MonoBehaviour
{
    #region ���
    [Header("���ʳt��"), Range(0,50)]
    public float moveSpeed = 10.5f;
    [Header("���D����"),Range(0, 15000)]
    public int jumpHeight = 3000;
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
        Turndirection();
        Jump();
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
        //print("���a������: " + hValue);
    }
    [Header("���O"), Range(0.01f, 1)]
    public float gravity = 1;

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
        Vector2 posMove = transform.position + new Vector3(horizontal, -gravity, 0) * moveSpeed * Time.fixedDeltaTime;
        // ����.���ʮy��(�n�e�����y��);
        rig.MovePosition(posMove);
    }

    private void Turndirection()
    {
        // �p�G���a��D�N�N���׳]�w��(0,0,0)
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = Vector3.zero;
        }
        // �p�G���a��A�N�N���׳]�w��(0,180,0)
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
    /// <summary>
    /// ���D
    /// </summary>
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(new Vector2(0, jumpHeight));
        }
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
