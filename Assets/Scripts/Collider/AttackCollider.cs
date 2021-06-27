using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    /// <summary>
    /// 攻击命中管理器
    /// </summary>
    public HitManager m_hitmanager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            // 攻击碰撞器和人物碰撞器相交
            m_hitmanager.AttackTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // 攻击碰撞器和人物碰撞器离开
            m_hitmanager.AttackTrigger = false;
        }
    }

}
