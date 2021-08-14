using UnityEngine;
/// <summary>
/// �ĤH�򩳦C�O
/// �\��: �H������, ����, �l�ܪ��a, ���˻P���`
/// ���A��: �C�| Enum, �P�_�� switch (��¦�y�k)
/// </summary>
public class BaseEnemy : MonoBehaviour
{
    #region ���
    [Header("�򥻯�O")]
    [Range(50, 5000)]
    public float hp = 100;
    [Range(5, 1000)]
    public float attack = 20;
    [Range(1, 500)]
    public float speed = 1.5f;

    [SerializeField]
    private StateEnemy state;

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
    #endregion

    #region �ƥ�
    private void Start()
    {
        #region ��l�ȳ]�w
        timeIdle = Random.Range(1f, 5f);
        #endregion
    }
    private void Update()
    {
        CheckState();
    }
    #endregion

    #region �禡
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
                break;
            case StateEnemy.dead:
                break;
        }
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
            state = StateEnemy.walk;            //�������A
            timerIdle = 0;                      //�p�ɾ��k�s
        }
    }

    private void Walk()
    {

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