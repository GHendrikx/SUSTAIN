using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GUILocationFinder : MonoBehaviour
{
    private RectTransform rt;
    private Vector3 location;
    private int multiplier;
    private int change;
    private int amount;
    private int destination;
    private Transform allocatieBlock;
    private Transform UICanvas;

    private GameObject Bubble;
    private BubbleManager BubbleManager;
    private GameObject Destination;
    public float startspeed = 5;
    private float spawninterval = 0.05f;

    void Start()
    {
        BubbleManager = GameObject.FindObjectOfType<BubbleManager>();
        
        UICanvas = GameObject.FindWithTag("Canvas").transform;
        Bubble = gameObject;
        rt = GetComponent<RectTransform>();

        GetChange();
        if (transform.parent.parent.parent.parent.parent.childCount > 1)
        {
            return;
            allocatieBlock = transform.parent.parent.parent.parent.parent.GetChild(1).transform;
            allocatieBlock.GetChild(1).GetComponent<Button>().onClick.AddListener(GetMultiplier);
            allocatieBlock.GetChild(2).GetComponent<Button>().onClick.AddListener(GetMultiplier);
        }
        GetMultiplier();
        DisplayWorldCorners();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(Spawn());
        }
    }

    void DisplayWorldCorners()
    {
        Vector3[] v = new Vector3[4];
        rt.GetWorldCorners(v);

        location = (v[1] + v[2] + v[3] + v[0]) / 4;
    }

    void GetChange()
    {
        return;
        string c = transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        change = int.Parse(c);
    }

    void GetMultiplier()
    {
        if(transform.parent.parent.parent.parent.parent.childCount > 1)
        {
            string c = allocatieBlock.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            multiplier = int.Parse(c);
        }
        else
        {
            multiplier = 1;
        }
        GetAmount();
    }

    void GetAmount()
    {
        amount = change * multiplier;
        //Debug.Log("allocatie multiplier = " + multiplier + " change: " + change + " amount " + amount);
    }

        IEnumerator Spawn()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject spawnedBubble = Instantiate(Bubble, transform);
            Destroy(spawnedBubble.GetComponent<GUILocationFinder>());
            spawnedBubble.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
            spawnedBubble.GetComponent<Image>().preserveAspect = true;
            spawnedBubble.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            spawnedBubble.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
            spawnedBubble.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
            BubbleManager.bubbleList.Add(spawnedBubble);
            BubbleManager.bubbleSpeedList.Add(new Vector2(Random.Range(-2.2f, 2.2f), Random.Range(-2.2f, 2.22f)));
            yield return new WaitForSeconds(spawninterval);
        }
    }
}
