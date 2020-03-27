using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeactiveButton : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private Image otherButtonImage;
    [SerializeField]
    private Sprite sprite;

    private void Start()
    {
        button.onClick.AddListener(() => CheckIfOtherButtonIsActivated());
    }

    private void CheckIfOtherButtonIsActivated()
    {
        if (otherButtonImage.sprite.name.Contains("Pressed"))
            otherButtonImage.sprite = sprite;
    }
}
