using UnityEngine;

/// <summary>
/// �{��API
/// </summary>
public class APIstatic : MonoBehaviour
{
    //API������
    //�R�@�A ������r static
    //�D�R�A �L����r static

    //�ݩ� properties �i�H�z�Ѭ����P�����
    //�禡 methods

    public float number = 9.99f;
    public Vector3 a = new Vector3(1, 1, 1);
    public Vector3 b = new Vector3(22, 22, 22);
    private void Start()
    {
        #region �{���R�A�ݩʻP��k
        //�R�A�ݩ�
        //���o
        //�y�k:���O.�R�A�ݩ�
        print("�H����:" + Random.value);
        print("�L���j:" + Mathf.Infinity);

        //�]�w
        //�y�k:���O.�R�A�ݩ� ���w ��;
        Cursor.visible = false;
        //Random.value = 7.7f; Read Only �ݩʤ���]�w
        Screen.fullScreen = true;

        //�R�A��k
        //�I�s
        //�y�k:���O.�R�A��k(�����޼�);
        float r = Random.Range(7.5f, 9.8f);
        print("�H���d�� 7.5 ~ 9.8:" + r);
        #endregion

        #region �m���R�A�ݩʻP��k
        print("�Ҧ���v���ƶq:" + Camera.allCamerasCount);
        print("2D�����O�j�p:" + Physics2D.gravity);
        print("��P�v:" + Mathf.PI);
        Physics2D.gravity = new Vector2(0, -20);
        print("2D�����O�j�p:" + Physics2D.gravity);
        Time.timeScale = 0.5f;
        print("�ɶ��j�p:" + Time.timeScale);

        //�I�s�R�A��k
        number = Mathf.Floor(number);
        print("9.99�h�p���I" + number);

        float d = Vector3.Distance(a, b);
        print("a b �Z��:" + d);

        Application.OpenURL("");
        #endregion
    }
    public float hp = 70;
    private void Update()
    {
        #region �{���R�A�ݩʻP��k
        hp = Mathf.Clamp(hp, 0, 100);
        print("��q:" + hp);
        #endregion

        #region �m���R�A�ݩʻP��k
        print("�O�_��J���N��:" + Input.anyKey);
        //print("�g�L�ɶ�:" + Time.time);
        #endregion
    }
}
