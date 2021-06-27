using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ɫ����
/// </summary>
public abstract class Character : MonoBehaviour
{
    /// <summary>
    /// ��ɫ�ƶ��ٶ�
    /// </summary>
    public float m_speed = 1.0f;

    /// <summary>
    /// ���ư���
    /// </summary>
    private KeyCode m_upButton;

    /// <summary>
    /// ���ư���
    /// </summary>
    private KeyCode m_downButton;

    /// <summary>
    /// ���ư���
    /// </summary>
    private KeyCode m_leftButton;

    /// <summary>
    /// ���ư���
    /// </summary>
    private KeyCode m_rightButton;

    /// <summary>
    /// ��������
    /// </summary>
    private KeyCode m_attackButton;

    /// <summary>
    /// ��Ծ����
    /// </summary>
    private KeyCode m_jumpButton;

    /// <summary>
    /// ���ڵ�
    /// </summary>
    public Transform m_parent;

    /// <summary>
    /// ����������װ��ʹ����ⲿֻд
    /// </summary>
    public KeyCode AttackButton { set => m_attackButton = value; }

    /// <summary>
    /// ��Ծ������װ��ʹ����ⲿֻд
    /// </summary>
    public KeyCode JumpButton { set => m_jumpButton = value; }

    /// <summary>
    /// ��ɫ�Ķ���������
    /// </summary>
    public Animator m_animator;

    /// <summary>
    /// ��ɫ����Ⱦ��
    /// </summary>
    public SpriteRenderer m_render;

    /// <summary>
    /// ������ײ��
    /// </summary>
    public Transform m_attackTrigger;

    /// <summary>
    /// ������ײ������
    /// </summary>
    public Vector2 m_attackPos;

    /// <summary>
    /// ������ײ��
    /// </summary>
    public Transform m_groundTrigger;

    /// <summary>
    /// ������ײ����Խ�ɫ����
    /// </summary>
    public Vector2 m_groundPos;

    /// <summary>
    /// ��ɫ��Ծ�߶�
    /// </summary>
    public float m_jumpHeight;

    /// <summary>
    /// ��ɫ��Ծ�ٶ�
    /// </summary>
    public float m_jumpSpeed;

    /// <summary>
    /// ��ɫ��ǰ�Ƿ�����Ծ״̬
    /// </summary>
    public bool m_jumpState = false;

    /// <summary>
    /// ���÷������λ
    /// </summary>
    /// <param name="upButton">�ϼ���λ</param>
    /// <param name="downButton">�¼���λ</param>
    /// <param name="leftButton">�����λ</param>
    /// <param name="rightButton">�Ҽ���λ</param>
    public void SetArrowButton(KeyCode upButton, KeyCode downButton, KeyCode leftButton, KeyCode rightButton)
    {
        m_upButton = upButton;
        m_downButton = downButton;
        m_leftButton = leftButton;
        m_rightButton = rightButton;
    }

