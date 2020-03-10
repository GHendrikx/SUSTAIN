using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Context
{
    public static class Extensions
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

        public static void SetEffectGain(string text, Sprite sprite, GameObject upgradeCost, GameObject upgradeBlock)
        {

            Transform upgrade = GameObject.Instantiate(upgradeCost.transform,upgradeBlock.transform);

            upgrade.GetComponentInChildren<TextMeshProUGUI>().text = text + Environment.NewLine;
            Image i = upgrade.GetChild(0).GetChild(0).GetComponentInChildren<Image>();
            i.sprite = sprite;
            upgrade.SetParent(upgradeBlock.transform);
        }


        public static void SetAllocatieCost(TextMeshProUGUI text, int fixedGain, Image image, Sprite sprite)
        {
            text.text = "+ " + fixedGain;
            image.sprite = sprite;
        }

    }
}