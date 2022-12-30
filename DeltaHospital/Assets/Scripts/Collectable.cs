using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Player player;
    private Rigidbody collectable;
    [SerializeField] private bool pickedUp;
    [SerializeField] private Hand leftHand, rightHand;
    // Start is called before the first frame update
    void Start()
    {
        pickedUp = false;

        leftHand = GameObject.FindWithTag("leftHand").GetComponent<Hand>();
        rightHand = GameObject.FindWithTag("rightHand").GetComponent<Hand>();

        collectable = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();
    }


    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        player.addBattery();
        Destroy(gameObject);
    }

    
}
