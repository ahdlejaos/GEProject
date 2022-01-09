using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{

    private Camera m_Camera;
    private Canvas m_Canvas;
    private RectTransform m_RectParent;
    private RectTransform m_RectHp;

    [HideInInspector]
    public Vector3 m_Offset = Vector3.zero;
    [HideInInspector]
    public Transform m_TargetTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Canvas = GetComponentInParent<Canvas>();
        m_Camera = m_Canvas.worldCamera;
        m_RectParent = m_Canvas.GetComponent<RectTransform>();
        m_RectHp = this.gameObject.GetComponent<RectTransform>();
        
    }
    private void LateUpdate()
    {
        //������ǥ�� ��ũ����ǥ�� ����
        var ScreenPos = Camera.main.WorldToScreenPoint(m_TargetTransform.position + m_Offset);

        if(ScreenPos.z < 0.0f)
        {
            ScreenPos *= -1.0f;
        }

        var LocalPos = Vector2.zero;
        //��ũ�� ��ǥ�� ĵ�������� ����Ҽ��ִ� ��ǥ�� ��ȯ
        RectTransformUtility.ScreenPointToLocalPointInRectangle(m_RectParent, ScreenPos, m_Camera, out LocalPos);

        //�� ��ǥ�� ü�°������� ǥ��
        m_RectHp.localPosition = LocalPos;
    }

}
