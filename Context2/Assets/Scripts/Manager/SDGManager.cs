using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Context 
{
    public class SDGManager : MonoBehaviour
    {
        [SerializeField]
        private SDGBar[] sdgBar;
        public SDGBar[] SDGBar
        {
            get
            {
                return sdgBar;
            }
            set
            {
                sdgBar = value;
            }
        }

        private void SetSDGBar(SDGType sdgType,float percentage)
        {
            if (sdgBar[(int)sdgType].LockImage.gameObject.activeInHierarchy)
                return;
            Extensions.UpdateSlider(sdgBar[(int)sdgType].RectTransform, percentage, 0.5f);

            //sdgBar[(int)sdgType].RectTransform.anchorMax = new Vector2(percentage,sdgBar[(int)sdgType].RectTransform.anchorMax.y);
        }
    }

    [System.Serializable]
    public struct SDGBar
    {
        //LockImage
        [SerializeField]
        private Image lockImage;
        public Image LockImage
        {
            get
            {
                return lockImage;
            }
            set
            {
                lockImage = value;
            }
        }

        //Process Image
        [SerializeField]
        private Image processBar;
        public Image ProcessBar
        {
            get
            {
                return processBar;
            }
            set
            {
                processBar = value;
            }
        }

        //Rect Transform of the object
        [SerializeField]
        private RectTransform rectTransform;
        public RectTransform RectTransform
        {
            get
            {
                return rectTransform;
            }
            set
            {
                rectTransform = value;
            }
        }

    } 
}