using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpSpeedInputField : MonoBehaviour
{
    public Player m_player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnEnable()
    {
        // ��ʼ�������ֵ
        GetComponent<InputField>().text = m_player.m_jumpSpeed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
