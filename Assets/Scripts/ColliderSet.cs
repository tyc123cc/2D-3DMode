using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��ײ������
/// </summary>
public class ColliderSet : MonoBehaviour
{
    /// <summary>
    /// ��ײ�����������
    /// </summary>
    public InputField m_xInputField;

    /// <summary>
    /// ��ײ����������
    /// </summary>
    public InputField m_yInputField;

    /// <summary>
    /// ��ײ������
    /// </summary>
    private ColliderType type;

    /// <summary>
    /// ��Ϸ������
    /// </summary>
    public GameManager m_gameManager;

    /// <summary>
    /// ��װ��ײ�����ͣ�ʹ��ֻ��д���ܶ�
    /// </summary>
    public ColliderType Type { set => type = value; }

    /// <summary>
    /// ��������������ִ�С
    /// </summary>
    /// <param name="x">��ײ������</param>
    /// <param name="y">��ײ�����</param>
    public void SetText(float x,float y)
    {
        // ����x��y������ı�
        m_xInputField.text = x.ToString();
        m_yInputField.text = y.ToString();
    }

    /// <summary>
    /// ������ײ����С
    /// </summary>
    public void SetColliderSize()
    {
        try
        {
            // ��ȡx��y������е���ֵ����ת��Ϊfloat��
            float x = float.Parse(m_xInputField.text);
            float y = float.Parse(m_yInputField.text);
            switch (type)
            {
                // ��ǰ����Ϊ������ײ��
                case ColliderType.Player:
                    // ����������ײ����С
                    m_gameManager.SetPlayerColliderSize(x, y);
                    break;
                // ��ǰ����Ϊ������ײ��
                case ColliderType.Attack:
                    // ���ù�����ײ����С
                    m_gameManager.SetAttackColliderSize(x, y);
                    break;
                // ��ǰ����Ϊ������ײ��
                case ColliderType.Ground:
                    // ���õ�����ײ����С
                    m_gameManager.SetGroundColliderSize(x, y);
                    break;
                // ��ǰ����Ϊ������ײ��
                case ColliderType.Sky:
                    // ���õ�����ײ����С
                    m_gameManager.SetSkyColliderSize(x, y);
                    break;
                default:
                    break;
            }
        }
        catch
        {
            // ����Ǹ����ͣ��쳣����
            Debug.LogError("������ײ����С�Ǹ�������X:" + m_xInputField.text + ",Y:" + m_yInputField.text);
        }
        // �رս���
        m_gameManager.HideColliderSet();
    }
}
