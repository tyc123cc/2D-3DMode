using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 碰撞器设置
/// </summary>
public class ColliderSet : MonoBehaviour
{
    /// <summary>
    /// 碰撞器长度输入框
    /// </summary>
    public InputField m_xInputField;

    /// <summary>
    /// 碰撞器宽度输入框
    /// </summary>
    public InputField m_yInputField;

    /// <summary>
    /// 碰撞器类型
    /// </summary>
    private ColliderType type;

    /// <summary>
    /// 游戏管理器
    /// </summary>
    public GameManager m_gameManager;

    /// <summary>
    /// 封装碰撞器类型，使其只能写不能读
    /// </summary>
    public ColliderType Type { set => type = value; }

    /// <summary>
    /// 设置输入框中数字大小
    /// </summary>
    /// <param name="x">碰撞器长度</param>
    /// <param name="y">碰撞器宽度</param>
    public void SetText(float x,float y)
    {
        // 设置x和y输入框文本
        m_xInputField.text = x.ToString();
        m_yInputField.text = y.ToString();
    }

    /// <summary>
    /// 设置碰撞器大小
    /// </summary>
    public void SetColliderSize()
    {
        try
        {
            // 获取x和y输入框中的数值，并转换为float型
            float x = float.Parse(m_xInputField.text);
            float y = float.Parse(m_yInputField.text);
            switch (type)
            {
                // 当前设置为人物碰撞器
                case ColliderType.Player:
                    // 设置人物碰撞器大小
                    m_gameManager.SetPlayerColliderSize(x, y);
                    break;
                // 当前设置为攻击碰撞器
                case ColliderType.Attack:
                    // 设置攻击碰撞器大小
                    m_gameManager.SetAttackColliderSize(x, y);
                    break;
                // 当前设置为地面碰撞器
                case ColliderType.Ground:
                    // 设置地面碰撞器大小
                    m_gameManager.SetGroundColliderSize(x, y);
                    break;
                // 当前设置为空中碰撞器
                case ColliderType.Sky:
                    // 设置地面碰撞器大小
                    m_gameManager.SetSkyColliderSize(x, y);
                    break;
                default:
                    break;
            }
        }
        catch
        {
            // 输入非浮点型，异常处理
            Debug.LogError("输入碰撞器大小非浮点数：X:" + m_xInputField.text + ",Y:" + m_yInputField.text);
        }
        // 关闭界面
        m_gameManager.HideColliderSet();
    }
}
