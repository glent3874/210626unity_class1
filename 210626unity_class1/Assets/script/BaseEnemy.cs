using UnityEngine;
using System.Linq;

/// <summary>
/// �ĤH�򩳦C�O
/// �\��: �H������, ����, �l�ܪ��a, ���˻P���`
/// ���A��: �C�| Enum, �P�_�� switch (��¦�y�k)
/// </summary>
public class BaseEnemy : MonoBehaviour
{
    #region ���:���}
    [Header("�򥻯�O")]
    [Range(50, 5000)]
    public float hp = 100;
    [Range(5, 1000)]
    public float attack = 20;
    [Range(1, 500)]
    public float speed = 1.5f;

    /// <summary>
    /// �H�����ݽd��
    /// </summary>
    public Vector2 v2RandomIdle = new Vector2(1, 5);
    /// <summary>
    /// �H�������d��
    /// </summary>
    public Vector2 v2RandomWalk = new Vector2(3, 6);
    [Header("�ˬd�e��O�_����ê���Φa�O�y��")]
    public Vector3 checkForwardOffect;
    [Range(0, 1)]
    public float checkForwardRadius = 0.3f;
    [Header("�Ĥ@����������"), Range(0.5f, 5)]
    public float attackDelayFirst = 0.5f;

    // �N�p�H�����ܦb�ݩʭ��O�W
    [SerializeField]
    protected StateEnemy state;
    #endregion



    #region ���: �p�H
    private Rigidbody2D rig;
    private Animator ani;
    private AudioSource aud;
    
    /// <summary>
    /// ���ݮɶ�: �H��
    /// </summary>
    private float timeIdle;
    /// <summary>
    /// ���ݥέp�ɾ�
    /// </summary>
    private float timerIdle;
    /// <summary>
    /// �����ɶ�: �H��
    /// </summary>
    private float timeWalk;
    /// <summary>
    /// �����έp�ɾ�
    /// </summary>
    private float timerWalk;
    #endregion

    #region �ƥ�
    private void Start()
    {
        #region ��l�ȳ]�w
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        #endregion
    }

    protected virtual void Update()
    {
        CheckForward();
        CheckState();
    }

    private void FixedUpdate()
    {
        WalkInFixedUpdate();
    }

