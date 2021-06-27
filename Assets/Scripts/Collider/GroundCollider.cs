using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    /// <summary>
    /// 攻击命中管理器
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
            // 地面碰撞器和地面碰撞器相交
            m_hitmanager.GroundTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "GroundCollider")
        {
            // 地面碰撞器和地面碰撞器相离
            m_hitmanager.GroundTrigger = false;
        }
    }
}
