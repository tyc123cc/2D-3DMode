using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �������й��������ҿ���Text�£�
/// </summary>
public class HitManager : MonoBehaviour
{
    /// <summary>
    /// ������ײ���Ƿ���ײ��ɫ��ײ��
    /// </summary>
    private bool attackTrigger = false;

    /// <summary>
    /// ������ײ���Ƿ���ײ
    /// </summary>
    private bool groundTrigger = false;

    /// <summary>
    /// ������ײ���Ƿ���ײ
    /// </summary>
    private bool skyTrigger = false;

    /// <summary>
    /// ���ù�����ײ����ײ
    /// </summary>
    public bool AttackTrigger { set { attackTrigger = value; CheckHit(); } }
    /// <summary>
    /// ���õ�����ײ����ײ
    /// </summary>
    public bool GroundTrigger { set { groundTrigger = value; CheckHit(); } }
    /// <summary>
    /// ���ÿ�����ײ����ײ
    /// </summary>
    public bool SkyTrigger { set { skyTrigger = value; CheckHit(); } }

    private Text m_text;

    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// ��鹥���Ƿ�����
    /// </summary>
    public void CheckHit()
    {
        if (attackTrigger && groundTrigger && skyTrigger)
        {
            // ��������
            m_text.text = "����";
        }
        else
        {
            // ����δ����
            m_text.text = "δ����";
        }
    }
}
