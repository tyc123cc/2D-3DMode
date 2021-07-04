using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 菜单物体
    /// </summary>
    public GameObject m_menu;

    /// <summary>
    /// 角色
    /// </summary>
    public List<GameObject> m_players;

    /// <summary>
    /// 玩家
    /// </summary>
    public Player m_player;

    /// <summary>
    /// 攻击碰撞器
    /// </summary>
    public GameObject m_acctakCollider;

    /// <summary>
    /// 玩家地面碰撞器
    /// </summary>
    public GameObject m_groundCollider_Player;

    /// <summary>
    /// 敌人地面碰撞器
    /// </summary>
    public GameObject m_groundCollider_Enemy;

    /// <summary>
    /// 玩家空中碰撞器
    /// </summary>
    public GameObject m_skyCollider_Player;

    /// <summary>
    /// 敌人空中碰撞器
    /// </summary>
    public GameObject m_skyCollider_Enemy;

    /// <summary>
    /// 设置碰撞器大小UI
    /// </summary>
    public ColliderSet m_setCollider;

    /// <summary>
    /// 当前设置的是否为玩家控制角色碰撞器
    /// </summary>
    private bool SetPlayer;


    public void Start()
    {
        // 隐藏菜单
        ShowMenu(false);
        // 显示人物碰撞器
        ShowPlayerCollider(true);
        // 设置人物碰撞器尺寸
        SetPlayerColliderSize(1.2f, 2.47f);
        // 设置攻击碰撞器尺寸
        SetAttackColliderSize(1f, 1f);
        // 隐藏碰撞器设置界面
        HideColliderSet();
    }


    /// <summary>
    /// 显示人物碰撞器设置界面
    /// </summary>
    public void ShowPlayerColliderSet()
    {
        // 设置人物碰撞器
        ShowColliderSet(m_players[0], ColliderType.Player);
    }

    /// <summary>
    /// 显示攻击碰撞器设置界面
    /// </summary>
    public void ShowAttackColliderSet()
    {
        // 设置攻击碰撞器
        ShowColliderSet(m_acctakCollider, ColliderType.Attack);

    }

    /// <summary>
    /// 显示玩家地面碰撞器设置界面
    /// </summary>
    public void ShowPlayerGroundColliderSet()
    {
        // 设置玩家地面碰撞器
        ShowColliderSet(m_groundCollider_Player, ColliderType.Ground);
        // 当前设置为玩家碰撞器
        SetPlayer = true;

    }

    /// <summary>
    /// 显示敌人地面碰撞器设置界面
    /// </summary>
    public void ShowEnemyGroundColliderSet()
    {
        // 设置敌人空中碰撞器
        ShowColliderSet(m_groundCollider_Enemy, ColliderType.Ground);
        // 当前设置为敌人碰撞器
        SetPlayer = false;
    }


    /// <summary>
    /// 显示玩家空中碰撞器设置界面
    /// </summary>
    public void ShowPlayerSkyColliderSet()
    {
        // 设置玩家空中碰撞器
        ShowColliderSet(m_skyCollider_Player, ColliderType.Sky);
        // 当前设置为玩家碰撞器
        SetPlayer = true;

    }

    /// <summary>
    /// 显示敌人空中碰撞器设置界面
    /// </summary>
    public void ShowEnemySkyColliderSet()
    {
        // 设置敌人地面碰撞器
        ShowColliderSet(m_skyCollider_Enemy, ColliderType.Sky);
        // 当前设置为敌人碰撞器
        SetPlayer = false;
    }
    /// <summary>
    /// 设置碰撞器设置界面
    /// </summary>
    /// <param name="collider">碰撞体</param>
    /// <param name="colliderType">需要设置的碰撞器类型</param>
    private void ShowColliderSet(GameObject collider,ColliderType colliderType)
    {
        // 显示碰撞器设置界面
        m_setCollider.gameObject.SetActive(true);
        // 设置碰撞器类型
        m_setCollider.Type = colliderType;
        // 获取攻击碰撞器
        BoxCollider2D collider2D = collider.GetComponent<BoxCollider2D>();
        // 填充人物碰撞器尺寸，为碰撞器设置界面初始化
        m_setCollider.SetText(collider2D.size.x, collider2D.size.y);
    }

    /// <summary>
    /// 隐藏碰撞器设置界面
    /// </summary>
    public void HideColliderSet()
    {
        // 隐藏碰撞器设置界面
        m_setCollider.gameObject.SetActive(false);
    }

    /// <summary>
    /// 显示/隐藏菜单
    /// </summary>
    /// <param name="show">是否显示</param>
    public void ShowMenu(bool show)
    {
        m_menu.SetActive(show);
    }

    /// <summary>
    /// 显示/隐藏人物碰撞器
    /// </summary>
    /// <param name="show">是否显示</param>
    public void ShowPlayerCollider(bool show)
    {
        foreach (GameObject player in m_players)
        {
            Transform img = player.transform.Find("PlayerCollider");
            // 显示/隐藏人物碰撞器
            img.gameObject.SetActive(show);
        }
    }

    /// <summary>
    /// 显示/隐藏攻击碰撞器
    /// </summary>
    /// <param name="show">是否显示</param>
    public void ShowAttackCollider(bool show)
    {

        Transform img = m_acctakCollider.transform.Find("AttackImage");
        // 显示/隐藏人物碰撞器
        img.gameObject.SetActive(show);

    }

    /// <summary>
    /// 显示/隐藏地面碰撞器
    /// </summary>
    /// <param name="show">是否显示</param>
    public void ShowGroundCollider(bool show)
    {

        Transform img = m_groundCollider_Enemy.transform.Find("GroundImage");
        // 显示/隐藏地面碰撞器
        img.gameObject.SetActive(show);

        img = m_groundCollider_Player.transform.Find("GroundImage");
        // 显示/隐藏地面碰撞器
        img.gameObject.SetActive(show);

    }

    /// <summary>
    /// 显示/隐藏空中碰撞器
    /// </summary>
    /// <param name="show">是否显示</param>
    public void ShowSkyCollider(bool show)
    {

        Transform img = m_skyCollider_Player.transform.Find("SkyImage");
        // 显示/隐藏地面碰撞器
        img.gameObject.SetActive(show);

        img = m_skyCollider_Enemy.transform.Find("SkyImage");
        // 显示/隐藏地面碰撞器
        img.gameObject.SetActive(show);

    }

    /// <summary>
    /// 设置人物碰撞器尺寸
    /// </summary>
    /// <param name="x">长度</param>
    /// <param name="y">宽度</param>
    public void SetPlayerColliderSize(float x, float y)
    {
        foreach (GameObject player in m_players)
        {
            // 设置人物碰撞器大小
            BoxCollider2D collider = player.GetComponent<BoxCollider2D>();
            collider.size = new Vector2(x, y);
            Transform img = player.transform.Find("PlayerCollider");
            // 设置碰撞器图像大小
            img.localScale = new Vector3(x, y, 1);
        }
    }

    /// <summary>
    /// 设置攻击碰撞器尺寸
    /// </summary>
    /// <param name="x">长度</param>
    /// <param name="y">宽度</param>
    public void SetAttackColliderSize(float x, float y)
    {
        // 设置攻击碰撞器大小
        BoxCollider2D collider = m_acctakCollider.GetComponent<BoxCollider2D>();
        collider.size = new Vector2(x, y);
        Transform img = m_acctakCollider.transform.Find("AttackImage");
        // 设置碰撞器图像大小
        img.localScale = new Vector3(x, y, 1);
    }

    /// <summary>
    /// 设置地面碰撞器尺寸
    /// </summary>
    /// <param name="x">长度</param>
    /// <param name="y">宽度</param>
    public void SetGroundColliderSize(float x, float y)
    {
        // 根据标识符判断应该操作的碰撞器实体
        GameObject collider = SetPlayer ? m_groundCollider_Player : m_groundCollider_Enemy;
        // 设置攻击碰撞器大小
        BoxCollider2D collider2D = collider.GetComponent<BoxCollider2D>();
        collider2D.size = new Vector2(x, y);
        Transform img = collider.transform.Find("GroundImage");
        // 设置碰撞器图像大小
        img.localScale = new Vector3(x, y, 1);
    }

    /// <summary>
    /// 设置空中碰撞器尺寸
    /// </summary>
    /// <param name="x">长度</param>
    /// <param name="y">宽度</param>
    public void SetSkyColliderSize(float x, float y)
    {
        // 根据标识符判断应该操作的碰撞器实体
        GameObject collider = SetPlayer ? m_skyCollider_Player : m_skyCollider_Enemy;
        // 设置攻击碰撞器大小
        BoxCollider2D collider2D = collider.GetComponent<BoxCollider2D>();
        collider2D.size = new Vector2(x, y);
        Transform img = collider.transform.Find("SkyImage");
        // 设置碰撞器图像大小
        img.localScale = new Vector3(x, y, 1);
    }

    /// <summary>
    /// 设置角色跳跃速度
    /// </summary>
    /// <param name="speed">跳跃速度</param>
    public void SetPlayerJumpSpeed(string speed)
    {
        // 设置角色跳跃速度
        m_player.m_jumpSpeed = float.Parse(speed);
    }
}