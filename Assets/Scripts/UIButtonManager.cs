using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButtonManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector2 buttonAnchoredPosition = Vector2.zero;

    private RectTransform rectTransform = null;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        buttonAnchoredPosition = rectTransform.anchoredPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.isPointerOverButton = true;
        UIManager.Instance.newAnchoredPosition = buttonAnchoredPosition;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.isPointerOverButton = false;
    }
}