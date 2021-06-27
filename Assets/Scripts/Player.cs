using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����
/// </summary>
public class Player : Character
{
    // Start is called before the first frame update
    void Start()
    {
        // ���÷����-WASD
        SetArrowButton(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D);
        // ���ø��ڵ�
        m_parent = transform.parent;
        // ���ö���������
        m_animator = GetComponent<Animator>();
        // ������Ⱦ��
        m_render = GetComponent<SpriteRenderer>();
        // ���ù�����
        AttackButton = KeyCode.J;
        // ���ù�����ײ��
        m_attackTrigger = transform.Find("AttackCollider");
        // ���ù�����ײ������
        m_attackPos = new Vector2(0.8f, 0.4f);
        // ���õ�����ײ��
        m_groundTrigger = m_parent.Find("GroundCollider");
        // ���õ�����ײ������
        m_groundPos = new Vector2(0f, -1.1f);
        // ������Ծ����
        JumpButton = KeyCode.K;
        // ������Ծ�߶�
        m_jumpHeight = 2;
        // ������Ծ�ٶ�
        m_jumpSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        // ��ɫ�����ƶ�
        Move();
        // ��ɫ���Թ���
        Attack();
        // ��ɫ������Ծ
        Jump();
    }
}
