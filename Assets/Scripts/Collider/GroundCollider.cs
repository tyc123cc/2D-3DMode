using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    /// <summary>
    /// �������й�����
    /// </summary>
    public HitManager m_hitmanager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GroundCollider")
        {
            // ������ײ���͵�����ײ���ཻ
            m_hitmanager.GroundTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "GroundCollider")
        {
            // ������ײ���͵�����ײ������
            m_hitmanager.GroundTrigger = false;
        }
    }
}
