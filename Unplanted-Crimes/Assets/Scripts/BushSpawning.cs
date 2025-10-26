using System;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.UI;

public class BushSpaning : MonoBehaviour
{
    public Sprite[] bushes;
    public GameObject bushTemplate;
    public GameObject bgrd;
    private Camera cam;
    public float buffer;
    public float waitingTime;
    public float timer;
    public float bushMax = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        waitingTime = UnityEngine.Random.Range(1f, 1.35f);
        timer = 0f;
        spawnBush(5);
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;

        if (timer > waitingTime)
        {
            spawnBush(1);
        }
    }

    void spawnBush(int qty)
    {
        float[] bounds = {0,0};
        for (int i = 0; i < bgrd.transform.childCount; i++)
        {
            bounds[i] = bgrd.transform.GetChild(i).transform.position.x;
        }
        for(int i = 0; i < qty; i++)
        {
            float rand = UnityEngine.Random.Range(bounds[0], bounds[1]);
            Vector3 bushPosition = new Vector3(rand, transform.position.y, transform.position.z);
            GameObject bush = Instantiate(bushTemplate) as GameObject;
            bush.transform.position = bushPosition;
            Sprite bushsprite = bushes[UnityEngine.Random.Range(0, 9)];
            bush.GetComponent<SpriteRenderer>().sprite = bushsprite;
        }
    }
}
