using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpriteAnimation : MonoBehaviour
{

    public Image m_Image;

    public Sprite[] m_SpriteArray;
    public float m_Speed = .02f;

    private int m_IndexSprite;
    Coroutine m_CorotineAnim;
    bool IsDone;
    public bool loop = true;
    public bool autoStart = true;

    private void Start()
    {
        if (autoStart)
        {
            StartUIAnim();
        }
    }

    public void StartUIAnim()
    {
        IsDone = false;
        StartCoroutine(PlayAnimUI());
    }
    public void StopUIAnim()
    {
        IsDone = true;
        StopCoroutine(PlayAnimUI());
    }
    IEnumerator PlayAnimUI()
    {
        yield return new WaitForSeconds(m_Speed);
        if (m_IndexSprite >= m_SpriteArray.Length)
        {
            if (loop)
            {
                m_IndexSprite = 0;    
            }
            else
            {
                IsDone = true;
                StopUIAnim();
            }
            
        }
        m_Image.sprite = m_SpriteArray[m_IndexSprite];
        m_IndexSprite += 1;
        if (IsDone == false)
            m_CorotineAnim = StartCoroutine(PlayAnimUI());
    }
}
