using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������
/// </summary>
public class Enemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        // ���÷����-��������
        SetArrowButton(KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow);
        // ���ø��ڵ�
        m_parent = transform.parent;
        // ���õ�����ײ��
        m_groundTrigger = m_parent.Find("GroundCollider");
        // ���õ�����ײ������
        m_groundPos = new Vector2(0f, -1.1f);
        // ������Ծ����
        JumpButton = KeyCode.L;
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
        // ��ɫ������Ծ
        Jump();
    }
}
