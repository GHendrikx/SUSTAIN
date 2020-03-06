using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Context
{
    public static class Extensions
    {
        //Because Marnix love lerps
        public static IEnumerator UpdateSlider(RectTransform rectTransform, float targetValue, float overtime)
        {
            float startTime = Time.time;
            float currentValue = rectTransform.anchorMax.x;

            while (Time.time < (startTime + overtime))
            {
                rectTransform.anchorMax = Vector2.Lerp(new Vector2(currentValue, rectTransform.anchorMax.y), new Vector2(targetValue, rectTransform.anchorMax.y), (Time.time - startTime) / overtime);
                yield return null;
            }
            yield return null;
        }

        public static void SetUpdateCost(string text, Image image, GameObject upgradeCost, GameObject upgradeBlock)
        {

            GameObject upgrade = GameObject.Instantiate<GameObject>(upgradeCost);
            upgrade.GetComponentInChildren<TextMeshProUGUI>().text = text;

            //upgrade.GetComponentInChildren<Image>().sprite = image.sprite;
            upgrade.transform.SetParent(upgradeBlock.transform);
            //upgrade.transform.parent = upgradeBlock.transform;
        }
    }
}