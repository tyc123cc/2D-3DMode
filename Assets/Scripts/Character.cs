using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色基类
/// </summary>
public abstract class Character : MonoBehaviour
{
    /// <summary>
    /// 角色移动速度
    /// </summary>
    public float m_speed = 1.0f;

    /// <summary>
    /// 上移按键
    /// </summary>
    private KeyCode m_upButton;

    /// <summary>
    /// 下移按键
    /// </summary>
    private KeyCode m_downButton;

    /// <summary>
    /// 左移按键
    /// </summary>
    private KeyCode m_leftButton;

    /// <summary>
    /// 右移按键
    /// </summary>
    private KeyCode m_rightButton;

    /// <summary>
    /// 攻击按键
    /// </summary>
    private KeyCode m_attackButton;

    /// <summary>
    /// 跳跃按键
    /// </summary>
    private KeyCode m_jumpButton;

    /// <summary>
    /// 父节点
    /// </summary>
    public Transform m_parent;

    /// <summary>
    /// 攻击按键封装，使其对外部只写
    /// </summary>
    public KeyCode AttackButton { set => m_attackButton = value; }

    /// <summary>
    /// 跳跃按键封装，使其对外部只写
    /// </summary>
    public KeyCode JumpButton { set => m_jumpButton = value; }

    /// <summary>
    /// 角色的动画控制器
    /// </summary>
    public Animator m_animator;

    /// <summary>
    /// 角色的渲染器
    /// </summary>
    public SpriteRenderer m_render;

    /// <summary>
    /// 攻击碰撞器
    /// </summary>
    public Transform m_attackTrigger;

    /// <summary>
    /// 攻击碰撞器坐标
    /// </summary>
    public Vector2 m_attackPos;

    /// <summary>
    /// 地面碰撞器
    /// </summary>
    public Transform m_groundTrigger;

    /// <summary>
    /// 地面碰撞器相对角色坐标
    /// </summary>
    public Vector2 m_groundPos;

    /// <summary>
    /// 角色跳跃高度
    /// </summary>
    public float m_jumpHeight;

    /// <summary>
    /// 角色跳跃速度
    /// </summary>
    public float m_jumpSpeed;

    /// <summary>
    /// 角色当前是否在跳跃状态
    /// </summary>
    public bool m_jumpState = false;

    /// <summary>
    /// 设置方向键盘位
    /// </summary>
    /// <param name="upButton">上键盘位</param>
    /// <param name="downButton">下键盘位</param>
    /// <param name="leftButton">左键盘位</param>
    /// <param name="rightButton">右键盘位</param>
    public void SetArrowButton(KeyCode upButton, KeyCode downButton, KeyCode leftButton, KeyCode rightButton)
    {
        m_upButton = upButton;
        m_downButton = downButton;
        m_leftButton = leftButton;
        m_rightButton = rightButton;
    }

