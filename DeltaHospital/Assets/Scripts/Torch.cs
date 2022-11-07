using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    private GameObject currentObj;
    List<GameObject> objects = new List<GameObject>();
    [SerializeField] private Rigidbody torch;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("STARTING TORCH");
    }

    // Update is called once per frame
    void Update()
    {
        currentObj = findNearestObj(objects);
        if (currentObj.tag == "monster")
        {
            Debug.Log("FREEZE MONSTER");
        }
    }

    private float calculateDistance(Vector3 a, Vector3 b)
    {
        return Mathf.Sqrt((a.z - b.z) * (a.z - b.z) + (a.x - b.x) * (a.x - b.x));
    }

    private GameObject findNearestObj(List<GameObject> objList)
    {
        float distance;
        float minimum_distance = float.MaxValue;
        GameObject foundObj = null;
        foreach(GameObject obj in objList)
        {
            distance = calculateDistance(transform.position, obj.transform.position);
            if(distance < minimum_distance)
            {
                minimum_distance = distance;
                foundObj = obj;
            }
        }
        if (!foundObj)
            Debug.LogError("No obj found");
        return foundObj;
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("ADAUG UNU");
        if(collider.gameObject.tag != "floor" && collider.gameObject.tag != "Untagged")
            objects.Add(collider.gameObject);
    }
}
