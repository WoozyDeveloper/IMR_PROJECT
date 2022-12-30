using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private bool inHand;

    // Start is called before the first frame update
    void Start()
    {
        inHand = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("INTRU");
        if(collision.gameObject.tag == "battery")
        {
            inHand = true;
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
