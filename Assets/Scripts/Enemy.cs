using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人类
/// </summary>
public class Enemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        // 设置方向键-上下左右
        SetArrowButton(KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow);
        // 设置父节点
        m_parent = transform.parent;
        // 设置地面碰撞器
        m_groundTrigger = m_parent.Find("GroundCollider");
        // 设置地面碰撞器坐标
        m_groundPos = new Vector2(0f, -1.1f);
        // 设置跳跃按键
        JumpButton = KeyCode.L;
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
        // 角色可以跳跃
        Jump();
    }
}
