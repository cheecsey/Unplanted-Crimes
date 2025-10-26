using UnityEngine;

public class BgrdLoop : MonoBehaviour
{
    public GameObject[] levels;
    private Camera cam;
    private Vector2 ScreenBounds;
    public float Buffer;
    public Transform playa;

    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        ScreenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));
        foreach (GameObject obj in levels)
        {
            loadChildObjects(obj);
        }
    }

    void loadChildObjects(GameObject obj)
    {
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - Buffer;
        int childsNeeded = (int)Mathf.Ceil(ScreenBounds.x * 2 / objectWidth);
        GameObject clone = Instantiate(obj) as GameObject;
        for (int i = 0; i < childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    void repositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if (children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - Buffer;
            if (transform.position.x + ScreenBounds.x > lastChild.transform.position.x + halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }
            else if (transform.position.x - ScreenBounds.x < firstChild.transform.position.x - halfObjectWidth)
            {
                lastChild.transform.SetAsLastSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }

    void LateUpdate()
    {
        transform.position = playa.transform.position + new Vector3(0, 1, -5);
        foreach (GameObject obj in levels)
        {
            repositionChildObjects(obj);
        }
    }
}