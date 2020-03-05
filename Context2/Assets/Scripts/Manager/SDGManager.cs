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

        [SerializeField]
        private AI ai;

        public void Start()
        {
        }

        public void UpdateSDGValues()
        {
            SetSDGBar((SDGType)0, ai.SDGProgress01);
            SetSDGBar((SDGType)1, ai.SDGProgress02);
            SetSDGBar((SDGType)2, ai.SDGProgress03);
            SetSDGBar((SDGType)3, ai.SDGProgress04);
            SetSDGBar((SDGType)4, ai.SDGProgress05);
            SetSDGBar((SDGType)5, ai.SDGProgress06);
            SetSDGBar((SDGType)6, ai.SDGProgress07);
            SetSDGBar((SDGType)7, ai.SDGProgress08);
            SetSDGBar((SDGType)8, ai.SDGProgress09);
            SetSDGBar((SDGType)9, ai.SDGProgress10);
            SetSDGBar((SDGType)10, ai.SDGProgress11);
            SetSDGBar((SDGType)11, ai.SDGProgress12);
            SetSDGBar((SDGType)12, ai.SDGProgress13);
            SetSDGBar((SDGType)13, ai.SDGProgress14);
            SetSDGBar((SDGType)14, ai.SDGProgress15);
            SetSDGBar((SDGType)15, ai.SDGProgress16);
            SetSDGBar((SDGType)16, ai.SDGProgress17);
        }

        private void SetSDGBar(SDGType sdgType, float percentage)
        {
            if (sdgBar[(int)sdgType].LockImage.gameObject.activeInHierarchy)
                return;

            StartCoroutine(Extensions.UpdateSlider(sdgBar[(int)sdgType].RectTransform, percentage, 0.5f));

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