    /// <summary>
    /// 人物跳跃函数
    /// </summary>
    public void Jump()
    {
        // 当按下跳跃键时，且位于地面时进行跳跃
        if (Input.GetKeyDown(m_jumpButton) && Math.Abs(transform.localPosition.y) < 0.01f)
        {
            m_jumpState = true;
        }
        // 当前为跳跃状态
        if (m_jumpState)
        {
            // 计算跳跃时下一帧坐标
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, transform.localPosition + Vector3.up, m_jumpSpeed * Time.deltaTime);
            if (transform.localPosition.y > m_jumpHeight)
            {
                // 达到最高跳跃高度，下降
                m_jumpState = false;
            }
        }
        // 当前为下降状态
        else if (!m_jumpState && transform.localPosition.y > 0)
        {
            // 计算下降时下一帧坐标
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, transform.localPosition + Vector3.down, m_jumpSpeed * Time.deltaTime);
            if (Math.Abs(transform.localPosition.y) < 0.01f)
            {
                // 下降到地面，重置坐标
                transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
            }

        }
    }

    /// <summary>
    /// 人物攻击函数
    /// </summary>
    public void Attack()
    {
        // 得到当前动画状态
        AnimatorStateInfo animatorStateInfo = m_animator.GetCurrentAnimatorStateInfo(0);
        // 当任务空闲状态，攻击按钮按下，人物开始执行攻击动画，同时生成攻击碰撞器
        if (Input.GetKeyDown(m_attackButton) && animatorStateInfo.IsName("Idle"))
        {
            m_animator.SetBool("Attack", true);
        }
        // 攻击进行动作
        Attacking(animatorStateInfo);
        // 攻击结束
        AttackEnd(animatorStateInfo);
    }

    /// <summary>
    /// 攻击进行动作
    /// </summary>
    private void Attacking(AnimatorStateInfo animatorStateInfo)
    {
        // 针对攻击帧创建攻击碰撞器
        if (animatorStateInfo.IsName("Attack") && m_render.sprite.name == "Attack")
        {
            // 当攻击帧时
            // 创建攻击碰撞器
            m_attackTrigger.localPosition = m_attackPos;
            // 创建地面碰撞器
            m_groundTrigger.localPosition = m_groundPos;
            // 使攻击碰撞器可用
            m_attackTrigger.gameObject.SetActive(true);
        }
        else
        {
            // 当非攻击帧时
            // 使攻击碰撞器不可用
            m_attackTrigger.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 攻击结束动作
    /// </summary>
    /// <param name="animatorStateInfo">当前动画状态</param>
    private void AttackEnd(AnimatorStateInfo animatorStateInfo)
    {
        if (animatorStateInfo.IsName("Attack") && animatorStateInfo.normalizedTime > 1.0f)
        {
            m_animator.SetBool("Attack", false);
        }
    }

    /// <summary>
    /// 人物移动函数
    /// </summary>
    public void Move()
    {
        // 角色下一帧位置
        Vector2 newPos = transform.parent.position;
        // 上移
        if (Input.GetKey(m_upButton))
        {
            // 计算下一帧坐标
            newPos = PlayerMoveTowards(newPos, Vector2.up, m_speed, Direction.Up);
        }
        // 下移
        if (Input.GetKey(m_downButton))
        {
            // 计算下一帧坐标
            newPos = PlayerMoveTowards(newPos, Vector2.down, m_speed, Direction.Down);
        }
        // 左移
        if (Input.GetKey(m_leftButton))
        {
            // 计算下一帧坐标
            newPos = PlayerMoveTowards(newPos, Vector2.left, m_speed, Direction.Left);
        }
        // 右移
        if (Input.GetKey(m_rightButton))
        {
            // 计算下一帧坐标
            newPos = PlayerMoveTowards(newPos, Vector2.right, m_speed, Direction.Right);
        }
        // 计算新位置与原位置差值
        Vector2 diff = newPos - new Vector2(transform.parent.position.x, transform.parent.position.y);
        // 设置角色新位置
        //transform.position = newPos;
        // 父节点随角色运动
        m_parent.position += new Vector3(diff.x, diff.y, 0);
        // 设置角色层级 使角色遮挡合理
        transform.GetComponent<SpriteRenderer>().sortingOrder = -(int)(newPos.y * 100);

    }

    /// <summary>
    /// 计算角色移动的下一帧坐标点
    /// </summary>
    /// <param name="oldPos">原坐标</param>
    /// <param name="forward">方向向量</param>
    /// <param name="speed">速度</param>
    /// /// <param name="direction">方向</param>
    /// <returns>新坐标点</returns>
    private Vector2 PlayerMoveTowards(Vector2 oldPos, Vector2 forward, float speed, Direction direction)
    {
        Vector2 newPos = Vector2.MoveTowards(oldPos, oldPos + forward, m_speed * Time.deltaTime);
        if (OutSceneLimit(newPos, direction))
        {
            return oldPos;
        }
        return newPos;
    }

    /// <summary>
    /// 判断当前坐标点是否超出场景界限
    /// </summary>
    /// <param name="pos">当前坐标点</param>
    /// <param name="direction">方向</param>
    /// <returns>true：超出界限；false：未超出</returns>
    private bool OutSceneLimit(Vector2 pos, Direction direction)
    {
        // 判断坐标点是否在场景边界包围的长方形内
        switch (direction)
        {
            case Direction.Up:
                // 上移判断上界是否越界
                if (pos.y > SceneLimit.SCENE_UP)
                {
                    return true;
                }
                break;
            case Direction.Down:
                // 下移判断下界是否越界
                if (pos.y < SceneLimit.SCENE_DOWN)
                {
                    return true;
                }
                break;
            case Direction.Left:
                // 左移判断左界是否越界
                if (pos.x < SceneLimit.SCENE_LEFT)
                {
                    return true;
                }
                break;
            case Direction.Right:
                // 右移判断右界是否越界
                if (pos.x > SceneLimit.SCENE_RIGHT)
                {
                    return true;
                }
                break;
            default:
                break;
        }
        // 未越界
        return false;
    }
}
