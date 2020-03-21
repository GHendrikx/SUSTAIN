using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject Bubble;

    private List<GameObject> bubbleList;
    private GameObject Destination;
    public float startspeed = 5;
    private float amount = 10;
    private float spawninterval = 0.05f;

    // Start is called before the first frame update
    void Awake()
    {
        Destination = GameObject.FindGameObjectWithTag("Destination");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject spawnedBubble = Instantiate(Bubble, transform);
            
            if (spawnedBubble.GetComponent<Rigidbody>() != null)
            {
                SpawnAudio();
                spawnedBubble.GetComponent<Rigidbody>().velocity = new Vector3(startspeed * Random.Range(-1, 1f), startspeed * Random.Range(-1f, 1f), 0f);
            }
            yield return new WaitForSeconds(spawninterval);
        }
    }
    void SpawnAudio()
    {
        AudioManager.Instance.SpawnBubble.SetActive(false);
        AudioManager.Instance.SpawnBubble.SetActive(true);
    }
}
