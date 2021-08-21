using UnityEngine;
using System.Collections;

/// <summary>
/// 近距離攻擊敵人類型: 近距離攻擊
/// </summary>
//類別: 父類別
//: 冒號後面第一個代表的是要繼承的類別
public class NearEnemy : BaseEnemy
{
    #region 欄位
    [Header("攻擊區域的位移與大小")]
    public Vector2 checkAttackOffset;
    public Vector3 checkAttackSize;
    #endregion

    #region 事件
    protected override void OnDrawGizmos()
    {
        //父類別原本的內容
        base.OnDrawGizmos();

        Gizmos.color = new Color(1, 0.3f, 0.1f, 0.3f);
        Gizmos.DrawCube(
            transform.position +
            transform.right * checkAttackOffset.x +
            transform.up * checkAttackOffset.y,
            checkAttackSize);
    }

    protected override void Update()
    {
        base.Update();

        CheckPlayerInAttackArea();
    }
    #endregion

    #region 函式
    private void CheckPlayerInAttackArea()
    {
        Collider2D hit = Physics2D.OverlapBox(
            transform.position +
            transform.right * checkAttackOffset.x +
            transform.up * checkAttackOffset.y,
            checkAttackSize, 0, 1 << 7);

        if (hit) state = StateEnemy.attack;
    }

    protected override void AttackMethod()
    {
        base.AttackMethod();

        StartCoroutine(DelaySendDamageToPlayer());
    }

    private IEnumerator DelaySendDamageToPlayer()
    {
        yield return new WaitForSeconds(attackDelayFirst);
    }
    #endregion
}
