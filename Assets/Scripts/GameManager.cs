using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// �˵�����
    /// </summary>
    public GameObject m_menu;

    /// <summary>
    /// ��ɫ
    /// </summary>
    public List<GameObject> m_players;

    /// <summary>
    /// ���
    /// </summary>
    public Player m_player;

    /// <summary>
    /// ������ײ��
    /// </summary>
    public GameObject m_acctakCollider;

    /// <summary>
    /// ��ҵ�����ײ��
    /// </summary>
    public GameObject m_groundCollider_Player;

    /// <summary>
    /// ���˵�����ײ��
    /// </summary>
    public GameObject m_groundCollider_Enemy;

    /// <summary>
    /// ��ҿ�����ײ��
    /// </summary>
    public GameObject m_skyCollider_Player;

    /// <summary>
    /// ���˿�����ײ��
    /// </summary>
    public GameObject m_skyCollider_Enemy;

    /// <summary>
    /// ������ײ����СUI
    /// </summary>
    public ColliderSet m_setCollider;

    /// <summary>
    /// ��ǰ���õ��Ƿ�Ϊ��ҿ��ƽ�ɫ��ײ��
    /// </summary>
    private bool SetPlayer;


    public void Start()
    {
        // ���ز˵�
        ShowMenu(false);
        // ��ʾ������ײ��
        ShowPlayerCollider(true);
        // ����������ײ���ߴ�
        SetPlayerColliderSize(1.2f, 2.47f);
        // ���ù�����ײ���ߴ�
        SetAttackColliderSize(1f, 1f);
        // ������ײ�����ý���
        HideColliderSet();
    }


    /// <summary>
    /// ��ʾ������ײ�����ý���
    /// </summary>
    public void ShowPlayerColliderSet()
    {
        // ����������ײ��
        ShowColliderSet(m_players[0], ColliderType.Player);
    }

    /// <summary>
    /// ��ʾ������ײ�����ý���
    /// </summary>
    public void ShowAttackColliderSet()
    {
        // ���ù�����ײ��
        ShowColliderSet(m_acctakCollider, ColliderType.Attack);

    }

    /// <summary>
    /// ��ʾ��ҵ�����ײ�����ý���
    /// </summary>
    public void ShowPlayerGroundColliderSet()
    {
        // ������ҵ�����ײ��
        ShowColliderSet(m_groundCollider_Player, ColliderType.Ground);
        // ��ǰ����Ϊ�����ײ��
        SetPlayer = true;

    }

    /// <summary>
    /// ��ʾ���˵�����ײ�����ý���
    /// </summary>
    public void ShowEnemyGroundColliderSet()
    {
        // ���õ��˿�����ײ��
        ShowColliderSet(m_groundCollider_Enemy, ColliderType.Ground);
        // ��ǰ����Ϊ������ײ��
        SetPlayer = false;
    }


    /// <summary>
    /// ��ʾ��ҿ�����ײ�����ý���
    /// </summary>
    public void ShowPlayerSkyColliderSet()
    {
        // ������ҿ�����ײ��
        ShowColliderSet(m_skyCollider_Player, ColliderType.Sky);
        // ��ǰ����Ϊ�����ײ��
        SetPlayer = true;

    }

    /// <summary>
    /// ��ʾ���˿�����ײ�����ý���
    /// </summary>
    public void ShowEnemySkyColliderSet()
    {
        // ���õ��˵�����ײ��
        ShowColliderSet(m_skyCollider_Enemy, ColliderType.Sky);
        // ��ǰ����Ϊ������ײ��
        SetPlayer = false;
    }
    /// <summary>
    /// ������ײ�����ý���
    /// </summary>
    /// <param name="collider">��ײ��</param>
    /// <param name="colliderType">��Ҫ���õ���ײ������</param>
    private void ShowColliderSet(GameObject collider,ColliderType colliderType)
    {
        // ��ʾ��ײ�����ý���
        m_setCollider.gameObject.SetActive(true);
        // ������ײ������
        m_setCollider.Type = colliderType;
        // ��ȡ������ײ��
        BoxCollider2D collider2D = collider.GetComponent<BoxCollider2D>();
        // ���������ײ���ߴ磬Ϊ��ײ�����ý����ʼ��
        m_setCollider.SetText(collider2D.size.x, collider2D.size.y);
    }

    /// <summary>
    /// ������ײ�����ý���
    /// </summary>
    public void HideColliderSet()
    {
        // ������ײ�����ý���
        m_setCollider.gameObject.SetActive(false);
    }

    /// <summary>
    /// ��ʾ/���ز˵�
    /// </summary>
    /// <param name="show">�Ƿ���ʾ</param>
    public void ShowMenu(bool show)
    {
        m_menu.SetActive(show);
    }

    /// <summary>
    /// ��ʾ/����������ײ��
    /// </summary>
    /// <param name="show">�Ƿ���ʾ</param>
    public void ShowPlayerCollider(bool show)
    {
        foreach (GameObject player in m_players)
        {
            Transform img = player.transform.Find("PlayerCollider");
            // ��ʾ/����������ײ��
            img.gameObject.SetActive(show);
        }
    }

    /// <summary>
    /// ��ʾ/���ع�����ײ��
    /// </summary>
    /// <param name="show">�Ƿ���ʾ</param>
    public void ShowAttackCollider(bool show)
    {

        Transform img = m_acctakCollider.transform.Find("AttackImage");
        // ��ʾ/����������ײ��
        img.gameObject.SetActive(show);

    }

    /// <summary>
    /// ��ʾ/���ص�����ײ��
    /// </summary>
    /// <param name="show">�Ƿ���ʾ</param>
    public void ShowGroundCollider(bool show)
    {

        Transform img = m_groundCollider_Enemy.transform.Find("GroundImage");
        // ��ʾ/���ص�����ײ��
        img.gameObject.SetActive(show);

        img = m_groundCollider_Player.transform.Find("GroundImage");
        // ��ʾ/���ص�����ײ��
        img.gameObject.SetActive(show);

    }

    /// <summary>
    /// ��ʾ/���ؿ�����ײ��
    /// </summary>
    /// <param name="show">�Ƿ���ʾ</param>
    public void ShowSkyCollider(bool show)
    {

        Transform img = m_skyCollider_Player.transform.Find("SkyImage");
        // ��ʾ/���ص�����ײ��
        img.gameObject.SetActive(show);

        img = m_skyCollider_Enemy.transform.Find("SkyImage");
        // ��ʾ/���ص�����ײ��
        img.gameObject.SetActive(show);

    }

    /// <summary>
    /// ����������ײ���ߴ�
    /// </summary>
    /// <param name="x">����</param>
    /// <param name="y">���</param>
    public void SetPlayerColliderSize(float x, float y)
    {
        foreach (GameObject player in m_players)
        {
            // ����������ײ����С
            BoxCollider2D collider = player.GetComponent<BoxCollider2D>();
            collider.size = new Vector2(x, y);
            Transform img = player.transform.Find("PlayerCollider");
            // ������ײ��ͼ���С
            img.localScale = new Vector3(x, y, 1);
        }
    }

    /// <summary>
    /// ���ù�����ײ���ߴ�
    /// </summary>
    /// <param name="x">����</param>
    /// <param name="y">���</param>
    public void SetAttackColliderSize(float x, float y)
    {
        // ���ù�����ײ����С
        BoxCollider2D collider = m_acctakCollider.GetComponent<BoxCollider2D>();
        collider.size = new Vector2(x, y);
        Transform img = m_acctakCollider.transform.Find("AttackImage");
        // ������ײ��ͼ���С
        img.localScale = new Vector3(x, y, 1);
    }

    /// <summary>
    /// ���õ�����ײ���ߴ�
    /// </summary>
    /// <param name="x">����</param>
    /// <param name="y">���</param>
    public void SetGroundColliderSize(float x, float y)
    {
        // ���ݱ�ʶ���ж�Ӧ�ò�������ײ��ʵ��
        GameObject collider = SetPlayer ? m_groundCollider_Player : m_groundCollider_Enemy;
        // ���ù�����ײ����С
        BoxCollider2D collider2D = collider.GetComponent<BoxCollider2D>();
        collider2D.size = new Vector2(x, y);
        Transform img = collider.transform.Find("GroundImage");
        // ������ײ��ͼ���С
        img.localScale = new Vector3(x, y, 1);
    }

    /// <summary>
    /// ���ÿ�����ײ���ߴ�
    /// </summary>
    /// <param name="x">����</param>
    /// <param name="y">���</param>
    public void SetSkyColliderSize(float x, float y)
    {
        // ���ݱ�ʶ���ж�Ӧ�ò�������ײ��ʵ��
        GameObject collider = SetPlayer ? m_skyCollider_Player : m_skyCollider_Enemy;
        // ���ù�����ײ����С
        BoxCollider2D collider2D = collider.GetComponent<BoxCollider2D>();
        collider2D.size = new Vector2(x, y);
        Transform img = collider.transform.Find("SkyImage");
        // ������ײ��ͼ���С
        img.localScale = new Vector3(x, y, 1);
    }

    /// <summary>
    /// ���ý�ɫ��Ծ�ٶ�
    /// </summary>
    /// <param name="speed">��Ծ�ٶ�</param>
    public void SetPlayerJumpSpeed(string speed)
    {
        // ���ý�ɫ��Ծ�ٶ�
        m_player.m_jumpSpeed = float.Parse(speed);
    }
}