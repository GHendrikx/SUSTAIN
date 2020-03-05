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

        //public static void SetUpdateCost(Data data, GameObject upgradeCost, GameObject upgradeBlock)
        //{
        //    if (data.allocatieCost > 0)
        //        Extensions.SetUpdateCost(data.allocatieCost.ToString(), Resources.Load<Image>("ART/UI_PHASE_2/16X16/iconProcessingPower16X16"), upgradeCost, upgradeBlock);
        //    if (data.creativityCost > 0)
        //        Extensions.SetUpdateCost(data.creativityCost.ToString(), Resources.Load<Image>("ART/UI_PHASE_2/16X16/iconProcessingPower16X16"), upgradeCost, upgradeBlock);
        //    if (data.droneCost > 0)
        //        Extensions.SetUpdateCost(data.droneCost.ToString(), Resources.Load<Image>("ART/UI_PHASE_2/16X16/iconProcessingPower16X16"), upgradeCost, upgradeBlock);
        //    if (data.fundsCost > 0)
        //        Extensions.SetUpdateCost(data.droneCost.ToString(), Resources.Load<Image>("ART/UI_PHASE_2/16X16/iconProcessingPower16X16"), upgradeCost, upgradeBlock);
        //    if (data.influenceCost > 0)
        //        Extensions.SetUpdateCost(data.influenceCost.ToString(), Resources.Load<Image>("ART/UI_PHASE_2/16X16/iconProcessingPower16X16"), upgradeCost, upgradeBlock);
        //    if (data.materialCost > 0)
        //        Extensions.SetUpdateCost(data.materialCost.ToString(), Resources.Load<Image>("ART/UI_PHASE_2/16X16/iconProcessingPower16X16"), upgradeCost, upgradeBlock);
        //    if (data.powerCost > 0)
        //        Extensions.SetUpdateCost(data.powerCost.ToString(), Resources.Load<Image>("ART/UI_PHASE_2/16X16/iconProcessingPower16X16"), upgradeCost, upgradeBlock);
        //    if (data.researchCost > 0)
        //        Extensions.SetUpdateCost(data.researchCost.ToString(), Resources.Load<Image>("ART/UI_PHASE_2/16X16/iconProcessingPower16X16"), upgradeCost, upgradeBlock);
        //}
    }
}