using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 攻击命中管理器（挂靠在Text下）
/// </summary>
public class HitManager : MonoBehaviour
{
    /// <summary>
    /// 攻击碰撞器是否碰撞角色碰撞器
    /// </summary>
    private bool attackTrigger = false;

    /// <summary>
    /// 地面碰撞器是否相撞
    /// </summary>
    private bool groundTrigger = false;

    /// <summary>
    /// 空中碰撞器是否碰撞
    /// </summary>
    private bool skyTrigger = false;

    /// <summary>
    /// 设置攻击碰撞器相撞
    /// </summary>
    public bool AttackTrigger { set { attackTrigger = value; CheckHit(); } }
    /// <summary>
    /// 设置地面碰撞器相撞
    /// </summary>
    public bool GroundTrigger { set { groundTrigger = value; CheckHit(); } }
    /// <summary>
    /// 设置空中碰撞器相撞
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
    /// 检查攻击是否命中
    /// </summary>
    public void CheckHit()
    {
        if (attackTrigger && groundTrigger && skyTrigger)
        {
            // 攻击命中
            m_text.text = "击中";
        }
        else
        {
            // 攻击未命中
            m_text.text = "未击中";
        }
    }
}
