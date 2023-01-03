using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private bool inHand;
    private Vector3 rot;

    // Start is called before the first frame update
    void Start()
    {
        inHand = false;
    }

    void Update()
    {
        rot = transform.localRotation.eulerAngles;
    }

    public Vector3 getPosition()
    {
        return gameObject.transform.position;
    }

    public bool checkHandRotation()
    {
        if(Mathf.Abs(rot.x) > 90f)
        {
            Debug.Log("Give a battery");
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "battery")
        {
            inHand = true;
        }
        if(collision.gameObject.tag == "key")
        {
            FindObjectOfType<Player>().foundKey(true);
            Destroy(collision.gameObject);
            Debug.Log("Gasit cheie");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "battery")
        {
            inHand = false;

        }
    }

    public bool isInHand()
    {
        return inHand;
    }

}
