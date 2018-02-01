using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    #region HideInInspector
    [HideInInspector]
    public Vector2 newAnchoredPosition = Vector2.zero;

    [HideInInspector]
    public bool isPointerOverButton = false;
    #endregion

    [Header("Button Hover Effect")]
    public RectTransform buttonHoverRectTransform = null;
    [Space]
    public float lerpSmoothingFactor = 12.0f;
    [Space]
    public List<Image> borderImages = null;

    [Header("Button Hover Effect Sizes")]
    public Vector2 buttonHoverSizeBig = new Vector2(290.0f, 82.0f);
    public Vector2 buttonHoverSizeSmall = new Vector2(258.0f, 50.0f);

    private Color colorTransparent = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    private Color colorWhite = Color.white;

    private float colorLerpDelay = 0.0f;
    public const float delay = 1.0f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    private void Start()
    {
        buttonHoverRectTransform.sizeDelta = buttonHoverSizeBig;

        for (int i = 0; i < borderImages.Count; i++)
        {
            borderImages[i].color = colorTransparent;
        }
    }

    private void Update()
    {
        if (isPointerOverButton)
        {
            SetButtonHoverEffect(lerpSmoothingFactor, buttonHoverSizeSmall, colorWhite);
        }
        else
        {
            SetButtonHoverEffect(lerpSmoothingFactor, buttonHoverSizeBig, colorTransparent);
        }
    }

    public void SetButtonHoverEffect(float _lerpSmoothingFactor, Vector2 buttonHoverSize, Color newColor)
    {
        buttonHoverRectTransform.anchoredPosition = Vector2.Lerp(buttonHoverRectTransform.anchoredPosition, newAnchoredPosition, Time.deltaTime * _lerpSmoothingFactor);
        buttonHoverRectTransform.sizeDelta = Vector2.Lerp(buttonHoverRectTransform.sizeDelta, buttonHoverSize, Time.deltaTime * _lerpSmoothingFactor);
        SetButtonHoverEffectBorderColor(newColor, _lerpSmoothingFactor);
    }

    private void SetButtonHoverEffectBorderColor(Color newColor, float _lerpSmoothingFactor)
    {
        for (int i = 0; i < borderImages.Count; i++)
        {
            borderImages[i].color = Color.Lerp(borderImages[i].color, newColor, Time.deltaTime * _lerpSmoothingFactor);
        }
    }
}