    /// <summary>
    /// ������Ծ����
    /// </summary>
    public void Jump()
    {
        // ��������Ծ��ʱ����λ�ڵ���ʱ������Ծ
        if (Input.GetKeyDown(m_jumpButton) && Math.Abs(transform.localPosition.y) < 0.01f)
        {
            m_jumpState = true;
        }
        // ��ǰΪ��Ծ״̬
        if (m_jumpState)
        {
            // ������Ծʱ��һ֡����
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, transform.localPosition + Vector3.up, m_jumpSpeed * Time.deltaTime);
            if (transform.localPosition.y > m_jumpHeight)
            {
                // �ﵽ�����Ծ�߶ȣ��½�
                m_jumpState = false;
            }
        }
        // ��ǰΪ�½�״̬
        else if (!m_jumpState && transform.localPosition.y > 0)
        {
            // �����½�ʱ��һ֡����
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, transform.localPosition + Vector3.down, m_jumpSpeed * Time.deltaTime);
            if (Math.Abs(transform.localPosition.y) < 0.01f)
            {
                // �½������棬��������
                transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
            }

        }
    }

    /// <summary>
    /// ���﹥������
    /// </summary>
    public void Attack()
    {
        // �õ���ǰ����״̬
        AnimatorStateInfo animatorStateInfo = m_animator.GetCurrentAnimatorStateInfo(0);
        // ���������״̬��������ť���£����￪ʼִ�й���������ͬʱ���ɹ�����ײ��
        if (Input.GetKeyDown(m_attackButton) && animatorStateInfo.IsName("Idle"))
        {
            m_animator.SetBool("Attack", true);
        }
        // �������ж���
        Attacking(animatorStateInfo);
        // ��������
        AttackEnd(animatorStateInfo);
    }

    /// <summary>
    /// �������ж���
    /// </summary>
    private void Attacking(AnimatorStateInfo animatorStateInfo)
    {
        // ��Թ���֡����������ײ��
        if (animatorStateInfo.IsName("Attack") && m_render.sprite.name == "Attack")
        {
            // ������֡ʱ
            // ����������ײ��
            m_attackTrigger.localPosition = m_attackPos;
            // ����������ײ��
            m_groundTrigger.localPosition = m_groundPos;
            // ʹ������ײ������
            m_attackTrigger.gameObject.SetActive(true);
        }
        else
        {
            // ���ǹ���֡ʱ
            // ʹ������ײ��������
            m_attackTrigger.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// ������������
    /// </summary>
    /// <param name="animatorStateInfo">��ǰ����״̬</param>
    private void AttackEnd(AnimatorStateInfo animatorStateInfo)
    {
        if (animatorStateInfo.IsName("Attack") && animatorStateInfo.normalizedTime > 1.0f)
        {
            m_animator.SetBool("Attack", false);
        }
    }

    /// <summary>
    /// �����ƶ�����
    /// </summary>
    public void Move()
    {
        // ��ɫ��һ֡λ��
        Vector2 newPos = transform.parent.position;
        // ����
        if (Input.GetKey(m_upButton))
        {
            // ������һ֡����
            newPos = PlayerMoveTowards(newPos, Vector2.up, m_speed, Direction.Up);
        }
        // ����
        if (Input.GetKey(m_downButton))
        {
            // ������һ֡����
            newPos = PlayerMoveTowards(newPos, Vector2.down, m_speed, Direction.Down);
        }
        // ����
        if (Input.GetKey(m_leftButton))
        {
            // ������һ֡����
            newPos = PlayerMoveTowards(newPos, Vector2.left, m_speed, Direction.Left);
        }
        // ����
        if (Input.GetKey(m_rightButton))
        {
            // ������һ֡����
            newPos = PlayerMoveTowards(newPos, Vector2.right, m_speed, Direction.Right);
        }
        // ������λ����ԭλ�ò�ֵ
        Vector2 diff = newPos - new Vector2(transform.parent.position.x, transform.parent.position.y);
        // ���ý�ɫ��λ��
        //transform.position = newPos;
        // ���ڵ����ɫ�˶�
        m_parent.position += new Vector3(diff.x, diff.y, 0);
        // ���ý�ɫ�㼶 ʹ��ɫ�ڵ�����
        transform.GetComponent<SpriteRenderer>().sortingOrder = -(int)(newPos.y * 100);

    }

    /// <summary>
    /// �����ɫ�ƶ�����һ֡�����
    /// </summary>
    /// <param name="oldPos">ԭ����</param>
    /// <param name="forward">��������</param>
    /// <param name="speed">�ٶ�</param>
    /// /// <param name="direction">����</param>
    /// <returns>�������</returns>
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
    /// �жϵ�ǰ������Ƿ񳬳���������
    /// </summary>
    /// <param name="pos">��ǰ�����</param>
    /// <param name="direction">����</param>
    /// <returns>true���������ޣ�false��δ����</returns>
    private bool OutSceneLimit(Vector2 pos, Direction direction)
    {
        // �ж�������Ƿ��ڳ����߽��Χ�ĳ�������
        switch (direction)
        {
            case Direction.Up:
                // �����ж��Ͻ��Ƿ�Խ��
                if (pos.y > SceneLimit.SCENE_UP)
                {
                    return true;
                }
                break;
            case Direction.Down:
                // �����ж��½��Ƿ�Խ��
                if (pos.y < SceneLimit.SCENE_DOWN)
                {
                    return true;
                }
                break;
            case Direction.Left:
                // �����ж�����Ƿ�Խ��
                if (pos.x < SceneLimit.SCENE_LEFT)
                {
                    return true;
                }
                break;
            case Direction.Right:
                // �����ж��ҽ��Ƿ�Խ��
                if (pos.x > SceneLimit.SCENE_RIGHT)
                {
                    return true;
                }
                break;
            default:
                break;
        }
        // δԽ��
        return false;
    }
}