    //�����O�������p�G�Ʊ�l���O�Ƽg������`:
    //1.�׹��������O public �� protected - �O�@ ���\�l���O�s��
    //2.�K�[����r virtual ���� - ���\�l���O�Ƽg
    //3. �l���O�ϥ� override
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0.3f, 0.3f, 0.3f);
        //transform.right ��e���󪺥k��(2D�Ҧ����e��, ����b�Y)
        //transform.up ��e���󪺤W�� (���b�Y)
        Gizmos.DrawSphere(
            transform.position +
            transform.right * checkForwardOffect.x +
            transform.up * checkForwardOffect.y,
            checkForwardRadius);
    }
    #endregion

    //�{�Ѱ}�C
    //�y�k: �������[�W���A��, �Ҧp: int [], float[], string[], Vector2[]
    public Collider2D[] hits;
    /// <summary>
    /// �s��e��O�_�����]�t�a�O, ���x������
    /// </summary>
    public Collider2D[] hitResult;

    #region �禡
    private void CheckForward()
    {
        hits = Physics2D.OverlapCircleAll(
            transform.position +
            transform.right * checkForwardOffect.x +
            transform.up * checkForwardOffect.y,
            checkForwardRadius);
        //��ر��p���n��V, �קK�����ê���H�α���
        //1. �}�C���O�Ū� - �S���a�诸�߷|����
        //2. �}�C�������O �a�O �� ���O ���x ������ - ����ê��
        //�d�߻y�� LinQ: �i�H�d�߰}�C���, �Ҧp: �O�_�]�t�a�O, �O�_����Ƶ���..

        hitResult = hits.Where(x => x.name != "�a�O" && x.name != "���x" && x.name != "�D��" && x.name != "�i��z���x").ToArray();

        //�}�C���ŭ�: �}�C�ƶq���s
        //�p�G �I���ƶq���s (�e��S���a�诸��) �Ϊ� �I�����G�j��s (�e�観��ê��) ���n��V
        if(hits.Length == 0 || hitResult.Length > 0)
        {
            print("�e��S���a�O�|����.");
            TurnDirection();
        }
    }

    private void TurnDirection()
    {
        float y = transform.eulerAngles.y;
        if (y == 0) transform.eulerAngles = Vector3.up * 180;
        else transform.eulerAngles = Vector3.zero;
    }
    private void CheckState()
    {
        switch (state)
        {
            case StateEnemy.idle:
                Idle();
                break;
            case StateEnemy.walk:
                Walk();
                break;
            case StateEnemy.track:
                break;
            case StateEnemy.attack:
                Attack();
                break;
            case StateEnemy.dead:
                break;
        }
    }

    [Range(0.5f, 5)]
    /// <summary>
    /// �����N�o�ɶ�
    /// </summary>
    public float cdAttack = 3;
    private float timerAttack;

    /// <summary>
    /// �������A: ��������òK�[�N�o
    /// </summary>
    private void Attack()
    {
        if (timerAttack < cdAttack)
        {
            timerAttack += Time.deltaTime;
        }
        else
        {
            AttackMethod();
        }
    }

    protected virtual void AttackMethod()
    {
        timerAttack = 0;
        ani.SetTrigger("����");
    }

    /// <summary>
    /// ����: �H����ƫ�i�J�������A
    /// </summary>
    private void Idle()
    {
        if(timerIdle < timeIdle)                //�p�G �p�ɾ� < ���ݮɶ�
        {
            timerIdle += Time.deltaTime;        //�֥[�ɶ�
        }
        else
        {
            RandomDirection();
            state = StateEnemy.walk;                                     //�������A
            timeWalk = Random.Range(v2RandomWalk.x, v2RandomWalk.y);     //���o�H����
            timerIdle = 0;                                               //�p�ɾ��k�s
        }
    }

    private void Walk()
    {
        if(timerWalk < timeWalk)
        {
            timerWalk += Time.deltaTime;
        }
        else 
        {
            state = StateEnemy.idle;
            timeIdle = Random.Range(v2RandomIdle.x, v2RandomIdle.y);
            timerWalk = 0;
        }
    }
    /// <summary>
    /// �N���z�欰��W�B�z�æb FixedUpdate �I�s
    /// </summary>
    private void WalkInFixedUpdate()
    {
        // �p�G�ثe���A�O���� ����.�[�t�� = �k�� * �t�� * 1/50 + �W�� * �a�ߤޤO
        if(state == StateEnemy.walk) rig.velocity = transform.right * speed * Time.deltaTime + Vector3.up * rig.velocity.y;
    }

    /// <summary>
    /// �H����V: �H�����V�k��Υ���
    /// �Ȭ� 0 ��, ����: 0, 180, 0
    /// �Ȭ� 1 ��, �k��: 0, 0, 0
    /// </summary>
    private void RandomDirection()
    {
        // �H��.�d��(�̤p, �̤j) - ��Ʈɤ��]�t�̤j��(0, 2) - �H�����o0��1
        int random = Random.Range(0, 2);
        if (random == 0) transform.eulerAngles = Vector2.up * 180;
        else transform.eulerAngles = Vector2.zero;
    }    

    #endregion
}

//�w�q�C�|
//1. �ϥ�����r enum �w�q�C�|�H�Υ]�t���ﶵ, �i�H�b���O�~�w�q
//2. �ݭn���@�����w�q�����C�|����
//�y�k: �׹��� enum �C�|�W��{�ﶵ1, �ﶵ2, .... ,�ﶵN}
enum StateEnemy
{
    idle, walk, track, attack, dead
}