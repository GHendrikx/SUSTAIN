using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> bubbleList;
    public List<Vector2> bubbleSpeedList;
    public List<Vector2> bubbleAccList;

    private Transform UICanvas;

    private void Start()
    {
        UICanvas = GameObject.FindWithTag("Canvas").transform;
    }

    private void Update()
    {
        for (int i = 0; i < bubbleList.Count; i++)
        {
            float xPos;
            float yPos;
            float dx;
            float dy;

            Vector2 Pos = bubbleList[i].GetComponent<RectTransform>().position;
            xPos = Pos.x;
            yPos = Pos.y;
            dx = bubbleSpeedList[i].x;
            dy = bubbleSpeedList[i].y;
            dx += 0.1f;
            bubbleSpeedList[i] = new Vector2(dx, dy);
            xPos += dx;
            yPos += dy;
            Pos = new Vector2(xPos, yPos);
            bubbleList[i].transform.SetParent(UICanvas);
            bubbleList[i].GetComponent<RectTransform>().position = Pos;
        }
    }


}
