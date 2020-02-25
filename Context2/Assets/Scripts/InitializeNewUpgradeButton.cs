using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Context
{
    public class InitializeNewUpgradeButton : MonoBehaviour
    {
        [SerializeField]
        private Button buttonPrefab;
        public Tab tab;
        public int amountOfUpgrades;
        public List<Data> initializedData = new List<Data>();

        private void Start()
        {
            Debug.Log(this.gameObject);
        }

        public void InitializeNewButton(Data data,AI ai)
        {

            initializedData.Add(data);
            Button button = GameObject.Instantiate(buttonPrefab, transform);
            UpdateButton update = button.gameObject.AddComponent<UpdateButton>();
            update.ButtonInformation(data, ai);
            RectTransform rectTransform = button.GetComponent<RectTransform>();
            rectTransform.position = new Vector2(rectTransform.position.x, 0);//button.transform.GetSiblingIndex() * 110f); transform.parent.gameObject.GetComponent<RectTransform>().position.y - 65f -
            button.gameObject.SetActive(true);
            button.GetComponentInChildren<Text>().text = data.name;
            amountOfUpgrades++;
            Debug.Log(data.name + "FINISHED");
        }

        public void InitializeNewSlider(Data data, AI ai)
        {

        }
    }
}