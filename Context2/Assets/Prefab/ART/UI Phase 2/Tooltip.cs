using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
public class Tooltip : MonoBehaviour
{
    private static Tooltip instance;

    [SerializeField]
    private Camera uiCamera;

    private TextMeshProUGUI tooltipText;
    private RectTransform backgroundRecTransform;
    private void Awake()
    {
        instance = this;
        backgroundRecTransform = transform.Find("background").GetComponent<RectTransform>();
        tooltipText = transform.Find("text").GetComponent<TextMeshProUGUI>();
        ShowTooltip("texxxxxxxxxxxxxxxxxxxxasdfasfasfasdfafdsafsdxxxxt");
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);
        transform.localPosition = localPoint;
    }
    private void ShowTooltip(string tooltipString)
    {
        gameObject.SetActive(true);

        tooltipText.text = tooltipString;
        float textpaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(tooltipText.preferredWidth + textpaddingSize * 2f, tooltipText.preferredHeight + textpaddingSize * 2f);
        backgroundRecTransform.sizeDelta = backgroundSize;
    }
    private void HideTooltip()
    {
        gameObject.SetActive(false);
    }
    public static void ShowTooltip_Static(string tooltipString)
    {
        instance.ShowTooltip(tooltipString);
    }
    public static void HideTooltip_Static()
    {
        instance.HideTooltip();
    }
}
