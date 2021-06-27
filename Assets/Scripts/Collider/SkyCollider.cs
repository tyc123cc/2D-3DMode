using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyCollider : MonoBehaviour
{
    /// <summary>
    ///  碰撞器绑定角色
    /// </summary>
    public Transform m_player;

    /// <summary>
    /// 角色上一帧高度
    /// </summary>
    private float m_lastHeight;

    /// <summary>
    /// 攻击命中管理器
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
        // 绑定角色的高度发生变化
        if(m_player.localPosition.y != m_lastHeight)
        {
            // 碰撞器高度跟随角色发生变化
            transform.position = new Vector3(transform.position.x, transform.position.y + m_player.localPosition.y - m_lastHeight, transform.position.z);
            // 重置角色位置
            m_lastHeight = m_player.localPosition.y;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SkyCollider")
        {
            // 空中碰撞器和空中碰撞器相交
            m_hitmanager.SkyTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SkyCollider")
        {
            // 空中碰撞器和空中碰撞器相离
            m_hitmanager.SkyTrigger = false;
        }
    }
}
