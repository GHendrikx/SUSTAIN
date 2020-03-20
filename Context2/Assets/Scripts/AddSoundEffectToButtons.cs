using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSoundEffectToButtons : MonoBehaviour
{
    [SerializeField]
    GameObject selectOn;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.GetComponentInChildren<Button>())
            {
                Button[] buttons = child.GetComponentsInChildren<Button>();

                foreach (Button childButton in buttons)
                {
                    childButton.GetComponentInChildren<Button>().onClick.AddListener(() => selectOn.gameObject.SetActive(false));
                    childButton.GetComponentInChildren<Button>().onClick.AddListener(() => selectOn.gameObject.SetActive(true));
                    childButton.GetComponentInChildren<Button>().onClick.AddListener(() => Debug.Log("dsadasds"));
                }

            }
        }
    }
}
