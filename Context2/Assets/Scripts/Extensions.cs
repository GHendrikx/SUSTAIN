using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Context
{
    public class Extensions
    {

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


        //Effects in Allocations
        public static void SetEffectGain(string text, Sprite sprite, GameObject upgradeCost, GameObject upgradeBlock, Color color, SDGBar sdgBar = null)
        {

            Transform upgrade = GameObject.Instantiate(upgradeCost.transform,upgradeBlock.transform);
            upgrade.GetComponentInChildren<TextMeshProUGUI>().color = color;
            upgrade.GetComponentInChildren<TextMeshProUGUI>().text = text + Environment.NewLine;

            Image i = upgrade.GetChild(0).GetChild(0).GetComponentInChildren<Image>();

            if (sdgBar != null)
            {
                i.color = sdgBar.Color;
                TextMeshProUGUI number = i.GetComponent<TextMeshProUGUI>();
                number.text = sdgBar.sdgIndex.ToString();
            }
            i.sprite = sprite;

        }

        public static void SetEffectGain(string text, Sprite sprite, GameObject upgradeCost, GameObject upgradeBlock)
        {
            
            int amount = System.Convert.ToInt32(text);

            Transform upgrade = GameObject.Instantiate(upgradeCost.transform, upgradeBlock.transform);

            string c = (amount > 0) ? "+" : string.Empty;

            upgrade.GetComponentInChildren<TextMeshProUGUI>().text = c + text + Environment.NewLine;
            upgrade.GetComponentInChildren<TextMeshProUGUI>().color = (amount > 0) ? Color.green : Color.red;

            Image i = upgrade.GetChild(0).GetChild(0).GetComponentInChildren<Image>();
            i.gameObject.AddComponent<GUILocationFinder>();
            i.sprite = sprite;
            upgrade.SetParent(upgradeBlock.transform);
        }

        public static void SetAllocatieCost(TextMeshProUGUI text, int fixedGain, Image image, Sprite sprite)
        {
            text.text = "+" + fixedGain;
            text.color = Color.black;
            image.sprite = sprite;
        }

    }
}