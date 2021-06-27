using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyCollider : MonoBehaviour
{
    /// <summary>
    ///  ��ײ���󶨽�ɫ
    /// </summary>
    public Transform m_player;

    /// <summary>
    /// ��ɫ��һ֡�߶�
    /// </summary>
    private float m_lastHeight;

    /// <summary>
    /// �������й�����
    /// </summary>
    public HitManager m_hitmanager;

    // Start is called before the first frame update
    void Start()
    {
        m_lastHeight = m_player.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        // �󶨽�ɫ�ĸ߶ȷ����仯
        if(m_player.localPosition.y != m_lastHeight)
        {
            // ��ײ���߶ȸ����ɫ�����仯
            transform.position = new Vector3(transform.position.x, transform.position.y + m_player.localPosition.y - m_lastHeight, transform.position.z);
            // ���ý�ɫλ��
            m_lastHeight = m_player.localPosition.y;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SkyCollider")
        {
            // ������ײ���Ϳ�����ײ���ཻ
            m_hitmanager.SkyTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SkyCollider")
        {
            // ������ײ���Ϳ�����ײ������
            m_hitmanager.SkyTrigger = false;
        }
    }
}
