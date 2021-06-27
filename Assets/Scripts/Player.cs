using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家类
/// </summary>
public class Player : Character
{
    // Start is called before the first frame update
    void Start()
    {
        // 设置方向键-WASD
        SetArrowButton(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D);
        // 设置父节点
        m_parent = transform.parent;
        // 设置动画控制器
        m_animator = GetComponent<Animator>();
        // 设置渲染器
        m_render = GetComponent<SpriteRenderer>();
        // 设置攻击键
        AttackButton = KeyCode.J;
        // 设置攻击碰撞器
        m_attackTrigger = transform.Find("AttackCollider");
        // 设置攻击碰撞器坐标
        m_attackPos = new Vector2(0.8f, 0.4f);
        // 设置地面碰撞器
        m_groundTrigger = m_parent.Find("GroundCollider");
        // 设置地面碰撞器坐标
        m_groundPos = new Vector2(0f, -1.1f);
        // 设置跳跃按键
        JumpButton = KeyCode.K;
        // 设置跳跃高度
        m_jumpHeight = 2;
        // 设置跳跃速度
        m_jumpSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        // 角色可以移动
        Move();
        // 角色可以攻击
        Attack();
        // 角色可以跳跃
        Jump();
    }
}
