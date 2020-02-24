using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Extensions
{
    //Because Marnix love lerps
   public static IEnumerator UpdateSlider(Slider slider, float targetValue, float overtime)
    {
        float startTime = Time.time;
        float currentValue = slider.value;

        while(Time.time < (startTime + overtime))
        {
            slider.value = Mathf.Lerp(currentValue, targetValue, (Time.time - startTime) / overtime);
            yield return null;
        }
        yield return null;
    }
}
