using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
using TMPro;
public class Tooltip : MonoBehaviour
{
    private static Tooltip instance;

    private string Text ;
    private Camera uiCamera;
    private TextMeshProUGUI tooltipText;
    private RectTransform backgroundRecTransform;
    [SerializeField]
    private Image backgroundImage;
    private void Awake()
    {
        backgroundImage.enabled = true;
        backgroundRecTransform = transform.GetChild(0).GetComponent<RectTransform>();
        tooltipText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private bool IsMouseOverUIWithIgnores()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);
        int counter = 0;
        for (int i = 0; i < raycastResultList.Count; i++)
        {
            if (raycastResultList[i].gameObject.tag.Contains("tip"))
            {
                Text = raycastResultList[i].gameObject.GetComponent<Transform>().name;
                int textLength = Text.Length - 4;
                Text = Text.Substring(0, textLength);
                break;
            }
            counter++;
        }

        if (counter == 0)
            return raycastResultList.Count > 0;
        else
            return false;
    }

    private void Update()
    {
        if (IsMouseOverUIWithIgnores())
        {
            tooltipText.text = Text;
            float textpaddingSize = 4f;

            Vector2 backgroundSize = new Vector2(tooltipText.preferredWidth + textpaddingSize * 2f, tooltipText.preferredHeight + textpaddingSize * 2f);
            backgroundRecTransform.sizeDelta = backgroundSize;
            gameObject.SetActive(true);
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);
            transform.localPosition = localPoint;
            backgroundRecTransform.gameObject.SetActive(true);
            tooltipText.gameObject.SetActive(true);
        }
        else
        {
            backgroundRecTransform.gameObject.SetActive(false);
            tooltipText.gameObject.SetActive(false);
        }
    }
}
