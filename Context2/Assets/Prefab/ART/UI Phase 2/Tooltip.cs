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
    private void Awake()

    {
        backgroundRecTransform = transform.Find("background").GetComponent<RectTransform>();
        tooltipText = transform.Find("text").GetComponent<TextMeshProUGUI>();
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
        for (int i = 0; i < raycastResultList.Count; i++)
        {
            if (raycastResultList[i].gameObject.GetComponent<MouseUIClickthrough>() != null)
            {
                Text = raycastResultList[i].gameObject.GetComponent<Transform>().name;
                Debug.Log (raycastResultList[i].gameObject.GetComponent<Transform>().name);
                raycastResultList.RemoveAt(i);

            }

        }
        return raycastResultList.Count > 0;
    }

    private void Update()
    {


        if (!IsMouseOverUIWithIgnores())
        {
            tooltipText.text = Text;
            float textpaddingSize = 4f;
            Vector2 backgroundSize = new Vector2(tooltipText.preferredWidth + textpaddingSize * 2f, tooltipText.preferredHeight + textpaddingSize * 2f);
            backgroundRecTransform.sizeDelta = backgroundSize;
            //gameObject.SetActive(true);
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
